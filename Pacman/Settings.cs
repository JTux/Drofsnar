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
        public int lives = 3;
        public int turnCount = 0;
        public int successiveGhostCount = 0;
        public int newPoints = 0;
        public int newLifeCount = 0;
        public int checkNewLife = 0;
        public string gameEvent = "";
    }
}
