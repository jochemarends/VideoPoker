using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Models
{
    public class HandEvaluator : ICollection<IHand>
    {
        private readonly IList<IHand> hands = new List<IHand>();

        public int Count => hands.Count;
        public bool IsReadOnly => hands.IsReadOnly;

        public IHand Evaluate(IList<Card> playerHand)
        {
            return hands.OrderBy(hand => hand.Reward).Reverse().FirstOrDefault(hand => hand.IsMatch(playerHand), new LosingHand());
        }

        public void Add(IHand hand) => hands.Add(hand);

        public void Clear() => hands.Clear();
        public bool Contains(IHand item) => hands.Contains(item);
        public void CopyTo(IHand[] array, int arrayIndex) => hands.CopyTo(array, arrayIndex);
        public bool Remove(IHand item) => hands.Remove(item);
        public IEnumerator<IHand> GetEnumerator() => hands.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => hands.GetEnumerator();
    }
}
