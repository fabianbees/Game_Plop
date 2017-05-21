using System;

namespace Game_Plop
{
	public class Quest
	{
		private string id;

		public Quest (string ID, Creature pub)
		{
			id = ID;
			// Subscribe to the event using C# 2.0 syntax
			pub.RaiseCustomEvent += HandleCustomEvent;
		}

		void HandleCustomEvent(object sender, CustomEventArgs e)
		{
            //Form1.textBox1.Text += id + " received this message:" + e.Message + Environment.NewLine;
        }
	}
}

