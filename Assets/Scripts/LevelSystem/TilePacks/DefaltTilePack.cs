using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiles;

namespace TilePacks
{
    class DefaltTilePack : ITilePack
    {
        public string packName = "Defalt";

        ITile DefineType(byte index)
        {
            return new CommonTile();
        }


    }
}
