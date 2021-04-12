using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapGens
{
    class TestMap : MapGen, IMapGen
    {
        protected override int SizeX => 16;
        protected override int SizeY => 8;
        protected override int borderSize => 1;

        protected override int TSizeX => 4;
        protected override int TSizeY => 4;

        protected override byte[][,] tiles1x1 => new byte[][,] { new byte[,] {
                                                                {1,1,1,1},
                                                                {1,0,0,1},
                                                                {0,0,0,0},
                                                                {1,1,1,1}
                                                            },
                                                            new byte[,] {
                                                                {1,1,1,1},
                                                                {1,1,1,1},
                                                                {0,0,0,0},
                                                                {1,0,0,1}
                                                            },
                                                            };
        protected override byte[][,] tiles2x1 => new byte[][,] { new byte[,] {
                                                                {1,1,1,1,1,1,1,1},
                                                                {1,0,0,0,0,0,0,1},
                                                                {0,0,0,0,0,0,0,0},
                                                                {1,1,1,1,1,1,1,1}
                                                            },
                                                            new byte[,] {
                                                                {1,1,1,1,1,1,1,1},
                                                                {1,0,0,0,1,1,1,1},
                                                                {0,0,1,0,0,0,0,0},
                                                                {1,1,1,1,1,1,1,1}
                                                            },
                                                            };
        protected override byte[][,] tiles1x2 => new byte[][,] { new byte[,] {
                                                                {1,1,1,1},
                                                                {1,0,0,1},
                                                                {0,0,0,0},
                                                                {1,0,0,1},
                                                                {1,0,0,1},
                                                                {1,0,1,1},
                                                                {0,0,0,0},
                                                                {1,1,1,1}
                                                            },
                                                            new byte[,] {
                                                                {1,1,1,1},
                                                                {1,0,0,1},
                                                                {0,0,0,0},
                                                                {1,0,0,1},
                                                                {0,0,1,1},
                                                                {0,1,1,1},
                                                                {0,0,0,0},
                                                                {1,1,1,1}
                                                            },
                                                            };
        protected override byte[][,] tiles2x2 => new byte[][,] { new byte[,] {
                                                                {1,1,1,1,1,1,1,1},
                                                                {1,0,0,0,0,0,0,1},
                                                                {0,0,0,0,0,0,0,0},
                                                                {1,1,0,0,0,0,1,1},
                                                                {1,0,0,0,0,0,0,1},
                                                                {1,0,0,1,1,0,0,1},
                                                                {0,0,0,0,0,0,0,0},
                                                                {1,1,1,1,1,1,1,1}
                                                            },
                                                            new byte[,] {
                                                                {1,1,1,1,1,1,1,1},
                                                                {1,0,0,0,0,0,0,1},
                                                                {0,0,1,0,0,1,0,0},
                                                                {1,1,1,0,1,1,1,1},
                                                                {1,1,1,0,0,1,1,1},
                                                                {1,1,1,1,0,0,0,1},
                                                                {0,0,0,0,0,1,0,0},
                                                                {1,1,1,1,1,1,1,1}
                                                            },
                                                            };

        protected override byte[][,] sideTiles1x1 => new byte[][,] { };
        protected override byte[][,] sideTiles2x1 => new byte[][,] { };
        protected override byte[][,] sideTiles1x2 => new byte[][,] { };
        protected override byte[][,] sideTiles2x2 => new byte[][,] { };

        protected override byte[,] borderTile => new byte[,] {
                                                                {1,1,1,1},
                                                                {1,1,1,1},
                                                                {1,1,1,1},
                                                                {1,1,1,1}
                                                             };

        protected override byte[][,] startTiles1x1 => new byte[][,] { };
        protected override byte[][,] startTiles2x1 => new byte[][,] { };

        protected override byte[][,] endTiles1x1 => new byte[][,] { };
        protected override byte[][,] endTiles2x1 => new byte[][,] { };

    }
}
