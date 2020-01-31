using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DowningActorIO
{
    class Program
    {
        private static readonly object userInput;

        static void Main(string[] args)
        {
            bool keepLooping = true;
            while (keepLooping)
            {
                string fName = @"D:\Spr2020_AU\CSC4100_SSAD\HW1\BestActors.txt";
                string[] rows = GetActorsFromFile(fName);

                List<Actor> actors = ParseIntoObject(rows);
                
                String inActor = GetActorFromUser(userInput);

                Console.WriteLine("User input{0}", inActor);

                if (inActor.ToLower().Equals("stop"))
                {
                    keepLooping = false;
                }
                else
                {
                    showThisActor(inActor, actors);
                }
            }
        }

        private static void showThisActor(string inActor, List<Actor> actors)
        {

            bool found = false;

            foreach (Actor a in actors)
            {
                if (a.aName.Equals(inActor))
                {
                    string oWin = null;
                    if (a.aWinner.Equals("0"))
                    {
                        oWin = "Loss";
                    }
                    else { oWin = "Win"; }

                    Console.WriteLine("\n Year:{0} Ceremony:{1} Winner:{2} Name:{3} Film:{4}", a.aYear,
                        a.aCeremony, oWin, a.aName, a.aFilm);

                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Sorry. This name is not found:", inActor);
            }

        }

        private static string GetActorFromUser(object userInput)
        {
            Console.WriteLine("What Actor Are You Interested In? Type STOP to quit -> ");
            userInput = Console.ReadLine();
            return userInput.ToString();
        }

        private static List<Actor> ParseIntoObject(string[] rows)
        {

            List<Actor> retActors = new List<Actor>();

            bool first = true;

            foreach (string s in rows)
            {
                if (first)
                {
                    first = false;
                    continue;
                }
                string[] toks = s.Split(',');


                retActors.Add(new Actor(toks[0], toks[1], toks[2],
                    toks[3], toks[4]));
            }
            return retActors;
        }

        private static string[] GetActorsFromFile(string fName)
        {
            String[] rows = new string[0];
            try
            {
                rows = File.ReadAllLines(fName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error on input{0}", fName);
                Console.WriteLine(e);
                Environment.Exit(1);
            }
            return rows;
        }

    }
}
