namespace Sbc.DTO
{
    /// <summary>
    /// Base DTO class for all data transfer objects
    /// </summary>
    public abstract class BaseDto
    {
        public int id { get; set; }
        public DateTime created_at { get; set; } = DateTime.UtcNow;
        public DateTime? updated_at { get; set; }
    }
}
