using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiles
{
    interface ITile
    {
    }

    abstract class Tile
    {
        protected byte index;

        protected Tile(byte i) { index = i; }
        protected Tile() { }
    }
}
