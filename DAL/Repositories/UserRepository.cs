using Microsoft.EntityFrameworkCore;
using Sbc.DAL.Models.Entity;
using Sbc.DTO.LoginPanel;

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
                    row.User.email.ToLower().Contains(term));
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
                "subscription_type" => sortDesc ? query.OrderByDescending(row => row.User.subscription_type) : query.OrderBy(row => row.User.subscription_type),
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

        public async Task<user?> GetUserForLoginPanelAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            return await AsQueryable()
                .Include(u => u.user_startup)
                    .ThenInclude(us => us.feature)
                .FirstOrDefaultAsync(u => u.email.ToLower() == email.ToLower());
        }

        /// <summary>
        /// Gets user data for login panel as DTOs to avoid circular reference issues
        /// </summary>
        public async Task<(LoginPanelUserDto? User, List<LoginPanelUserStartupDto> UserStartups)> GetUserForLoginPanelDtoAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return (null, new List<LoginPanelUserStartupDto>());

            var user = await AsQueryable()
                .Where(u => u.email.ToLower() == email.ToLower())
                .Select(u => new LoginPanelUserDto
                {
                    id = u.id,
                    name = u.name,
                    email = u.email,
                    phone = u.phone,
                    phone_area = u.phone_area,
                    membership_type = u.subscription_type,
                    membership_end_date = u.subscription_end_date,
                    lang_app = u.lang_app,
                    login_limit = u.login_limit,
                    trial_status = u.trial_status
                })
                .FirstOrDefaultAsync();

            if (user == null)
                return (null, new List<LoginPanelUserStartupDto>());

            // Get user startups with features (projected to DTOs to avoid circular references)
            var userStartups = await _context.user_startup
                .Where(us => us.user_id == user.id)
                .OrderBy(us => us.sort_number)
                .Select(us => new LoginPanelUserStartupDto
                {
                    id = us.id,
                    sort_number = us.sort_number,
                    feature_id = us.feature_id,
                    active = us.active,
                    create_date = us.create_date,
                    value1 = us.value1,
                    value2 = us.value2,
                    update_time = us.update_time,
                    feature = us.feature != null ? new LoginPanelFeatureDto
                    {
                        id = us.feature.id,
                        sort_number = us.feature.sort_number,
                        code = us.feature.code,
                        active = us.feature.active,
                        create_date = us.feature.create_date,
                        value1 = us.feature.value1,
                        value2 = us.feature.value2,
                        name_en = us.feature.name_en,
                        name_tr = us.feature.name_tr
                    } : null
                })
                .ToListAsync();

            return (user, userStartups);
        }
    }
}
