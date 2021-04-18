using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Nether_Realms
{
    public class Demon 
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Regex hpRegex = new Regex(@"[^\d\-+.*\/]");
            Regex numRegex = new Regex(@"[+\-]{0,1}\d+\.?\d*");
            Regex amplifiersRegex = new Regex(@"[*\/]");
            string[] demons = Console.ReadLine().Split(new[] { ',',' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<Demon> demonsList = new List<Demon>();
            foreach(string demon in demons)
            {
                MatchCollection hpMatches = hpRegex.Matches(demon);
                int health = GetHealth(hpMatches);

                MatchCollection numbersMatches = numRegex.Matches(demon);
                double damage = GetBaseDamage(numbersMatches);

                MatchCollection ampMatches = amplifiersRegex.Matches(demon);
                foreach (Match match in ampMatches)
                {
                    if(match.Value == "*")
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }

                demonsList.Add(new Demon
                {
                    Name = demon,
                    Health = health,
                    Damage = damage
                });
               
            }

            List<Demon> sorted = demonsList.OrderBy(d => d.Name).ToList();

            foreach(Demon demon in sorted)
            {
                Console.WriteLine(demon.Name + "  -  " + demon.Health + " health, " + demon.Damage + " damage.");
            }
        }

        private static double GetBaseDamage(MatchCollection matchCollection)
        {
            double damage = 0;
            foreach (Match match in matchCollection)
            {
                damage += double.Parse(match.Value);
            }

            return damage;
        }

        private static int GetHealth(MatchCollection matchCollection)
        {
            int sum = 0;
            foreach(Match match in matchCollection)
            {
                sum += char.Parse(match.Value);
            }

            return sum;
        }
    }
}
