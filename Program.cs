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

            Console.WriteLine("Please choose a difficulty level for your mission (1-100)");
            string difficultyLevel = Console.ReadLine();
            int bankDifficulty = int.Parse(difficultyLevel);
            

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

            Console.WriteLine("How many times would you like to run this simulation? (1-5)");
            string trialRuns = Console.ReadLine();
            int trialRunInt = int.Parse(trialRuns);


            int teamSkillLevel = 0;
            int failedRuns = 0;
            int successRuns = 0;

            foreach (KeyValuePair<string, TeamMember> member in TheSquad)
            {
                teamSkillLevel += member.Value.SkillLevel;
            }

            for (int i = 0; i < trialRunInt; i++)
            {
                //Creating a random number fo the heist luck value
                Random r = new Random();
                int luckValue = r.Next(-10, 11);
                Console.WriteLine(luckValue);
                bankDifficulty += luckValue;

                Console.WriteLine($"Your team skill level is {teamSkillLevel}. The bank's difficulty is {bankDifficulty}");

                if (teamSkillLevel >= bankDifficulty)
                {
                    Console.WriteLine("Success!");
                    successRuns += 1;
                }
                else
                {
                    Console.WriteLine("You got caught immediately.");
                    failedRuns += 1;
                }

                bankDifficulty += int.Parse(difficultyLevel);
            }
        }
    }
}
