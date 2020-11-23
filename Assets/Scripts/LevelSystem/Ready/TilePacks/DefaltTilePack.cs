using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiles;

namespace TilePacks
{
    class DefaltTilePack : ITilePack
    {
        public string packName => "Defalt";

        public ITile GetTile(byte index)
        {
            // 0 - air (tiles don't spawn)
            if (index < 128)
            {
                return new CommonTile(index);
            }
            if (index < 254)
            {
                return new EntityTile(index);
            }
            if (index == 254)
            {
                return new StartTile();
            }
            return new EndTile();
        }
    }
}
