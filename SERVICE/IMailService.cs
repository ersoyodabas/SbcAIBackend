using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IMailService
    {
        Task<ReturnObject> SaveMailAsync(MailDto dto);
        Task<ReturnObject> GetAllMailsAsync();
        Task<ReturnObject> GetMailByIdAsync(int id);
        Task<ReturnObject> DeleteMailAsync(int id);
    }
}
