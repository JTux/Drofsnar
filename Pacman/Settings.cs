using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Settings
    {
        public int score = 5000;
        public int lives = 5;
        public int turnCount, successiveGhostCount, newPoints, newLifeCount, checkNewLife;
        public string gameEvent;
        public ConsoleColor mainTextColor = ConsoleColor.White;
        public ConsoleColor badEventTextColor = ConsoleColor.Red;
        public ConsoleColor goodEventTextColor = ConsoleColor.Green;

        public Dictionary<string, int> ItemValues { get; set; }
    }
}
