using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Weapon;

namespace Player
{
	public class Player : MonoBehaviour
	{
		static public Player player;

		public Transform tr;

		// Equipment
		private IWeapon weapon;

		void Awake()
		{
			player = this;

			tr = GetComponent<Transform>();
		}



	}
}
