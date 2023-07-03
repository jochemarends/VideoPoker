using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Models
{
    public class RoyalFlush : IHand
    {
        private readonly List<Rank> requiredRanks = new()
        {
            Rank.Ten, Rank.Jack, Rank.Queen, Rank.King, Rank.Ace
        };

        public string Name => "Royal Flush";
        public int Reward => 9;

        public bool IsMatch(IList<Card> cards)
        {
            return cards.Select(card => card.Rank).Order().SequenceEqual(requiredRanks.Order());
        }
    }
}
