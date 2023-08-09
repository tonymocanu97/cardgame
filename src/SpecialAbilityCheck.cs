using CardGame.Config;
using CardGame.Helper;
using CardGame.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class SpecialAbilityCheck
    {
        private readonly List<SpecialAbility> _specialAbilities;
        private readonly GameDetails _gameDetails;
        private readonly Message _message;

        public SpecialAbilityCheck(GameDetails gameDetails)
        {
            Deserialize deserialize = new();
            _specialAbilities = deserialize.SpecialAbility();
            _gameDetails = gameDetails;
            _message = new Message();
        }

        public GameDetails Start()
        {
            foreach (var item in _specialAbilities.Where(item =>
                         item.Id == _gameDetails.SelectedCards[0].SpecialAbilityId ||
                         item.Id == _gameDetails.SelectedCards[1].SpecialAbilityId))
            {
                switch (item.Id)
                {
                    case 1:
                        UndefeatedHero();
                        break;
                    case 2:
                        TrojanHorse();
                        break;
                }
                break;
            }
            return _gameDetails;
        }

        private void UndefeatedHero()
        {
            CollectionUpdate(1);
        }

        private void TrojanHorse()
        {
            if (_gameDetails.SelectedCards[0].RoleId >= 5) 
                return;

            CollectionUpdate(1);
            _gameDetails.CollectionSetB += _gameDetails.CollectionSetA / 2;
            _gameDetails.CollectionSetA /= 2;
        }

        private void CollectionUpdate(int value)
        {
            switch (value)
            {
                case 1:
                    _gameDetails.CollectionSetA += 2;
                    _message.WriteSetA(_gameDetails.SelectedCards[0].RoleId, _gameDetails.SelectedCards[1].RoleId);
                    break;
                default:
                    _gameDetails.CollectionSetB += 2;
                    _message.WriteSetB(_gameDetails.SelectedCards[0].RoleId, _gameDetails.SelectedCards[1].RoleId);
                    break;
            }
            _message.WriteSpecialAbility(_gameDetails.SelectedCards[0].SpecialAbilityId, _gameDetails.SelectedCards[1].SpecialAbilityId);
        }
    }
}