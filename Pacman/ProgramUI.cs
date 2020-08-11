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
        private string[] _words;
        private Settings _set;

        public void Start()
        {
            LoadFile();
            Run();
            Console.WriteLine("Cool thanks bye!");
            Console.ReadLine();
        }

        private void Run()
        {
            do
            {
                Startup();
                SetStartingLives();
                Play();
            }
            while (GetKeepRunning());
        }

        private bool GetKeepRunning()
        {
            Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                Console.WriteLine("Would you like to play again?");

                switch (Console.ReadLine().ToLower())
                {
                    case "yes":
                    case "y":
                    case "sure":
                    case "yup":
                    case "of course":
                    case "duh":
                        return true;
                    case "no":
                    case "n":
                    case "nah":
                    case "nope":
                    case "no thank you":
                    case "no thanks":
                    case "lol no":
                        return false;
                    default:
                        Console.WriteLine("I'm sorry I didn't quite understand that. Please try again.");
                        break;
                }
            }
        }

        private void SetStartingLives()
        {
            int startingLives;
            do
            {
                Console.Clear();
                Console.Write("Enter starting lives: ");
            }
            while (!int.TryParse(Console.ReadLine(), out startingLives));

            Console.Clear();
            _set.lives = startingLives;
        }

        private void Play()
        {
            Console.WriteLine($"{"Turn:",-5} {"Interaction:",-22} {"Points:",-8} {"Score:",-7} Lives:");
            foreach (var word in _words)
            {
                PrepNewItem();
                Thread.Sleep(75);

                GetPointsFromItem(word);

                CheckNextNewLife();

                Console.WriteLine($"{_set.turnCount,-5} {word,-22} +{_set.newPoints,-7} {_set.score,-7} {_set.lives,-5} {_set.gameEvent}");

                if (_set.lives == 0)
                {
                    Console.WriteLine($"\nDead! Final score: {_set.score}");
                    break;
                }
            }
        }

        private void PrepNewItem()
        {
            _set.turnCount++;
            _set.gameEvent = "";
            _set.newPoints = 0;
            Console.ForegroundColor = _set.mainTextColor;
        }

        private void CheckNextNewLife()
        {
            _set.checkNewLife = _set.score / 10000;

            if (_set.checkNewLife > _set.newLifeCount)
            {
                Console.ForegroundColor = _set.goodEventTextColor;
                _set.gameEvent = "+1 Life";
                _set.newLifeCount++;
                _set.lives++;
            }
        }

        private void GetPointsFromItem(string word)
        {
            switch (word.ToLower())
            {
                case "invincibleghost":
                case "invinciblebirdhunter":
                    Console.ForegroundColor = _set.badEventTextColor;
                    _set.gameEvent = "-1 Life";
                    _set.lives--;
                    break;
                case "vulnerableghost":
                case "vulnerablebirdhunter":
                    _set.newPoints = Convert.ToInt32(200 * Math.Pow(2, _set.successiveGhostCount));
                    _set.successiveGhostCount++;
                    break;
                default:
                    _set.newPoints = _set.ItemValues[word.ToLower()];
                    break;
            }
            _set.score += _set.newPoints;
        }

        private void LoadFile()
        {
            string text = System.IO.File.ReadAllText(@"..\game-sequence.txt");
            //string text = System.IO.File.ReadAllText(@"..\pacman-sequence.txt");
            string[] words = text.Split(',');
            _words = words;
        }

        private void Startup()
        {
            _set = new Settings
            {
                ItemValues = new Dictionary<string, int>
                {
                    { "dot", 10 },
                    { "cherry", 100 },
                    { "strawberry", 300 },
                    { "orange", 500 },
                    { "apple", 700 },
                    { "melon", 1000 },
                    { "galaxian", 2000 },
                    { "bell", 3000 },
                    { "key", 5000 },
                    { "bird", 10 },
                    { "crestedibis", 100 },
                    { "greatkiskudee", 300 },
                    { "redcrossbill", 500 },
                    { "red-neckedphalarope", 700 },
                    { "eveninggrosbeak", 1000 },
                    { "greaterprairiechicken", 2000 },
                    { "icelandgull", 3000 },
                    { "orange-belliedparrot", 5000 },
                }
            };
        }
    }
}