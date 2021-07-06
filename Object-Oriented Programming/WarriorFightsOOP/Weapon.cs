using System;
using System.Collections.Generic;
using System.Text;

namespace WarriorFightsOOP
{
    class Weapon
    {
        private const int ALLY_DAMAGE = 5;
        private const int ENEMY_DAMAGE = 4;

        private int damage;

        public int Damage
        {
            get
            {
                return damage;
            }

        }

        public Weapon(Type type)
        {
            if (type == Type.Ally)
            {
                damage = ALLY_DAMAGE;
            }
            else if (type == Type.Enemy)
            {
                damage = ENEMY_DAMAGE;
            }
        }
    }
}
