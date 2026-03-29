using Microsoft.EntityFrameworkCore;
using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class UserRepository : GenericRepository<user>
    {
        private const string WebLoginType = "web";
        private const string BotLoginType = "bot";

        public sealed class UserPagedRow
        {
            public user User { get; set; } = null!;

            public DateTime? WebUpdateTime { get; set; }

            public DateTime? BotUpdateTime { get; set; }
        }

        public UserRepository() : base() { }

        public UserRepository(_DbContext context) : base(context) { }

        public async Task<(IEnumerable<UserPagedRow> Items, int Total)> GetPagedAsync(
            int page, int pageSize,
            string? search, string? role, bool? active, bool? banned,
            string? sortBy, bool sortDesc)
        {
            var query = AsQueryable()
                .Select(u => new UserPagedRow
                {
                    User = u,
                    WebUpdateTime = _context.user_login
                        .Where(l => l.user_id == u.id && l.type == WebLoginType)
                        .Max(l => (DateTime?)l.update_time),
                    BotUpdateTime = _context.user_login
                        .Where(l => l.user_id == u.id && l.type == BotLoginType)
                        .Max(l => (DateTime?)l.update_time)
                });

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.ToLower();
                query = query.Where(row =>
                    row.User.name.ToLower().Contains(term) ||
                    row.User.email.ToLower().Contains(term) ||
                    (row.User.username != null && row.User.username.ToLower().Contains(term)));
            }

            if (!string.IsNullOrWhiteSpace(role))
                query = query.Where(row => row.User.role == role);

            if (active.HasValue)
                query = query.Where(row => row.User.active == active.Value);

            if (banned.HasValue)
                query = query.Where(row => row.User.banned == banned.Value);

            var total = await query.CountAsync();

            query = sortBy switch
            {
                "name" => sortDesc ? query.OrderByDescending(row => row.User.name) : query.OrderBy(row => row.User.name),
                "email" => sortDesc ? query.OrderByDescending(row => row.User.email) : query.OrderBy(row => row.User.email),
                "role" => sortDesc ? query.OrderByDescending(row => row.User.role) : query.OrderBy(row => row.User.role),
                "membership_type" => sortDesc ? query.OrderByDescending(row => row.User.membership_type) : query.OrderBy(row => row.User.membership_type),
                "create_date" => sortDesc ? query.OrderByDescending(row => row.User.create_date) : query.OrderBy(row => row.User.create_date),
                "last_login_date_app" => sortDesc ? query.OrderByDescending(row => row.User.last_login_date_app) : query.OrderBy(row => row.User.last_login_date_app),
                "web_update_time" => sortDesc
                    ? query.OrderByDescending(row => row.WebUpdateTime)
                    : query.OrderBy(row => row.WebUpdateTime),
                "bot_update_time" => sortDesc
                    ? query.OrderByDescending(row => row.BotUpdateTime)
                    : query.OrderBy(row => row.BotUpdateTime),
                _ => query.OrderByDescending(row => row.BotUpdateTime)
                    .ThenByDescending(row => row.User.id)
            };

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, total);
        }

        public async Task<user?> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            return await AsQueryable()
                .FirstOrDefaultAsync(u => u.email.ToLower() == email.ToLower());
        }
    }
}
