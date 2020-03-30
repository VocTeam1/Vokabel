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
        public CurrentQuestion GetNext()
        {
            Random rand = new Random();
            CurrentQuestion currentQuestions = new CurrentQuestion();
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
    }

    struct CurrentQuestion
    {
        public int correctID; // Index von richtige Antwort in array "answers"
        public string question; // Die Frage
        public string[] answers; // Array von antworten.
    }
}
