using System;
using System.Xml;

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

        public void LoadQuest (Form1 form)
        {
            XmlDocument questXML = new XmlDocument();
            //HardCoded not needed!!!
            //We have to use LoadXml() instead of Load()
            //questXML.Load("C:\\Users\\fabia\\Documents\\Visual Studio 2017\\Projects\\Game_Plop\\Game_Plop\\testquest.xml");
            questXML.LoadXml(Properties.Resources.quest);

            QuestObject quest = new QuestObject(questXML, form, true);
        }
	}
}

