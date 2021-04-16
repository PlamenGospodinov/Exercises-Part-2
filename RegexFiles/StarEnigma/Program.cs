using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            Regex reg = new Regex(@"[STARstar]");
            Regex planetReg = new Regex(@"[^@\-!:>]*\@(?<planet>[A-Za-z]+)[^@\-!:>]*\:[^@\-!:>](?<population>\d+)[^@\-!:>]*\![^@\-!:>]*(?<type>[AD])[^@\-!:>]*\!->[^@\-!:>]*(?<soldiers>\d+)[^@\-!:>]*");
            int numberOfLines = int.Parse(Console.ReadLine());
            
            for(int i = 0; i < numberOfLines; i++)
            {
                StringBuilder sb = new StringBuilder();
                string line = Console.ReadLine();
                MatchCollection matches = reg.Matches(line);
                int numberOfLetters = matches.Count;
                char[] arr = line.ToCharArray();
                foreach(char ch in arr)
                {
                    int charCode = (int)ch;
                    int newCode = charCode - numberOfLetters;
                    char newChar = (char)newCode;
                    sb.Append(newChar);
                }
                string decripted = sb.ToString();
                Match finalMatches = planetReg.Match(decripted);
                string planet = finalMatches.Groups["planet"].Value;
                int population = int.Parse(finalMatches.Groups["population"].Value);
                string attackType = finalMatches.Groups["type"].Value;
                int numberOfSoldiers = int.Parse(finalMatches.Groups["soldiers"].Value);
                if(attackType == "D")
                {
                    destroyedPlanets.Add(planet);
                }
                else if(attackType == "A")
                {
                    attackedPlanets.Add(planet);
                }
            }

            Console.WriteLine("Attacked planets: " + attackedPlanets.Count);
            foreach(string planet in attackedPlanets)
            {
                Console.WriteLine("-> " + planet);
            }
            Console.WriteLine("Destroyed planets: " + destroyedPlanets.Count);
            foreach(string planet in destroyedPlanets)
            {
                Console.WriteLine("-> " + planet);
            }
        }
    }
}
