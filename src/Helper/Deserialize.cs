using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CardGame.Config;

namespace CardGame.Helper
{
    public class Deserialize
    {
        public List<Role> Roles()
        {
            List<Role> roles;

            using (var reader = new StreamReader(@"..\..\..\Config\Roles.xml"))
            {
                XmlSerializer deserializer = new(typeof(List<Role>),
                    new XmlRootAttribute("Roles"));
                roles = (List<Role>)deserializer.Deserialize(reader)!;
            }
            return roles;
        }

        public List<Ability> Ability()
        {
            List<Ability> abilities;

            using (var reader = new StreamReader(@"..\..\..\Config\Abilities.xml"))
            {
                XmlSerializer deserializer = new(typeof(List<Ability>),
                    new XmlRootAttribute("Abilities"));
                abilities = (List<Ability>)deserializer.Deserialize(reader)!;
            }
            return abilities;
        }

        public List<SpecialAbility> SpecialAbility()
        {
            List<SpecialAbility> specialAbilities;

            using (var reader = new StreamReader(@"..\..\..\Config\SpecialAbilities.xml"))
            {
                XmlSerializer deserializer = new(typeof(List<SpecialAbility>),
                    new XmlRootAttribute("SpecialAbilities"));
                specialAbilities = (List<SpecialAbility>)deserializer.Deserialize(reader)!;
            }
            return specialAbilities;
        }

        public List<CardDetails> CardSetA()
        {
            List<CardDetails> cardSetA;

            using (var reader = new StreamReader(@"..\..\..\Config\CardSetA.xml"))
            {
                XmlSerializer deserializer = new(typeof(List<CardDetails>),
                    new XmlRootAttribute("CardSetA"));
                cardSetA = (List<CardDetails>)deserializer.Deserialize(reader)!;
            }
            return cardSetA;
        }

        public List<CardDetails> CardSetB()
        {
            List<CardDetails> cardSetB;

            using (var reader = new StreamReader(@"..\..\..\Config\CardSetB.xml"))
            {
                XmlSerializer deserializer = new(typeof(List<CardDetails>),
                    new XmlRootAttribute("CardSetB"));
                cardSetB = (List<CardDetails>)deserializer.Deserialize(reader)!;
            }
            return cardSetB;
        }
    }
}
