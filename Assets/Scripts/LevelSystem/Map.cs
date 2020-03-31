﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TilePacks;

namespace Maps
{
    interface IMap
    {
        byte[,] Generate();
    }

    abstract class Map
    {
        //public DefaltTilePack;

        protected abstract int SizeX { get; }
        protected abstract int SizeY { get; }

        protected abstract int TSizeX { get; }
        protected abstract int TSizeY { get; }

        protected abstract byte[,,] tiles1x1 { get; }
        protected abstract byte[,,] tiles2x1 { get; }
        protected abstract byte[,,] tiles1x2 { get; }
        protected abstract byte[,,] tiles2x2 { get; }

        protected abstract byte[,,] sideTiles1x1 { get; }
        protected abstract byte[,,] sideTiles2x1 { get; }
        protected abstract byte[,,] sideTiles1x2 { get; }
        protected abstract byte[,,] sideTiles2x2 { get; }

        protected abstract byte[,,] startTiles1x1 { get; }
        protected abstract byte[,,] startTiles2x1 { get; }

        protected abstract byte[,,] endTiles1x1 { get; }
        protected abstract byte[,,] endTiles2x1 { get; }

        public virtual byte[,] Generate()
        {
            int x = 0;
            int y = 0;
            bool[,] isTaken = new bool[SizeX, SizeY];



            return new byte[0,0];
        }
    }
}