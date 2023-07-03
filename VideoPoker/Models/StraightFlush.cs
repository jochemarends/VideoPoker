using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Models
{
    public class StraightFlush : IHand
    {
        private readonly Straight straight = new();
        private readonly Flush flush = new();
        public string Name => "Straight Flush";
        public int Reward => 8;

        public bool IsMatch(IList<Card> hand)
        {
            return straight.IsMatch(hand) && flush.IsMatch(hand); 
        }
    }
}
