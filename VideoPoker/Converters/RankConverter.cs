using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VideoPoker.Models;

namespace VideoPoker.Converters
{
    public class RankConverter : JsonConverter<Rank>
    {
        private Dictionary<string, Rank> stringToRank = new()
        {
            { "2",     Rank.Two   },
            { "3",     Rank.Three },
            { "4",     Rank.Four  },
            { "5",     Rank.Five  },
            { "6",     Rank.Six   },
            { "7",     Rank.Seven },
            { "8",     Rank.Eight },
            { "9",     Rank.Nine  },
            { "10",    Rank.Ten   },
            { "jack",  Rank.Jack  },
            { "queen", Rank.Queen },
            { "king",  Rank.King  },
            { "ace",   Rank.Ace   }
        };

        public override Rank Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return stringToRank[reader.GetString().ToLower()];
        }

        public override void Write(Utf8JsonWriter writer, Rank value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
