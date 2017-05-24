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

        public QuestObject(XmlDocument doc, Form1 form, bool create)
        {
            name = doc.DocumentElement.SelectSingleNode("/quest/name").InnerText;
            story_intro = doc.DocumentElement.SelectSingleNode("/quest/story_intro").InnerText;
            story_outro = doc.DocumentElement.SelectSingleNode("/quest/story_outro").InnerText;

            if (create)
            { 
                form.treeViewQuests.Nodes.Add("Quest: " + name);
                form.treeViewQuests.Nodes.Add(story_intro);
            }
        }

        public void didSomething (Form1 form)
        {
            form.treeViewQuests.Nodes.Add(story_outro);
        }
    }
}
