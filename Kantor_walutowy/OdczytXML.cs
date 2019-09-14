using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Kantor_walutowy
{
    class OdczytXML : Polaczenie
    {
        public XmlNodeList Nazwa { get; private set; }
        public XmlNodeList Przelicznik { get; private set; }
        public XmlNodeList Kod { get; private set; }
        public XmlNodeList Kurs { get; private set; }
        public OdczytXML()
        {
            doc.Load("Waluty.xml");
            Nazwa = doc.GetElementsByTagName("nazwa_waluty");
            Przelicznik = doc.GetElementsByTagName("przelicznik");
            Kod = doc.GetElementsByTagName("kod_waluty");
            Kurs = doc.GetElementsByTagName("kurs_sredni");
        }
    }
}
