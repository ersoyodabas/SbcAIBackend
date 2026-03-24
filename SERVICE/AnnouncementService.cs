using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    /// <summary>
    /// Announcement service.
    /// DTO ↔ Entity mapping is handled in SERVICE layer.
    /// Repository works with entities only.
    /// </summary>
    public class AnnouncementService : IAnnouncementService
    {
        private readonly AnnouncementRepository _repository;

        public AnnouncementService() : this(new AnnouncementRepository())
        {
        }

        public AnnouncementService(AnnouncementRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// DTO'dan announcement oluşturur veya günceller.
        /// Mapping SERVICE katmanında yapılır, repository entity ile çalışır.
        /// </summary>
        public async Task<ReturnObject> SaveAnnouncementAsync(AnnouncementDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return new ReturnObject
                    {
                        result = false,
                        message = "Announcement bilgisi boş olamaz.",
                        data = null
                    };
                }

                if (dto.id <= 0)
                {
                    var created = await CreateAsync(dto);
                    return new ReturnObject
                    {
                        result = true,
                        message = "Announcement başarıyla oluşturuldu.",
                        data = created
                    };
                }

                var updated = await UpdateAsync(dto.id, dto);
                if (updated == null)
                {
                    return new ReturnObject
                    {
                        result = false,
                        message = "Güncellenecek announcement bulunamadı.",
                        data = null
                    };
                }

                return new ReturnObject
                {
                    result = true,
                    message = "Announcement başarıyla güncellendi.",
                    data = updated
                };
            }
            catch (Exception ex)
            {
                return new ReturnObject
                {
                    result = false,
                    message = $"Kayıt sırasında hata oluştu: {GetFullExceptionMessage(ex)}",
                    data = null
                };
            }
        }

        public async Task<ReturnObject> GetAllAnnouncementsAsync()
        {
            try
            {
                var items = await GetAllAsync();
                return new ReturnObject
                {
                    result = true,
                    message = "Announcement listesi getirildi.",
                    data = items
                };
            }
            catch (Exception ex)
            {
                return new ReturnObject
                {
                    result = false,
                    message = $"Listeleme sırasında hata oluştu: {GetFullExceptionMessage(ex)}",
                    data = null
                };
            }
        }

        public async Task<ReturnObject> GetAnnouncementByIdAsync(int id)
        {
            try
            {
                var item = await GetByIdAsync(id);
                if (item == null)
                {
                    return new ReturnObject
                    {
                        result = false,
                        message = "Announcement bulunamadı.",
                        data = null
                    };
                }

                return new ReturnObject
                {
                    result = true,
                    message = "Announcement getirildi.",
                    data = item
                };
            }
            catch (Exception ex)
            {
                return new ReturnObject
                {
                    result = false,
                    message = $"Getirme sırasında hata oluştu: {GetFullExceptionMessage(ex)}",
                    data = null
                };
            }
        }

        public async Task<ReturnObject> DeleteAnnouncementAsync(int id)
        {
            try
            {
                var deleted = await DeleteAsync(id);
                if (!deleted)
                {
                    return new ReturnObject
                    {
                        result = false,
                        message = "Silinecek announcement bulunamadı.",
                        data = null
                    };
                }

                return new ReturnObject
                {
                    result = true,
                    message = "Announcement silindi.",
                    data = id
                };
            }
            catch (Exception ex)
            {
                return new ReturnObject
                {
                    result = false,
                    message = $"Silme sırasında hata oluştu: {GetFullExceptionMessage(ex)}",
                    data = null
                };
            }
        }

        public async Task<IEnumerable<AnnouncementDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapEntityToDto).ToList();
        }

        public async Task<AnnouncementDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            return MapEntityToDto(entity);
        }

        public async Task<AnnouncementDto> CreateAsync(AnnouncementDto dto)
        {
            var entity = MapDtoToEntity(dto);

            entity.create_date = entity.create_date == default ? DateTime.UtcNow : entity.create_date;
            entity.update_date = null;

            await _repository.AddAsync(entity);
            return MapEntityToDto(entity);
        }

        public async Task<AnnouncementDto?> UpdateAsync(int id, AnnouncementDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
            {
                return null;
            }

            existing.type = dto.type;
            existing.icon = dto.icon;
            existing.logo = dto.logo;
            existing.img_url = dto.img_url;
            existing.link_url = dto.link_url;
            existing.desc_tr = dto.desc_tr;
            existing.desc_en = dto.desc_en;
            existing.duration = dto.duration;
            existing.return_button = dto.return_button;
            existing.return_url = dto.return_url;
            existing.header_tr = dto.header_tr;
            existing.header_en = dto.header_en;
            existing.start_date = dto.start_date;
            existing.end_date = dto.end_date;
            existing.update_date = DateTime.UtcNow;

            await _repository.UpdateAsync(existing);
            return MapEntityToDto(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
            {
                return false;
            }

            await _repository.DeleteAsync(id);
            return true;
        }

        private static announcement MapDtoToEntity(AnnouncementDto dto)
        {
            return new announcement
            {
                id = dto.id,
                type = dto.type,
                icon = dto.icon,
                logo = dto.logo,
                img_url = dto.img_url,
                link_url = dto.link_url,
                desc_tr = dto.desc_tr,
                desc_en = dto.desc_en,
                duration = dto.duration,
                return_button = dto.return_button,
                return_url = dto.return_url,
                create_date = dto.create_date,
                update_date = dto.update_date,
                header_tr = dto.header_tr,
                header_en = dto.header_en,
                start_date = dto.start_date,
                end_date = dto.end_date
            };
        }

        private static AnnouncementDto MapEntityToDto(announcement entity)
        {
            return new AnnouncementDto
            {
                id = entity.id,
                type = entity.type,
                icon = entity.icon,
                logo = entity.logo,
                img_url = entity.img_url,
                link_url = entity.link_url,
                desc_tr = entity.desc_tr,
                desc_en = entity.desc_en,
                duration = entity.duration,
                return_button = entity.return_button,
                return_url = entity.return_url,
                create_date = entity.create_date,
                update_date = entity.update_date,
                header_tr = entity.header_tr,
                header_en = entity.header_en,
                start_date = entity.start_date,
                end_date = entity.end_date
            };
        }

        private static string GetFullExceptionMessage(Exception ex)
        {
            var messages = new List<string>();
            var current = ex;

            while (current != null)
            {
                if (!string.IsNullOrWhiteSpace(current.Message))
                {
                    messages.Add(current.Message);
                }

                current = current.InnerException;
            }

            return string.Join(" | ", messages);
        }
    }
}
