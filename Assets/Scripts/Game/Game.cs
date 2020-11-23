using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LevelPacks;

namespace Game
{
    static class Game
    {
        public delegate void NoReturn();

        static public ILevelPack levelPack = new TestLevelPack();

        static private event NoReturn _onNewLevel;
        static public event NoReturn OnNewLevel
        {
            add { _onNewLevel += value; }
            remove { _onNewLevel -= value; }
        }

        static void NextLevel(int n)
        {
            levelPack.NextLevel(n);

            // Do some logic

            // builder.Generate(levelPack.CurrentLevel);

            _onNewLevel();
        }

    }
}
