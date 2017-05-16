using System;


namespace Game_Plop
{
	public class Avatar : Creature
	{
		public Avatar() {
			id = "Avatar";
			texture = id+".png";
		}

		int[] inventory = new int[100];
		int[] weapons = new int[10];


		public void walk() {
			//TODO
		}

		public void heal() {
			//TODO
		}

		public void attack() {
			//TODO
		}

		public void defend() {
			//TODO
		}

		public void pick() {
			//TODO
		}
	}
}

