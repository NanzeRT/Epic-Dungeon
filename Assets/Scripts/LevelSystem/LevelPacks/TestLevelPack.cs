using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Levels;

namespace LevelPacks
{
    class TestLevelPack : LevelPack, ILevelPack
    {
        protected override ILevel[] Generate()
        {
            return new ILevel[] { new TestLevel(1), new TestLevel(2), new TestLevel(3) };
        }
    }
}
