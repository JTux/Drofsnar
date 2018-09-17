using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pacman
{
    class ProgramUI
    {
        public void Start()
        {
            Settings settings = new Settings();

            Console.WriteLine($"{"Turn:",-5} {"Interaction:",-16} {"Points:",-8} {"Score:",-7} Lives:");
            string text = System.IO.File.ReadAllText(@"pacman-sequence.txt");
            string[] words = text.Split(',');

            foreach (var word in words)
            {
                settings.turnCount++;

                Console.ForegroundColor = ConsoleColor.White;

                settings.gameEvent = "";
                Thread.Sleep(75);
                settings.newPoints = 0;

                switch (word.ToLower())
                {
                    case "dot":
                        settings.newPoints = 10;
                        break;
                    case "invincibleghost":
                        Console.ForegroundColor = ConsoleColor.Red;
                        settings.gameEvent = "-1 Life";
                        settings.lives--;
                        break;
                    case "vulnerableghost":
                        settings.newPoints = Convert.ToInt32(200 * Math.Pow(2, settings.successiveGhostCount));
                        settings.successiveGhostCount++;
                        break;
                    case "cherry":
                        settings.newPoints = 100;
                        break;
                    case "strawberry":
                        settings.newPoints = 300;
                        break;
                    case "orange":
                        settings.newPoints = 500;
                        break;
                    case "apple":
                        settings.newPoints = 700;
                        break;
                    case "melon":
                        settings.newPoints = 1000;
                        break;
                    case "galaxian":
                        settings.newPoints = 2000;
                        break;
                    case "bell":
                        settings.newPoints = 3000;
                        break;
                    case "key":
                        settings.newPoints = 5000;
                        break;
                }

                settings.score += settings.newPoints;

                settings.checkNewLife = settings.score / 10000;

                if (settings.checkNewLife > settings.newLifeCount)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    settings.gameEvent = "+1 Life";
                    settings.newLifeCount++;
                    settings.lives++;
                }

                Console.WriteLine($"{settings.turnCount,-5} {word,-16} +{settings.newPoints,-7} {settings.score,-7} {settings.lives,-5} {settings.gameEvent}");
                if (settings.lives == 0)
                {
                    Console.WriteLine($"\nDead! Final score: {settings.score}");
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
