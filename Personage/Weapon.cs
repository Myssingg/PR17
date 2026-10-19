using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personage
{
    class Weapon
    {
        public string name;
        public int lvl;
        public int damage;
        public string typeWeapon;
        public string pathWeapon;

        public Weapon(string name, int lvl, int damage, string  typeWeapon, string pathWeapon)
        {
            this.name = name;
            this.lvl = lvl;
            this.damage = damage;
            this.typeWeapon = typeWeapon;
            this.pathWeapon = pathWeapon;
        }
        
        public Weapon()
        {
            this.name = "Безымянный щит";
            this.lvl = 1;
            this.damage = 10;
            this.typeWeapon = "Щит";
            this.pathWeapon = "shield.jpg";
        }
        public static Weapon operator +(Weapon i1, Weapon i2)
        {
            string nameOfBest;
            int lvlOfBest;

            if (i1.lvl > i2.lvl)
            {
               nameOfBest = i1.name;
               lvlOfBest = i1.lvl + 1;
            }
            else if(i1.lvl < i2.lvl)
            {
                nameOfBest = i2.name;
                lvlOfBest = i2.lvl + 1;
            }
            else
            {
                nameOfBest = i1.name;
                lvlOfBest = i1.lvl + 1;
            }
            return new Weapon(nameOfBest + "+", lvlOfBest++, i1.damage + i2.damage, i1.typeWeapon, i1.pathWeapon);
        }

        public virtual string GerInfo()
        {
            return $"Имя: {name}, Уровень оружия: {lvl}, \nУрон: {damage}, Тип оружия: {typeWeapon}";
        }
    }
}
