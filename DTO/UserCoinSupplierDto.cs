using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for user_coin_supplier
    /// </summary>
    public class UserCoinSupplierDto : BaseDto
    {
        public int id { get; set; }

        public int user_id { get; set; }

        public int? supplier__user_id { get; set; }

        public DateTime create_date { get; set; }

        public DateTime? update_date { get; set; }
    }
}
