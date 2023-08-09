using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Model
{
    public class BattleResults
    {
        public int Result { get; set; }
        public PlayerCards Cards { get; set; } = new();
    }
}
