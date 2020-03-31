using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDef : MonoBehaviour {
	SpriteRenderer render;

	public int x, y;
	public byte type;
	public Builder bui;
	Sprite sprite;

	void Start () {
		render = GetComponent<SpriteRenderer>();

		defSprite();
	}
	
	void defSprite()
	{
		byte key = 0;

		key = (byte)(key + (y > 0 ? bui.tiles[y - 1, x] != type ? 128 : 0 : 128));									// верхняя грань
		key = (byte)(key + (x < bui.tiles.GetUpperBound(1) ? bui.tiles[y, x + 1] != type ? 64 : 0 : 64));			// правая грань
		key = (byte)(key + (y < bui.tiles.GetUpperBound(0) ? bui.tiles[y + 1, x] != type ? 32 : 0 : 32));			// нижняя грань
		key = (byte)(key + (x > 0 ? bui.tiles[y, x - 1] != type ? 16 : 0 : 16));									// левая грань

		key = (byte)(key + ((key & 128) == 0 && (key & 64) == 0 ? bui.tiles[y - 1, x + 1] != type ? 8 : 0 : 0));	// вп угол
		key = (byte)(key + ((key & 32) == 0 && (key & 64) == 0 ? bui.tiles[y + 1, x + 1] != type ? 4 : 0 : 0));	// нп угол
		key = (byte)(key + ((key & 32) == 0 && (key & 16) == 0 ? bui.tiles[y + 1, x - 1] != type ? 2 : 0 : 0));	// нл угол
		key = (byte)(key + ((key & 128) == 0 && (key & 16) == 0 ? bui.tiles[y - 1, x - 1] != type ? 1 : 0 : 0));	// вл угол

		sprite = Resources.LoadAll<Sprite>("Sprites\\Tiles\\tilesDD")[bui.SpriteKeys[key]];
		render.sprite = sprite;
	}
}
