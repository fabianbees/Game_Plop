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
			Console.WriteLine(id + " received this message: {0}", e.Message);
		}
	}
}

