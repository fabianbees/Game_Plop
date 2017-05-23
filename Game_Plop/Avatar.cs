using System;
using System.Collections.Generic;

namespace Game_Plop
{
	public class Avatar : Creature
	{
		public Avatar() {
            TextureId = "avatar";
			//texture = id+".png";
		}

        // int[] inventory = new int[100];
        public List<string> inventory = new List<string>();
        int[] weapons = new int[10];


		public void walk() {
			//moved to Form1
		}

		public void heal(Form1 form) {
           form.updateHealth(getHealth() + 10);
		}

		public void attack() {
			//TODO
		}

		public void defend() {
			//TODO
		}

		public void pick(int itemID) {
            //moved to Form1
		}

    }
}

