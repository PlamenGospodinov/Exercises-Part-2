using System;
using System.Collections.Generic;
using System.Text;

namespace WarriorFightsOOP
{
    public class Warrior
    {
        private const int ALLY_START_HEALTH = 28;
        private const int ENEMY_START_HEALTH = 28;

        private readonly Type type;

        private string name;
        private int health;
        private bool isAlive;

        private Weapon weapon;
        private Armor armor;

        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
        }

        public Warrior(string name,Type type)
        {
            this.name = name;
            this.type = type;
            isAlive = true;

            switch (type)
            {
                case Type.Ally:
                    weapon = new Weapon(type);
                    armor = new Armor(type);
                    health = ALLY_START_HEALTH;
                    break;
                case Type.Enemy:
                    weapon = new Weapon(type);
                    armor = new Armor(type);
                    health = ENEMY_START_HEALTH;
                    break;
                default:
                    break;
            }
        }

        public void Attack(Warrior enemyWarrior)
        {
            int damage = weapon.Damage / enemyWarrior.armor.ArmorPoints;
            enemyWarrior.health -= damage;
            AttackResult(enemyWarrior, damage);
        }

        public void AttackResult(Warrior enemyWarrior,int damage)
        {
            if(enemyWarrior.health <= 0)
            {
                enemyWarrior.isAlive = false;
                Additional.ColorWriteLine($"{enemyWarrior.name} is dead!", ConsoleColor.DarkRed);
                Additional.ColorWriteLine($"{name} is victorious!", ConsoleColor.DarkMagenta);
            }
            else
            {
                Console.WriteLine($"{name} attacked {enemyWarrior.name} for {damage} damage. \n" +
                    $"{name} current health: {health}\n" +
                    $"{ enemyWarrior.name} current health: { enemyWarrior.health}\n" +
                    new string('-', 40) + "\n");
            }
        }
    }
}
