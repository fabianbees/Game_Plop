using System;


namespace Game_Plop
{
	public class Avatar : Creature
	{
		public Avatar() {
            TextureId = "avatar";
			//texture = id+".png";
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
        /*
        public void MoveRight()
        {
            int x = this.getXvalue();
            if(x < 24 && x >= 0)
            {
                this.position[0]++;
            }
        }
        public void MoveLeft()
        {
            int x = this.getXvalue();
            if (x <= 24 && x > 0)
            {
                this.position[0]--;
            }
        }
        public void MoveUp()
        {
            int x = this.getYvalue();
            if (x <= 24 && x > 0)
            {
                this.position[1]--;
            }
        }
        public void MoveDown()
        {
            int x = this.getYvalue();
            if (x < 24 && x >= 0)
            {
                this.position[1]++;
            }
        }
        */

    }
}

