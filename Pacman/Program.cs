using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            var score = 5000;
            var lives = 3;
            var turnCount = 0;
            var successiveGhostCount = 0;
            var newPoints = 0;
            var newLifeCount = 0;
            var checkNewLife = 0;
            var gameEvent = "";

            Console.WriteLine($"{"Turn:",-5} {"Interaction:", -16} {"Points:",-8} {"Score:", -7} Lives:");
            string text = System.IO.File.ReadAllText(@"pacman-sequence.txt");
            string[] words = text.Split(',');

            foreach (var word in words)
            {
                turnCount++;

                Console.ForegroundColor = ConsoleColor.White;

                gameEvent = "";
                Thread.Sleep(75);
                newPoints = 0;

                switch (word.ToLower())
                {
                    case "dot":
                        newPoints = 10;
                        break;
                    case "invincibleghost":
                        Console.ForegroundColor = ConsoleColor.Red;
                        gameEvent = "-1 Life";
                        lives--;
                        break;
                    case "vulnerableghost":
                        newPoints = Convert.ToInt32(200 * Math.Pow(2, successiveGhostCount));
                        successiveGhostCount++;

                        break;
                    case "cherry":
                        newPoints = 100;
                        break;
                    case "strawberry":
                        newPoints = 300;
                        break;
                    case "orange":
                        newPoints = 500;
                        break;
                    case "apple":
                        newPoints = 700;
                        break;
                    case "melon":
                        newPoints = 1000;
                        break;
                    case "galaxian":
                        newPoints = 2000;
                        break;
                    case "bell":
                        newPoints = 3000;
                        break;
                    case "key":
                        newPoints = 5000;
                        break;
                }

                score += newPoints;

                checkNewLife = score / 10000;

                if (checkNewLife > newLifeCount)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    gameEvent = "+1 Life";
                    newLifeCount++;
                    lives++;
                }

                Console.WriteLine($"{turnCount, -5} {word, -16} +{newPoints, -7} {score, -7} {lives, -5} {gameEvent}");
                if (lives == 0)
                {
                    Console.WriteLine($"\nDead! Final score: {score}");
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}