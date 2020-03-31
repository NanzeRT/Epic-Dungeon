using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weapon
{
	internal interface IUseable : IItem
	{
		void Use();
	}

	internal interface IWeapon : IItem
	{
		void Hit();
	}

	internal interface IItem
	{
		void GetTxt();
	}

	internal abstract class Item
	{
		public virtual void GetTxt()
		{
			
		}

		public override string ToString()
		{
			return "Предмет";
		}
	}

	internal abstract class Weapon : Item
	{
		public virtual void Hit()
		{
			
		}
		public override string ToString()
		{
			return "Оружие";
		}
	}

	internal abstract class Gun : Weapon
	{
		public override void Hit()
		{
			
		}
	}

	internal abstract class Sword : Weapon
	{
		public override void Hit()
		{
			
		}
	}
}
