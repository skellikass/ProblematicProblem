using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static Random rng = new Random();
        //static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \n" +
                "Would you like to generate a random activity? yes/no: ");
            bool cont = Console.ReadLine().ToLower() == "yes" ? true : false;
            if (cont)
            {
                Console.WriteLine("Great!");
            }
            else return;
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            string userNameInitialCap = textInfo.ToTitleCase(userName);
            Console.WriteLine();
            Console.Write("What is your age? ");
            bool isValid = int.TryParse(Console.ReadLine(), out int userAge);
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? yes/no: ");
            bool seeList = Console.ReadLine().ToLower() == "yes" ? true : false;
            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.WriteLine($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                bool addToList = Console.ReadLine().ToLower() == "yes" ? true : false;
                Console.WriteLine();
                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    string userAdditionInitialCap = textInfo.ToTitleCase(userAddition);
                    activities.Add(userAdditionInitialCap);
                    Console.WriteLine("Awesome! Here is the updated list with your addition:");
                    foreach (string activity in activities)
                    {
                        Console.WriteLine($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.Write("Would you like to add more? yes/no: ");
                    addToList = Console.ReadLine().ToLower() == "yes" ? true : false;
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(50);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(50);
                }
                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    //Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}.");
                    //Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }
                Console.Write($"Ah, got it! {userNameInitialCap}, your random activity is: {randomActivity}! \n" +
                    $"Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                cont = Console.ReadLine().ToLower() == "redo" ? true : false;
            }
        }
    }
}