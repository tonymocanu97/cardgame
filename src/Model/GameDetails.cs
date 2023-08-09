using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Config;

namespace CardGame.Model
{
    public class GameDetails
    {
        public List<CardDetails> CardSetA { get; set; }
        public List<CardDetails> CardSetB { get; set; }
        public List<CardDetails> SelectedCards { get; set; }
        public List<CardDetails> TemporaryCards { get; set; }
        public int CollectionSetA { get; set; }
        public int CollectionSetB { get; set; }
        public List<BattleResults> BattleOutcomes { get; set; }
        public int TurnNumber { get; set; }

        public GameDetails()
        {
            CardSetA = new List<CardDetails>();
            CardSetB = new List<CardDetails>();
            SelectedCards = new List<CardDetails>();
            TemporaryCards = new List<CardDetails>();
            BattleOutcomes = new List<BattleResults>();
        }
    }
}
