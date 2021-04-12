using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pointer;
using Player;

public class CamMove : MonoBehaviour {

	Transform tr;

	Vector3 pos;
	Vector2 mousePos;
	public float S = 0.5f;
	Transform PTr;

	void Start () {
		PTr = Player.Player.player.tr;
		tr = GetComponent<Transform>();
	}

	void Update () {
		mousePos = Pointer.Pointer.lookpos * S;
		pos.Set(Mathf.Lerp(tr.position.x, (PTr.position.x + mousePos.x) / (1f + S), Time.deltaTime * 7f),
		Mathf.Lerp(tr.position.y, (PTr.position.y + mousePos.y) / (1f + S), Time.deltaTime * 7f),
		tr.position.z);
		tr.position = pos;
	}
}
