using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny_Items
{
    public class Weapon
    {
        public Weapon() { }
        public Weapon(string name, string weaponType, string rarity) 
        { 
            _name = name;
            _type = weaponType;
            _rarity = rarity;
        }

        private string _name;
        private string _type;
        private string _rarity;

        public string Name { get { return _name; } set { _name = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public string Rarity { get { return _rarity; } set { _rarity = value; } }
    }
}
