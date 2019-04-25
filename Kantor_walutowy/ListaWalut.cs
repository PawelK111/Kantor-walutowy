using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Kantor_walutowy
{
    class ListaWalut
    {
        OdczytXML odczytXML = new OdczytXML();
        public List<Waluta> waluta = new List<Waluta>();
        public void UtworzListe()
        {
            for (int i = 0; i < 35; i++)
            {
                waluta.Add(new Waluta(odczytXML.Nazwa[i].InnerXml, 
                    int.Parse(odczytXML.Przelicznik[i].InnerXml), 
                    odczytXML.Kod[i].InnerXml, 
                    double.Parse(odczytXML.Kurs[i].InnerXml)));
            }
        }  
    }
}
