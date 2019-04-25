using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kantor_walutowy
{
    class Waluta
    {
        public string Nazwa { get; private set; }
        public int Przelicznik { get; private set; }
        public string Kod_waluty { get; private set; }
        public double Kurs { get; private set; }

        public Waluta(string nazwa, int przelicznik, string kod_waluty, double kurs)
        {
            Nazwa = nazwa;
            Przelicznik = przelicznik;
            Kod_waluty = kod_waluty;
            Kurs = kurs;
        }
    }
}
