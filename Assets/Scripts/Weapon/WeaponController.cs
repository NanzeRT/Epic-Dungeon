using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player;
using Pointer;

namespace Weapon
{
	public class WeaponController : MonoBehaviour
	{

		internal static WeaponController weapon;

		Transform tr;
		SpriteRenderer render;
		Animator anim;

		public float WDist = 0.1f;

		Transform PTr;

		void Start()
		{
			weapon = this;

			tr = GetComponent<Transform>();
			render = GetComponent<SpriteRenderer>();
			anim = GetComponent<Animator>();

			PTr = Player.Player.player.tr;
		}


		void Update()
		{
			SetPos();
		}

		void SetPos()
		{
			Vector2 localPPos = Pointer.Pointer.pos - (Vector2)PTr.position;
			float angle = Mathf.Atan2(localPPos.y, localPPos.x);
			Vector3 pos = new Vector3(Mathf.Cos(angle) * WDist, Mathf.Sin(angle) * WDist, tr.position.z);
			tr.position = pos + PTr.position;
			tr.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);

		}
	}
}