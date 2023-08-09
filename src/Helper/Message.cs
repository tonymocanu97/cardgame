using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Config;

namespace CardGame.Helper
{
    public class Message
    {
        private readonly List<Role> _roles;
        private readonly List<Ability> _abilities;
        private readonly List<SpecialAbility> _specialAbilities;
        private readonly List<CardDetails> _cardDetailsSetA;
        private readonly List<CardDetails> _cardDetailsSetB;

        public Message()
        {
            Deserialize helper = new();

            _roles = helper.Roles();
            _abilities = helper.Ability();
            _specialAbilities = helper.SpecialAbility();
            _cardDetailsSetA = helper.CardSetA();
            _cardDetailsSetB = helper.CardSetB();
        }

        public void Show()
        {
            Console.WriteLine("Set A: ");

            foreach (var item2 in from item in _cardDetailsSetA from item2 in _roles where item.RoleId == item2.Id select item2)
            {
                Console.Write($"{item2.Name} ");
            }

            Console.WriteLine("\r\nSet B: ");

            foreach (var item2 in from item in _cardDetailsSetB from item2 in _roles where item.RoleId == item2.Id select item2)
            {
                Console.Write($"{item2.Name} ");
            }

            Console.WriteLine();
        }

        public void WriteAbility(int selectedCardFromSetA, int selectedCardFromSetB)
        {
            foreach (var item in _abilities.Where(item => selectedCardFromSetA == item.Id || selectedCardFromSetB == item.Id))
            {
                Console.Write($"\r\nAbility used: {item.Name} -> {item.Description} ");
                break;
            }
        }

        public void WriteSpecialAbility(int selectedCardFromSetA, int selectedCardFromSetB)
        {
            foreach (var item in _specialAbilities.Where(item => selectedCardFromSetA == item.Id || selectedCardFromSetB == item.Id))
            {
                Console.Write($"\r\nSpecial ability used: {item.Name} -> {item.Description} ");
                break;
            }
        }

        public void WriteSetA(int selectedCardFromSetA, int selectedCardFromSetB)
        {
            WriteBattles(selectedCardFromSetA, selectedCardFromSetB);

            foreach (var item in _roles.Where(item => item.Id == selectedCardFromSetA))
            {
                Console.Write($"{item.Name}");
            }
        }

        public void WriteSetB(int selectedCardFromSetA, int selectedCardFromSetB)
        {
            WriteBattles(selectedCardFromSetA, selectedCardFromSetB);

            foreach (var item in _roles.Where(item => item.Id == selectedCardFromSetB))
            {
                Console.Write($"{item.Name}");
            }
        }

        public void WriteDraw(int selectedCardFromSetA, int selectedCardFromSetB)
        {
            WriteBattles(selectedCardFromSetA, selectedCardFromSetB);

            Console.Write("Draw");
        }

        private void WriteBattles(int selectedCardFromSetA, int selectedCardFromSetB)
        {
            foreach (var item in _roles.Where(item => item.Id == selectedCardFromSetA))
            {
                Console.Write($"\r\n{item.Name} vs ");
            }

            foreach (var item in _roles.Where(item => item.Id == selectedCardFromSetB))
            {
                Console.Write($"{item.Name} -> ");
            }
        }
    }
}
