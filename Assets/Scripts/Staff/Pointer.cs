using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Pointer
{
	public class Pointer : MonoBehaviour
	{
		static public Vector2 pos;
		static public Vector2 lookpos;
		static private Vector2 looklocalpos = new Vector2(Screen.width / 2, Screen.height / 2);
		public float lookspeed = 2;
		public float lookResetTime = 0.3f;
		static private float looktime;
		
		void Update()
		{
			if (CrossPlatformInputManager.GetButtonDown("Look"))
				looktime = Time.time;

			if (CrossPlatformInputManager.GetButtonUp("Look"))
				if (Time.time - looktime < lookResetTime)
					looklocalpos = new Vector2(Screen.width / 2, Screen.height / 2);

			if (CrossPlatformInputManager.GetButton("Look"))
			{
				looklocalpos = new Vector2(
					Mathf.Lerp(looklocalpos.x, Input.mousePosition.x, Time.deltaTime * lookspeed),
					Mathf.Lerp(looklocalpos.y, Input.mousePosition.y, Time.deltaTime * lookspeed));
			}
			lookpos = Camera.main.ScreenToWorldPoint(looklocalpos);
			pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}
}