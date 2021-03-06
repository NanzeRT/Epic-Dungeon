﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Levels;


namespace LevelPacks
{
    internal interface ILevelPack
    {
        ILevel CurrentLevel { get; }
        void NextLevel();
        void NextLevel(int n);
    }

    internal abstract class LevelPack
    {
        protected ILevel currentLevel;
        public ILevel CurrentLevel => currentLevel;
        protected int NoLevel = 0; // Number of Level

        protected ILevel[] levels;


        protected LevelPack() { levels = Generate(); }

        protected virtual ILevel[] Generate()
        {
            return new ILevel[] { new TestLevel(0) };
        }

        public void NextLevel() { NextLevel(1); }
        public void NextLevel(int n)
        {
            if (NoLevel == levels.Length - 1) currentLevel = null;
            NoLevel += n;
            if (NoLevel > levels.Length - 1) NoLevel = levels.Length - 1;
            currentLevel = levels[NoLevel];
        }
    }
}
