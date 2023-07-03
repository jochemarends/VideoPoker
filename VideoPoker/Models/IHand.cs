using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Models
{
    public interface IHand
    {
        string Name { get; }
        int Reward { get; }
        bool IsMatch(IList<Card> hand);
    }
}
