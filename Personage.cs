using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personage
{

    class Personage
    {
        public string Name { get; set; }
        public int Lvl { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public Weapon Weapons { get; set; }
        public string PathChar { get; set; }
        public int LvlWeapon { get; set; }
        public int Damage { get; set; }


        public Personage(string name, int lvl, int strength, int dexterity, int intelligence, Weapon weapons, string pathChar, int lvlWeapon, int damage)
        {
            this.Name = name;
            this.Lvl = lvl;
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Intelligence = intelligence;
            this.Weapons = weapons;
            this.PathChar = pathChar;
            this.LvlWeapon = lvlWeapon;
            this.Damage = damage;
        }
        public Personage(Weapon weapons)
        {
            this.Name = "Безымянный персонаж";
            this.Lvl = 1;
            this.Strength = 1;
            this.Dexterity = 1;
            this.Intelligence = 10;
            this.Weapons = weapons;
            this.PathChar = "папич.jpg";
            this.LvlWeapon = weapons.Lvl;
            this.Damage = weapons.Damage;

        }

        public virtual string GetInfo()
        {
            return $"Имя: {Name}, Уровень: {Lvl}, Сила: {Strength}, Ловкость: {Dexterity}, Интеллект: {Intelligence}";
        }
    }
}




