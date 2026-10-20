using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personage
{
    class Weapon
    {
        public string Name { get; set; }
        public int Lvl { get; set; }
        public int Damage { get; set; }
        public string TypeWeapon { get; set; }
        public string PathWeapon { get; set; }

        public Weapon(string name, int lvl, int damage, string typeWeapon, string pathWeapon)
        {
            this.Name = name;
            this.Lvl = lvl;
            this.Damage = damage;
            this.TypeWeapon = typeWeapon;
            this.PathWeapon = pathWeapon;
        }

        public Weapon()
        {
            this.Name = "Безымянный щит";
            this.Lvl = 1;
            this.Damage = 10;
            this.TypeWeapon = "Щит";
            this.PathWeapon = "shield.jpg";
        }
        public static Weapon operator +(Weapon first, Weapon second)
        {
            Weapon best;
            if (first.Lvl >= second.Lvl)
            {
                best = first;
            }
            else
            {
                best = second;
            }

            return new Weapon(
                best.Name + "+",
                best.Lvl + 1,
                first.Damage + second.Damage,
                best.TypeWeapon,
                best.PathWeapon
            );
        }

        public virtual string GerInfo()
        {
            return $"Имя: {Name}, Уровень оружия: {Lvl}, \nУрон: {Damage}, Тип оружия: {TypeWeapon}";
        }
    }
}
