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
        public Dictionary<int, Waluta> waluta = new Dictionary<int, Waluta>();
        public ListaWalut()
        {
            for (int i = 0; i < 35; i++)
            {
                waluta.Add(i+1, new Waluta(odczytXML.Nazwa[i].InnerXml,
                    int.Parse(odczytXML.Przelicznik[i].InnerXml),
                    odczytXML.Kod[i].InnerXml,
                    decimal.Parse(odczytXML.Kurs[i].InnerXml)));
            }
        }
    }
}
