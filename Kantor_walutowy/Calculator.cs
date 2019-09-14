using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;

namespace Kantor_walutowy
{
    static class Calculator
    {
        static decimal wynik, zlotowki;

        public static void Calculate(decimal ilosc, Waluta waluta1, Waluta waluta2)
        {
            wynik = ilosc * waluta1.Kurs / waluta1.Przelicznik;
            zlotowki = wynik / 10000;
            wynik = (wynik / waluta2.Kurs) * waluta2.Przelicznik;
            MessageBox.Show($"Posiadasz: {Math.Round(ilosc, 2)} {waluta1.Kod_waluty}\n" +
                $"W pezeliczeniu na PLN: {Math.Round(zlotowki,2)}\n" +
                $"Otrzymasz: {Math.Round(wynik, 2)} {waluta2.Kod_waluty}",
               "Przeliczanie zakończone",
               MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
