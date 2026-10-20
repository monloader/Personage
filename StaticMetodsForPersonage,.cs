using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personage
{
    static class StaticMetodsForPersonage
    {
        public static Weapon Weapons { get; set; }
        public static int Strength { get; set; }
        public static int Dexterity { get; set; }
        public static int Intelligence { get; set; }
        public static int Lvl { get; set; }
        
        private static int CalculatePower(Personage personage)
        {
            int statsSum = personage.Strength + personage.Dexterity + personage.Intelligence;
            int statsPower = statsSum * personage.Lvl;
            int weaponPower = personage.Weapons.Lvl * personage.Weapons.Damage;
            int totalPower = statsPower + weaponPower;

            return totalPower > int.MaxValue ? int.MaxValue : totalPower;
        }
        
        static public string Power(Personage personage)
        {

            if (personage == null || personage.Weapons == null)
            {
                return "Неизвестно";
            }

            long statsSum = (long)personage.Strength + personage.Dexterity + personage.Intelligence;
            long statsPower = statsSum * personage.Lvl;
            long weaponPower = (long)personage.Weapons.Lvl * personage.Weapons.Damage;
            long totalPower = statsPower + weaponPower;

            int power = (int)totalPower;
            if (totalPower > int.MaxValue)
            {
                power = int.MaxValue;
            }

            string type = personage.Weapons.TypeWeapon;

            if (type == "Меч")
            {
                if (power <= 50) return "Просто мечник";
                if (power <= 100) return "Хороший мечник";
                if (power <= 200) return "Отличный мечник";
                if (power <= 400) return "Великолепный мечник";
                return "А точно мечник? Может это Гатс?";
            }
            else if (type == "Клинки")
            {
                if (power <= 50) return "Кадет";
                if (power <= 100) return "Рядовой";
                if (power <= 200) return "Ефрейтор";
                if (power <= 400) return "Младший капрал";
                return "Капрал";
            }
            else if (type == "Щит")
            {
                if (power <= 50) return "Просто щитоносец";
                if (power <= 100) return "Хороший щитоносец";
                if (power <= 200) return "Отличный щитоносец";
                if (power <= 400) return "Великолепный щитоносец";
                return "А точно щитоносец? Может это Львиный Глаз?";
            }
            else if (type == "Лук")
            {
                if (power <= 50) return "Просто лучник";
                if (power <= 100) return "Хороший лучник";
                if (power <= 200) return "Отличный лучник";
                if (power <= 400) return "Великолепный лучник";
                return "А точно лучник? Может это Лиралей?";
            }

            return "Неизвестно";
        }

        static public string StrongPersonage(List<Personage> personage)
        {
            if (personage == null || personage.Count == 0)
            {
                return "Список персонажей пустой";
            }

            int maxPower = 0;
            int strongestIndex = 0;

            for (int i = 0; i < personage.Count; i++)
            {
                int currentPower = CalculatePower(personage[i]);

                if (currentPower > maxPower)
                {
                    maxPower = currentPower;
                    strongestIndex = i;
                }
            }

            return $"Самый сильный персонаж: {personage[strongestIndex].GetInfo()}";

        }
    }
}
