using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pointer
{
	public class Pointer : MonoBehaviour
	{
		static public Vector2 pos;
		
		void Update()
		{
			pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}
}