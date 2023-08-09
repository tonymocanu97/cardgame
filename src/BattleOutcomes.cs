using CardGame.Config;
using CardGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public partial class Battle
    {
        public List<BattleResults> BattleOutcomes()
        {
            return new List<BattleResults>
            {
                new BattleResults { Result = 0, Cards = new PlayerCards(){CardA = 1, CardB = 1}},
                new BattleResults { Result = 2, Cards = new PlayerCards(){CardA = 1, CardB = 2}},
                new BattleResults { Result = 1, Cards = new PlayerCards(){CardA = 1, CardB = 3}},
                new BattleResults { Result = 1, Cards = new PlayerCards(){CardA = 1, CardB = 4}},
                new BattleResults { Result = 2, Cards = new PlayerCards(){CardA = 1, CardB = 5}},
                new BattleResults { Result = 1, Cards = new PlayerCards(){CardA = 1, CardB = 6}},
                new BattleResults { Result = 1, Cards = new PlayerCards(){CardA = 2, CardB = 1}},
                new BattleResults { Result = 0, Cards = new PlayerCards(){CardA = 2, CardB = 2}},
                new BattleResults { Result = 2, Cards = new PlayerCards(){CardA = 2, CardB = 3}},
                new BattleResults { Result = 1, Cards = new PlayerCards(){CardA = 2, CardB = 4}},
                new BattleResults { Result = 2, Cards = new PlayerCards(){CardA = 2, CardB = 5}},
                new BattleResults { Result = 1, Cards = new PlayerCards(){CardA = 2, CardB = 6}},
                new BattleResults { Result = 2, Cards = new PlayerCards(){CardA = 3, CardB = 1}},
                new BattleResults { Result = 1, Cards = new PlayerCards(){CardA = 3, CardB = 2}},
                new BattleResults { Result = 0, Cards = new PlayerCards(){CardA = 3, CardB = 3}},
                new BattleResults { Result = 1, Cards = new PlayerCards(){CardA = 3, CardB = 4}},
                new BattleResults { Result = 2, Cards = new PlayerCards(){CardA = 3, CardB = 5}},
                new BattleResults { Result = 1, Cards = new PlayerCards(){CardA = 3, CardB = 6}},
                new BattleResults { Result = 2, Cards = new PlayerCards(){CardA = 4, CardB = 1}},
                new BattleResults { Result = 2, Cards = new PlayerCards(){CardA = 4, CardB = 2}},
                new BattleResults { Result = 2, Cards = new PlayerCards(){CardA = 4, CardB = 3}},
                new BattleResults { Result = 0, Cards = new PlayerCards(){CardA = 4, CardB = 4}},
                new BattleResults { Result = 1, Cards = new PlayerCards(){CardA = 4, CardB = 5}},
                new BattleResults { Result = 1, Cards = new PlayerCards(){CardA = 4, CardB = 6}},
                new BattleResults { Result = 1, Cards = new PlayerCards(){CardA = 5, CardB = 1}},
                new BattleResults { Result = 1, Cards = new PlayerCards(){CardA = 5, CardB = 2}},
                new BattleResults { Result = 1, Cards = new PlayerCards(){CardA = 5, CardB = 3}},
                new BattleResults { Result = 2, Cards = new PlayerCards(){CardA = 5, CardB = 4}},
                new BattleResults { Result = 0, Cards = new PlayerCards(){CardA = 5, CardB = 5}},
                new BattleResults { Result = 0, Cards = new PlayerCards(){CardA = 5, CardB = 6}},
                new BattleResults { Result = 2, Cards = new PlayerCards(){CardA = 6, CardB = 1}},
                new BattleResults { Result = 2, Cards = new PlayerCards(){CardA = 6, CardB = 2}},
                new BattleResults { Result = 2, Cards = new PlayerCards(){CardA = 6, CardB = 3}},
                new BattleResults { Result = 2, Cards = new PlayerCards(){CardA = 6, CardB = 4}},
                new BattleResults { Result = 0, Cards = new PlayerCards(){CardA = 6, CardB = 5}},
                new BattleResults { Result = 0, Cards = new PlayerCards(){CardA = 6, CardB = 6}}
            };
        }
    }
}
