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
            dataDictionary.TryGetValue(werte.frage, out werte.antworten[rand.Next(0, 3)]);
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
    }

    struct Werte
    {
        public string frage;
        public string[] antworten;

    }
}
