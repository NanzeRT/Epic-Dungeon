using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Maps;

namespace Levels
{
    interface ILevel
    {
        byte[,] Generate();
        IMap Map { get; }
    }

    abstract class Level
    {
        protected byte difficulty;

        protected readonly IMap map;
        public IMap Map => map;


        protected Level(IMap m, byte dif) { map = m; difficulty = dif; }

        public virtual byte[,] Generate()
        {
            return map.Generate();
        }
    }
}
