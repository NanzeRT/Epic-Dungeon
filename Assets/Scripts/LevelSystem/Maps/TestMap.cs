using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maps
{
    class TestMap : Map, IMap
    {
        protected override int SizeX => 5;
        protected override int SizeY => 5;

        protected override int TSizeX => 16;
        protected override int TSizeY => 16;

        protected override byte[,,] tiles1x1 => new byte[,,] { };
        protected override byte[,,] tiles2x1 => new byte[,,] { };
        protected override byte[,,] tiles1x2 => new byte[,,] { };
        protected override byte[,,] tiles2x2 => new byte[,,] { };

        protected override byte[,,] sideTiles1x1 => new byte[,,] { };
        protected override byte[,,] sideTiles2x1 => new byte[,,] { };
        protected override byte[,,] sideTiles1x2 => new byte[,,] { };
        protected override byte[,,] sideTiles2x2 => new byte[,,] { };

        protected override byte[,] borderTile => new byte[,] { };

        protected override byte[,,] startTiles1x1 => new byte[,,] { };
        protected override byte[,,] startTiles2x1 => new byte[,,] { };

        protected override byte[,,] endTiles1x1 => new byte[,,] { };
        protected override byte[,,] endTiles2x1 => new byte[,,] { };

    }
}
