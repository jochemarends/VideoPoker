using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Models
{
    public class Straight : IHand
    {
        public string Name => "Straight";
        public int Reward => 4;

        public bool IsMatch(IList<Card> hand)
        {
            // If the hand contains duplicates we already know its not a straight.
            if (hand.Count != hand.Distinct().Count())
                return false;

            // Convert to int so we can perform arithmetic operations on the elements. 
            var numbers = hand.Select(card => (int)card.Rank);
            var distances = numbers.Select((a, b) => Math.Abs(b - a));
            return distances.All(distance => distance == 1);
        }
    }
}
