using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for card_default
    /// </summary>
    public class CardDefaultDto : BaseDto
    {
        public int id { get; set; }

        public int? quality_id { get; set; }

        public int? rarity_id { get; set; }

        public int min_rating { get; set; }

        public int max_rating { get; set; }

        public int min_price { get; set; }

        public int? max_price { get; set; }
    }
}
