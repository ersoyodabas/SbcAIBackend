using Sbc.DAL.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Sbc.DAL.Repositories
{
    public class CoinCardRepository : GenericRepository<coin_card>
    {
        public CoinCardRepository() : base() { }

        public CoinCardRepository(_DbContext context) : base(context) { }

        public async Task<int> DeleteLowedRatioCardsAsync(double maxRatioExclusive = 2)
        {
            var allCards = await _context.coin_card.ToListAsync();

            var cards = allCards
                .Where(card =>
                {
                    var buyNow = card.price_pc ?? card.price_cross;
                    var maxPrice = card.max_price_pc ?? card.max_price_cross;

                    if (!buyNow.HasValue || buyNow.Value <= 0 || !maxPrice.HasValue)
                    {
                        return true;
                    }

                    var ratio = (maxPrice.Value - buyNow.Value) / buyNow.Value;
                    return ratio < maxRatioExclusive;
                })
                .ToList();

            if (cards.Count == 0)
            {
                return 0;
            }

            _context.coin_card.RemoveRange(cards);
            await _context.SaveChangesAsync();
            return cards.Count;
        }
    }
}
