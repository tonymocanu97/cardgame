using CardGame.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Helper;
using CardGame.Model;

namespace CardGame
{
    public partial class Battle
    {
        private readonly AbilityCheck _abilityCheck;
        private readonly SpecialAbilityCheck _specialAbilityCheck;
        private readonly Message _message;

        private GameDetails _gameDetails;

        public Battle(List<CardDetails> cardSetA, List<CardDetails> cardSetB)
        {
            _gameDetails = new GameDetails
            {
                CardSetA = cardSetA,
                CardSetB = cardSetB,
                SelectedCards = new List<CardDetails>(),
                TemporaryCards = new List<CardDetails>(),
                BattleOutcomes = new List<BattleResults>()
            };
            _abilityCheck = new AbilityCheck(_gameDetails);
            _specialAbilityCheck = new SpecialAbilityCheck(_gameDetails);
            _message = new Message();
        }

        public GameDetails AttackResult(CardDetails selectedCardFromSetA, CardDetails selectedCardFromSetB)
        {
            _gameDetails.TurnNumber++;
            _gameDetails.SelectedCards = new List<CardDetails>() { selectedCardFromSetA, selectedCardFromSetB };

            AbilityCase();

            _gameDetails.CardSetA.Remove(selectedCardFromSetA);
            _gameDetails.CardSetB.Remove(selectedCardFromSetB);

            return new GameDetails() { CardSetA = _gameDetails.CardSetA, CardSetB = _gameDetails.CardSetB };
        }

        private void AbilityCase()
        {
            if (_gameDetails.SelectedCards[0].SpecialAbilityId != 0 ||
                _gameDetails.SelectedCards[1].SpecialAbilityId != 0)
            {
                CardHasSpecialAbility();
            }
            else if (_gameDetails.SelectedCards[0].RoleId == _gameDetails.SelectedCards[1].RoleId &&
                     (_gameDetails.SelectedCards[0].AbilityId != 0 ||
                      _gameDetails.SelectedCards[1].AbilityId != 0))
            {
                CardHasAbility();
            }
            else
            {
                CardHasNoAbility();
            }
        }

        private void CardHasSpecialAbility()
        {
            var gameDetails = _specialAbilityCheck.Start();
            _gameDetails = gameDetails;
        }

        private void CardHasAbility()
        {
            Draw();

            var gameDetails = _abilityCheck.Start();
            _gameDetails = gameDetails;
        }

        private void CardHasNoAbility()
        {
            _gameDetails.BattleOutcomes = BattleOutcomes();

            foreach (var item in _gameDetails.BattleOutcomes.Where(item =>
                         item.Cards.CardA == _gameDetails.SelectedCards[0].RoleId &&
                         item.Cards.CardB == _gameDetails.SelectedCards[1].RoleId))
            {
                switch (item.Result)
                {
                    case 0:
                        Draw();
                        break;
                    default:
                        CollectionUpdate(item.Result);
                        break;
                }
            }
        }

        private void CollectionUpdate(int value)
        {
            var counter = 0;
            if (_gameDetails.TemporaryCards.Any())
            {
                counter += _gameDetails.TemporaryCards.Count;
                _gameDetails.TemporaryCards.Clear();
            }

            switch (value)
            {
                case 1:
                    _gameDetails.CollectionSetA += 2 + counter;
                    _message.WriteSetA(_gameDetails.SelectedCards[0].RoleId, _gameDetails.SelectedCards[1].RoleId);
                    break;
                default:
                    _gameDetails.CollectionSetB += 2 + counter;
                    _message.WriteSetB(_gameDetails.SelectedCards[0].RoleId, _gameDetails.SelectedCards[1].RoleId);
                    break;
            }
        }

        private void Draw()
        {
            _gameDetails.TemporaryCards.Add(_gameDetails.SelectedCards[0]);
            _gameDetails.TemporaryCards.Add(_gameDetails.SelectedCards[1]);

            _message.WriteDraw(_gameDetails.SelectedCards[0].RoleId, _gameDetails.SelectedCards[1].RoleId);
        }

        public void Winner()
        {
            Console.WriteLine("\r\n");
            Console.WriteLine(_gameDetails.CollectionSetA > _gameDetails.CollectionSetB
                ? $"Player 1 wins with {_gameDetails.CollectionSetA} cards."
                : $"Player 2 wins with {_gameDetails.CollectionSetB} cards.");
        }
    }
}
