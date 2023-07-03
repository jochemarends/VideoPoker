using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Models
{
    public class LosingHand : IHand
    {
        public string Name => "Losing Hand";
        public int Reward => 0;
        public bool IsMatch(IList<Card> hand) => true;
    }
}
