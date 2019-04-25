using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Kantor_walutowy
{
    class Polaczenie
    {  
        protected XmlDocument doc = new XmlDocument();
        public Polaczenie() { }
        public Polaczenie(string url)
        {
            doc.Load(url);
            doc.Save("data.xml");
        }
    }
}
