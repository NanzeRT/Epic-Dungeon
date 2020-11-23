using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MapGens;

namespace Levels
{
    interface ILevel
    {
        byte[,] Generate();
        IMapGen Gen { get; }
    }

    abstract class Level
    {
        protected byte difficulty;

        protected readonly IMapGen map;
        public IMapGen Gen => map;


        protected Level(IMapGen m, byte dif) { map = m; difficulty = dif; }

        public virtual byte[,] Generate()
        {
            return map.Generate();
        }
    }
}
