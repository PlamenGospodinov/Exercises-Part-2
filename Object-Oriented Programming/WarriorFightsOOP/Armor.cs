using System;
using System.Collections.Generic;
using System.Text;

namespace WarriorFightsOOP
{
    public class Armor
    {
        private const int ALLY_ARMOR = 5;
        private const int ENEMY_ARMOR = 5;

        private int armorPoints;

        public int ArmorPoints
        {
            get
            {
                return armorPoints;
            }
            
        }

        public Armor(Type type)
        {
            if(type == Type.Ally)
            {
                armorPoints = ALLY_ARMOR;
            }
            else if(type == Type.Enemy)
            {
                armorPoints = ENEMY_ARMOR;
            }
        }
    }
}
