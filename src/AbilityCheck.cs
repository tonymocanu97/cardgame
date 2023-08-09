using CardGame.Config;
using CardGame.Helper;
using CardGame.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class AbilityCheck
    {
        private readonly List<Ability> _abilities;
        private readonly GameDetails _gameDetails;
        private readonly Message _message;
        
        public AbilityCheck(GameDetails gameDetails)
        {
            Deserialize deserialize = new();
            _abilities = deserialize.Ability();
            _gameDetails = gameDetails;
            _message = new Message();
        }

        public GameDetails Start()
        {
            foreach (var item in _abilities.Where(item =>
                         item.Id == _gameDetails.SelectedCards[0].AbilityId ||
                         item.Id == _gameDetails.SelectedCards[1].AbilityId))
            {
                switch (item.Id)
                {
                    case 1:
                        SimpleExtraction();
                        break;
                    case 2:
                        ResetAll();
                        break;
                    case 3:
                        ExplosiveGrowth();
                        break;
                    case 4:
                        GreatRevolution();
                        break;
                }
                break;
            }
            _message.WriteAbility(_gameDetails.SelectedCards[0].AbilityId, _gameDetails.SelectedCards[1].AbilityId);

            return _gameDetails;
        }

        private void SimpleExtraction()
        {
            Random random = new();
            var indexSetB = random.Next(_gameDetails.CardSetB.Count);

            _gameDetails.CardSetB.RemoveAt(indexSetB);
        }

        private void ResetAll()
        {
            Deserialize deserialize = new();
            var cardSetB = deserialize.CardSetB();
            var collectedCardsSetB = cardSetB.ExceptBy(_gameDetails.CardSetB.Select(x => x.Id), x => x.Id);

            foreach (var item in collectedCardsSetB)
            {
                _gameDetails.TemporaryCards.Add(item);
            }
            _gameDetails.CollectionSetB = 0;
        }

        private void ExplosiveGrowth()
        {
            _gameDetails.CollectionSetB += _gameDetails.TurnNumber;
        }

        private void GreatRevolution()
        {
            foreach (var item in _gameDetails.BattleOutcomes)
            {
                item.Result = item.Result switch
                {
                    1 => 2,
                    2 => 1,
                    _ => item.Result
                };
            }
        }
    }
}