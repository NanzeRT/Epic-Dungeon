using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiles;

namespace TilePacks
{
    interface ITilePack
    {
        string packName { get; }
        ITile GetTile(byte index);
    }
}
