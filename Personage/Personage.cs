using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personage
{

    class Personage
    {
        public string name;
        public int lvl;
        public int strenght;
        public int dexterity;
        public int intellegence;
        public Weapon weapons;
        public string pathChar;
        public int lvlWeapon;
        public int damage;

        public Personage(string name, int lvl, int strenght, int dexterity, int intellegence, Weapon weapons, string pathChar, int lvlWeapon, int damage)
        {
            this.name = name;
            this.lvl = lvl;
            this.strenght = strenght;
            this.dexterity = dexterity;
            this.intellegence = intellegence;
            this.weapons = weapons;
            this.pathChar = pathChar;
            this.lvlWeapon = lvlWeapon;
            this.damage = damage;
        }
        public Personage(Weapon weapons)
        {
            this.name = "Безымянный персонаж";
            this.lvl = 1;
            this.strenght = 1;
            this.dexterity = 1;
            this.intellegence = 10;
            this.weapons = weapons;
            this.pathChar = "папич.jpg";                     
            this.lvlWeapon = weapons.lvl;
            this.damage = weapons.damage;

        }
        
        public virtual string GetInfo()
        {
            return $"Имя: {name}, Уровень: {lvl}, Сила: {strenght}, Ловкость: {dexterity}, Интеллект: {intellegence}";
        }
    }
}




