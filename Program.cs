using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");

            Dictionary<string, TeamMember> TheSquad = new();
            
            while (true)
            {
                TeamMember TeamMember = new();
                Console.WriteLine("What is your team leader's name?");
                string givenName = Console.ReadLine();
                TeamMember.Name = givenName;
                if (givenName == "")
                {
                    break;
                }

                Console.WriteLine("What your team leader's skill level? Must be a positive integer no greater than 10");

                string LeaderSkillLevel = Console.ReadLine();
                int LeaderSkillInt = int.Parse(LeaderSkillLevel);
                while (LeaderSkillInt < 0 || LeaderSkillInt > 10)
                {
                    Console.WriteLine("Invalid input");
                    LeaderSkillLevel = Console.ReadLine();
                    LeaderSkillInt = int.Parse(LeaderSkillLevel);
                }
                TeamMember.SkillLevel = LeaderSkillInt;

                Console.WriteLine("What your team leader's courage factor? Must be a positive integer no greater than 10");
                string LeaderCourageFactor = Console.ReadLine();
                float LeaderCourageFloat = float.Parse(LeaderCourageFactor);
                while (LeaderCourageFloat < 0.0 || LeaderCourageFloat > 2.0)
                {
                    Console.WriteLine("Please try again");
                    LeaderCourageFactor = Console.ReadLine();
                    LeaderCourageFloat = float.Parse(LeaderCourageFactor);
                }
                TeamMember.CourageFactor = LeaderCourageFloat;
                TheSquad.Add(givenName, TeamMember);
                /* Console.WriteLine($"Your esteemed team leader {TeamMember} has a skill level of {TeamMember.SkillLevel} and a courage factor of {TeamMember.CourageFactor}"); */

            }
            int bankDifficulty = 100;
            
            //Creating a random number fo the heist luck value
            Random r = new Random();
            int luckValue = r.Next(-10, 11);
            Console.WriteLine(luckValue);
            bankDifficulty +=luckValue;

            //
            int teamSkillLevel = 0;
            foreach (KeyValuePair<string, TeamMember> member in TheSquad)
            {
                teamSkillLevel += member.Value.SkillLevel;
            }

            Console.WriteLine($"Your team skill level is {teamSkillLevel}. The bank's difficulty is {bankDifficulty}");

            if (teamSkillLevel >= bankDifficulty)
            {
                Console.WriteLine("Success!");
            }
            else{
                Console.WriteLine("You got caught immediately.");
            }
        }
    }
}
