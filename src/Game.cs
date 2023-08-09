using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Config;
using CardGame.Helper;
using CardGame.Model;

namespace CardGame
{
    public class Game
    {
        private List<CardDetails> _cardSetA;
        private List<CardDetails> _cardSetB;
        private int _indexSetA;
        private int _indexSetB;
        private readonly Battle _battle;
        private GameDetails _updateSet;

        public Game()
        {
            Deserialize deserialize = new();

            var message = new Message();
            message.Show();

            _cardSetA = deserialize.CardSetA();
            _cardSetB = deserialize.CardSetB();

            _battle = new Battle(_cardSetA, _cardSetB);
            _updateSet = new GameDetails();
        }

        public void Start()
        {
            Random random = new();

            while (_cardSetA.Count > 0 && _cardSetB.Count > 0)
            {
                _indexSetA = random.Next(_cardSetA.Count);
                _indexSetB = random.Next(_cardSetB.Count);

                _updateSet = _battle.AttackResult(_cardSetA[_indexSetA], _cardSetB[_indexSetB]);

                _cardSetA = _updateSet.CardSetA;
                _cardSetB = _updateSet.CardSetB;
            }

            _battle.Winner();
        }
    }
}
