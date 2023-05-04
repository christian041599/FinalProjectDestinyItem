using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny_Items
{
    public class Character
    {
        private string _name;
        private string _arktype;
        private List<Weapon> _weapon;
        private List<Armor> _armor;

        public Character() { }

        public Character(string name, string arktype, List<Weapon> weapon, List<Armor> armor) 
        {
            _name = name;
            _arktype = arktype;
            _weapon = weapon;
            _armor = armor;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public string Arktype { get { return _arktype; } set { _arktype = value; } }  
        public List<Weapon> Weapon { get { return _weapon; } set { _weapon = value; } }
        public List<Armor> Armor { get { return _armor; } set { _armor = value; } }
    }
}
