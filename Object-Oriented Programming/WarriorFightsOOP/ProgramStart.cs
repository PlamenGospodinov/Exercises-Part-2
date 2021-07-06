using System;
using System.Threading;

namespace WarriorFightsOOP
{
    class ProgramStart
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            Warrior ally = new Warrior("Pesho", Type.Ally);
            Warrior enemy = new Warrior("Miro", Type.Enemy);

            while(ally.IsAlive && enemy.IsAlive)
            {
                if(rand.Next(0,10) < 5)
                {
                    ally.Attack(enemy);
                }
                else
                {
                    enemy.Attack(ally);
                }

                Thread.Sleep(500);
            }
        }
    }
}
