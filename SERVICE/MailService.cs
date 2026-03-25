using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class MailService : GenericCrudService<mail, MailDto>, IMailService
    {
        public MailService() : this(new MailRepository())
        {
        }

        public MailService(MailRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveMailAsync(MailDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllMailsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetMailByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteMailAsync(int id)
            => DeleteAsync(id);
    }
}
