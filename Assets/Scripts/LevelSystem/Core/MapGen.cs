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
        protected virtual int borderSize { get => 0; }

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

        protected abstract byte[,] borderTile { get ; }

        protected abstract byte[][,] startTiles1x1 { get; }
        protected abstract byte[][,] startTiles2x1 { get; }

        protected abstract byte[][,] endTiles1x1 { get; }
        protected abstract byte[][,] endTiles2x1 { get; }

        public virtual byte[,] Generate()
        {
            Random rand = new Random();
            return _generate(rand);
        }

        public virtual byte[,] Generate(int seed)
        {
            Random rand = new Random(seed);
            return _generate(rand);
        }

        protected virtual byte[,] _generate(Random rand)
        {
            byte[,] minimap = _generateMinimap(rand);
            //minimap = _setBorder(minimap);
            return _generateMap(rand, _setBorder(minimap));
        }
    
        protected virtual byte[,] _generateMinimap(Random rand)
        {
            int x = 0;
            int y = 0;
            byte[,] minimap = new byte[SizeY, SizeX];
            byte[,] map = new byte[SizeY * TSizeY, SizeX * TSizeX];
            int rowSpaces;
            int nextSpaces = SizeX;
            int randInt;

            // ToDo: add some staff
            for (y = 0; y < SizeY; y++)
            {
                rowSpaces = nextSpaces;
                nextSpaces = SizeX;
                randInt = rand.Next();
                for (x = 0; x < SizeX; x++)
                {
                    // 1 - 1x1, 2 - 1x2, 3 - 2x1, 4 - 2x2, 5 - border, 255 - shadow
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
            return minimap;
        }
    
        protected virtual byte[,] _setBorder(byte[,] minimap)
        {
            int _sizeY = SizeY + 2 * borderSize;
            int _sizeX = SizeX + 2 * borderSize;
            byte[,] new_minimap = new byte[_sizeY, _sizeX];

            if (borderSize > 0)
            {
                for (int i = 0; i < _sizeY; ++i)
                {
                   for (int j = 0; j < borderSize; ++j)
                    {
                        new_minimap[i, j] = 5;
                        new_minimap[i, _sizeX + j - borderSize] = 5;
                    }
                }
                for (int i = 0; i < _sizeX; ++i)
                {
                   for (int j = 0; j < borderSize; ++j)
                    {
                        new_minimap[j, i] = 5;
                        new_minimap[_sizeY + j - borderSize, i] = 5;
                    }
                }
            }

            for (int i = 0; i < SizeX; ++i)
            {
               for (int j = 0; j < SizeY; ++j)
                {
                    new_minimap[j + borderSize, i + borderSize] = minimap[j, i];
                }
            }
            return new_minimap;
        }

        protected virtual byte[,] _generateMap(Random rand, byte[,] minimap)
        {
            int _sizeY = minimap.GetLength(0);
            int _sizeX = minimap.GetLength(1);

            int x = 0;
            int y = 0;
            byte[,] map = new byte[_sizeY * TSizeY, _sizeX * TSizeX];

            byte[,] tile;

            for (y = 0; y < _sizeY; y++)
            {
                for (x = 0; x < _sizeX; x++)
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
                        case 5:
                            tile = borderTile;
                            break;
                    }

                    if (tile != null)
                    {
                        for (int i = 0; i < tile.GetLength(0); ++i)
                        {
                            for (int j = 0; j < tile.GetLength(1); ++j)
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
