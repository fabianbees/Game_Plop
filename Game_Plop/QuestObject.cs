using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Game_Plop
{
    class QuestObject
    {
        public String name;
        public string story_intro;
        public string story_outro;

        public QuestObject (XmlDocument doc, Form1 form)
        {
            name = doc.DocumentElement.SelectSingleNode("/quest/name").InnerText;
            story_intro = doc.DocumentElement.SelectSingleNode("/quest/story_intro").InnerText;
            story_outro = doc.DocumentElement.SelectSingleNode("/quest/story_outro").InnerText;

            form.textBox1.Text += "Quest: " + name + Environment.NewLine;
            form.textBox1.Text += story_intro + Environment.NewLine;
        }
    }
}
