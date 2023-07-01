using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Models
{
    public class Deck
    {
        public Queue<Card> Cards { get; set; } = new();
        public Card DrawCard() => Cards.Dequeue();
        public void Add(Card card) => Cards.Enqueue(card);
    }
}
