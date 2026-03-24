using System.Text.Json;
using Sbc.DAL.Repositories;

namespace Sbc.SERVICE
{
    /// <summary>
    /// Generic CRUD service that works with DTOs in SERVICE layer and entities in DAL repository layer.
    /// </summary>
    public class GenericCrudService<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        private readonly GenericRepository<TEntity> _repository;

        protected GenericCrudService(GenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<ReturnObject> SaveAsync(TDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return new ReturnObject
                    {
                        result = false,
                        message = "DTO boş olamaz.",
                        data = null
                    };
                }

                var id = GetIdValue(dto);
                var entity = MapDtoToEntity(dto);
                if (entity == null)
                {
                    return new ReturnObject
                    {
                        result = false,
                        message = "DTO entity'ye map edilemedi.",
                        data = null
                    };
                }

                if (id <= 0)
                {
                    SetDateIfExists(entity, "create_date", DateTime.UtcNow, onlyIfDefault: true);
                    SetDateIfExists(entity, "update_date", null, onlyIfDefault: false);

                    await _repository.AddAsync(entity);

                    return new ReturnObject
                    {
                        result = true,
                        message = "Kayıt oluşturuldu.",
                        data = MapEntityToDto(entity)
                    };
                }

                var existing = await _repository.GetByIdAsync(id);
                if (existing == null)
                {
                    return new ReturnObject
                    {
                        result = false,
                        message = "Güncellenecek kayıt bulunamadı.",
                        data = null
                    };
                }

                SetDateIfExists(entity, "update_date", DateTime.UtcNow, onlyIfDefault: false);
                await _repository.UpdateAsync(entity);

                return new ReturnObject
                {
                    result = true,
                    message = "Kayıt güncellendi.",
                    data = MapEntityToDto(entity)
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

        public async Task<ReturnObject> GetAllAsync()
        {
            try
            {
                var entities = await _repository.GetAllAsync();
                var list = entities.Select(MapEntityToDto).ToList();

                return new ReturnObject
                {
                    result = true,
                    message = "Kayıtlar getirildi.",
                    data = list
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

        public async Task<ReturnObject> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                {
                    return new ReturnObject
                    {
                        result = false,
                        message = "Kayıt bulunamadı.",
                        data = null
                    };
                }

                return new ReturnObject
                {
                    result = true,
                    message = "Kayıt getirildi.",
                    data = MapEntityToDto(entity)
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

        public async Task<ReturnObject> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repository.GetByIdAsync(id);
                if (existing == null)
                {
                    return new ReturnObject
                    {
                        result = false,
                        message = "Silinecek kayıt bulunamadı.",
                        data = null
                    };
                }

                await _repository.DeleteAsync(id);

                return new ReturnObject
                {
                    result = true,
                    message = "Kayıt silindi.",
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

        protected virtual TEntity? MapDtoToEntity(TDto dto)
        {
            var json = JsonSerializer.Serialize(dto);
            return JsonSerializer.Deserialize<TEntity>(json);
        }

        protected virtual TDto? MapEntityToDto(TEntity entity)
        {
            var json = JsonSerializer.Serialize(entity);
            return JsonSerializer.Deserialize<TDto>(json);
        }

        private static int GetIdValue(TDto dto)
        {
            var prop = dto.GetType().GetProperty("id");
            if (prop == null)
            {
                return 0;
            }

            var value = prop.GetValue(dto);
            if (value == null)
            {
                return 0;
            }

            return value is int intValue ? intValue : 0;
        }

        private static void SetDateIfExists(TEntity entity, string propertyName, DateTime? dateValue, bool onlyIfDefault)
        {
            var prop = entity.GetType().GetProperty(propertyName);
            if (prop == null || !prop.CanWrite)
            {
                return;
            }

            if (prop.PropertyType == typeof(DateTime))
            {
                if (dateValue == null)
                {
                    return;
                }

                var currentValue = (DateTime)prop.GetValue(entity)!;
                if (onlyIfDefault && currentValue != default)
                {
                    return;
                }

                prop.SetValue(entity, dateValue.Value);
                return;
            }

            if (prop.PropertyType == typeof(DateTime?))
            {
                if (!onlyIfDefault)
                {
                    prop.SetValue(entity, dateValue);
                    return;
                }

                var currentValue = (DateTime?)prop.GetValue(entity);
                if (currentValue == null || currentValue == default)
                {
                    prop.SetValue(entity, dateValue);
                }
            }
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
