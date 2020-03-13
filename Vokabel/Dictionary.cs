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
       private Dictionary<string, string> dataDictionary = new Dictionary<string, string>();
        public Dictionary()
        {
            
            //XDocument doc = XDocument.Parse(Properties.Resources.Vokabelliste);

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(Properties.Resources.Vokabelliste); // suppose that myXmlString contains "<Names>...</Names>"

            XmlNodeList xnList = xml.SelectNodes("/root/row");
            foreach (XmlNode xn in xnList)
            {
                string englisch = xn["Fremdsprache"].InnerText;
                string deutsch = xn["Deutsch"].InnerText;
                try
                {
                    dataDictionary.Add(englisch, deutsch);
                }
                catch (Exception)
                {
                }
                
            }
        }
        public Werte GetNext()
        {
            Random rand = new Random();
            Werte werte = new Werte();
            werte.antworten = new string[4];
            werte.frage = dataDictionary.ElementAt(rand.Next(0, dataDictionary.Count)).Key;
            werte.correctI = rand.Next(0, 3);
            dataDictionary.TryGetValue(werte.frage, out werte.antworten[werte.correctI]);
          //  int tmpRnd = rand.Next(0, 3);
            //  !werte.antworten[tmpRnd] == null

            for (int i = 0; i < werte.antworten.Length; i++)
            {
                if (werte.antworten[i] == null)
                {
                    werte.antworten[i] = dataDictionary.ElementAt(rand.Next(0, dataDictionary.Count)).Value;
                }
            }
            return werte;

        }
        public bool IsCorrectAnswer(string englisch, string deutsch)
        {
            string correct;
            dataDictionary.TryGetValue(englisch, out correct);
            if (correct == deutsch)
            {
                return true;
            }
            return false;
        }
        public string CorrectAnswer(string englisch)
        {
            string correct;
            dataDictionary.TryGetValue(englisch, out correct);
            return correct;
        }
    }

    struct Werte
    {
        public int correctI;
        public string frage;
        public string[] antworten;

    }
}
