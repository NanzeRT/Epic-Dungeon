using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MapGens;

public class Builder : MonoBehaviour
{

    public byte[,] tiles = new MapGens.TestMap().Generate();
    TileDef[,] tilesScr;

    public GameObject tilePref;
    public Dictionary<byte, byte> SpriteKeys = new Dictionary<byte, byte>
    {
        {0,0},{1,1},{2,2},{3,3},{4,4},{5,5},{6,6},{7,7},{8,8},{9,9},{10,10},
        {11,11},{12,12},{13,13},{14,14},{15,15},{16,16},{20,17},{24,18},
        {28,19},{32,20},{33,21},{40,22},{41,23},{48,24},{56,25},{64,26},
        {65,27},{66,28},{67,29},{80,30},{96,31},{97,32},{112,33},{128,34},
        {130,35},{132,36},{134,37},{144,38},{148,39},{160,40},{176,41},{192,42},
        {194,43},{208,44},{224,45},{240,46}
    };


    void Start()
    {
        tilesScr = new TileDef[tiles.GetUpperBound(0) + 1, tiles.GetUpperBound(1) + 1];
        for (int y = 0; y <= tiles.GetUpperBound(0); y++)
        {
            for (int x = 0; x <= tiles.GetUpperBound(1); x++)
            {
                if (tiles[y, x] != 0)
                {
                    tilesScr[y, x] = Instantiate(tilePref, new Vector3(x, -y, 0f), new Quaternion(), this.transform).GetComponent<TileDef>();
                    tilesScr[y, x].type = tiles[y, x];
                    tilesScr[y, x].x = x;
                    tilesScr[y, x].y = y;
                    tilesScr[y, x].bui = this;
                }
            }
        }
        CompositeCollider2D composit = this.GetComponent<CompositeCollider2D>();
        composit.GenerateGeometry();
    }

    void Update()
    {

    }
}

