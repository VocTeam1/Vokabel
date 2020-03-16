using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Vokabel
{
    class Dictionary
    {
       private Dictionary<string, string> dictionary = new Dictionary<string, string>();
        public Dictionary()
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(Properties.Resources.Vokabelliste);
            XmlNodeList xnList = xml.SelectNodes("/root/row");
            foreach (XmlNode xn in xnList)
            {
                string englisch = xn["Fremdsprache"].InnerText;
                string deutsch = xn["Deutsch"].InnerText;
                try
                {
                    dictionary.Add(englisch, deutsch);
                }
                catch (Exception)
                {
                }
            }
        }
        public CurrentQuestions GetNext()
        {
            Random rand = new Random();
            CurrentQuestions currentQuestions = new CurrentQuestions();
            currentQuestions.answers = new string[4];
            currentQuestions.question = dictionary.ElementAt(rand.Next(0, dictionary.Count)).Key;
            currentQuestions.correctID = rand.Next(0, 3);
            dictionary.TryGetValue(currentQuestions.question, out currentQuestions.answers[currentQuestions.correctID]);
            for (int i = 0; i < currentQuestions.answers.Length; i++)
            {
                if (currentQuestions.answers[i] == null)
                {
                    currentQuestions.answers[i] = dictionary.ElementAt(rand.Next(0, dictionary.Count)).Value;
                }
            }
            return currentQuestions;
        }
        public bool IsCorrectAnswer(string englisch, string german)
        {
            string correct;
            dictionary.TryGetValue(englisch, out correct);
            if (correct == german)
            {
                return true;
            }
            return false;
        }
        public string CorrectAnswer(string englisch)
        {
            string correct;
            dictionary.TryGetValue(englisch, out correct);
            return correct;
        }
    }

    struct CurrentQuestions
    {
        public int correctID;
        public string question;
        public string[] answers;
    }
}
