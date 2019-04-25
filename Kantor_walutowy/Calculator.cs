using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kantor_walutowy
{
    class Calculator
    {
        public void Calculate(double ilosc, double kurs_waluty1, double kurs_waluty2, int przelicznik1, int przelicznik2, string nazwa1, string nazwa2)
        {
            double wynik = (Math.Round(ilosc,2) * kurs_waluty1) / przelicznik1;
            double zlotowki = wynik;
            wynik = (wynik / kurs_waluty2) * przelicznik2;


            MessageBox.Show("Posiadasz: " + Math.Round(ilosc,2) + " " + nazwa1 + "\nW przeliczeniu na PLN: " + Math.Round(zlotowki,2) + "\nOtrzymasz: " + Math.Round(wynik,2) + " " + nazwa2, 
                "Przeliczanie zakończone",
                MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}
