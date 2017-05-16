using System;

namespace Game_Plop
{
	public class Wolf : Animal
	{
		public Wolf() {
			id = "Wolf";
			texture = id+".png";
		}

		public void wuff () {
			Console.WriteLine("Wuff! Wuff!");
		}
	}
}

