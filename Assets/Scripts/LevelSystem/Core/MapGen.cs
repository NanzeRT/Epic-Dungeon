using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TilePacks;

namespace MapGens
{
    interface IMapGen
    {
        byte[,] Generate();
        ITilePack Pack { get; }
    }

    abstract class MapGen : IMapGen
    {
        protected ITilePack pack = new DefaltTilePack();
        public ITilePack Pack => pack;

        protected abstract int SizeX { get; }
        protected abstract int SizeY { get; }

        protected abstract int TSizeX { get; }
        protected abstract int TSizeY { get; }

        protected abstract byte[][,] tiles1x1 { get; }
        protected abstract byte[][,] tiles2x1 { get; }
        protected abstract byte[][,] tiles1x2 { get; }
        protected abstract byte[][,] tiles2x2 { get; }

        protected abstract byte[][,] sideTiles1x1 { get; }
        protected abstract byte[][,] sideTiles2x1 { get; }
        protected abstract byte[][,] sideTiles1x2 { get; }
        protected abstract byte[][,] sideTiles2x2 { get; }

        protected abstract byte[,] borderTile { get; }

        protected abstract byte[][,] startTiles1x1 { get; }
        protected abstract byte[][,] startTiles2x1 { get; }

        protected abstract byte[][,] endTiles1x1 { get; }
        protected abstract byte[][,] endTiles2x1 { get; }

        public virtual byte[,] Generate()
        {
            int x = 0;
            int y = 0;
            byte[,] minimap = new byte[SizeY, SizeX];
            byte[,] map = new byte[SizeY * TSizeY, SizeX * TSizeX];
            int rowSpaces;
            int nextSpaces = SizeX;
            Random rand = new Random();
            int randInt;

            // ToDo: add some staff
            for (y = 0; y < SizeY; y++)
            {
                rowSpaces = nextSpaces;
                nextSpaces = SizeX;
                randInt = rand.Next();
                for (x = 0; x < SizeX; x++)
                {
                    // 1 - 1x1, 2 - 1x2, 3 - 2x1, 4 - 2x2, 255 - shadow
                    if (minimap[y, x] == 0)
                    {
                        if (randInt % rowSpaces < 1 && y != SizeY - 1)
                        {
                            nextSpaces--;
                            rowSpaces += 50;
                            minimap[y, x] = 2;
                            minimap[y+1, x] = 255;
                        }
                        else
                        {
                            minimap[y, x] = 1;
                        }
                        rowSpaces--;
                    }
                }

                for (x = SizeX-1; x > 0; x--)
                {
                    if (minimap[y, x] == 1  && minimap[y, x - 1] != 255) {
                        if (randInt % (x*5) < x*2)
                        {
                            if (minimap[y, x - 1] == 2)
                            {
                                minimap[y, x-1] = 4;
                                minimap[y+1, x-1] = 255;
                                minimap[y+1, x] = 255;
                                minimap[y, x] = 255;
                                nextSpaces--;
                            }
                            else
                            {
                                minimap[y, x-1] = 3;
                                minimap[y, x] = 255;
                            }
                        }
                    }
                }
            }

            // next
            byte[,] tile;

            for (y = 0; y < SizeY; y++)
            {
                for (x = 0; x < SizeX; x++)
                {
                    tile = null;
                    switch (minimap[y, x])
                    {
                        case 1:
                            tile = tiles1x1[rand.Next(tiles1x1.Length)];
                            break;
                        case 2:
                            tile = tiles1x2[rand.Next(tiles1x2.Length)];
                            break;
                        case 3:
                            tile = tiles2x1[rand.Next(tiles2x1.Length)];
                            break;
                        case 4:
                            tile = tiles2x2[rand.Next(tiles2x2.Length)];
                            break;
                    }

                    if (tile != null)
                    {
                        for (int i = 0; i < tile.GetLength(0); i++)
                        {
                            for (int j = 0; j < tile.GetLength(1); j++)
                            {
                                map[y * TSizeY + i, x * TSizeX + j] = tile[i, j];
                            }
                        }
                    }
                }
            }

            return map;
        }
    }
}
