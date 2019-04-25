using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kantor_walutowy
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListaWalut listaWalut;
        Calculator calculator = new Calculator();
        
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Polaczenie polaczenie = new Polaczenie("http://nbp.pl/kursy/xml/lasta.xml");
            }
            catch
            {
                MessageBox.Show("Brak połączenia z internetem! Aplikacja spróbuje odczytać ostatni plik XML zapisany na tym komputerze!","Błąd połączenia",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            try
            { 
                listaWalut = new ListaWalut();
                listaWalut.UtworzListe();
                int lp = 1;
                foreach (Waluta aWaluta in listaWalut.waluta)
                {
                    Currency.Items.Add(lp + ". " + aWaluta.Nazwa);
                    CurrencyTarget.Items.Add(lp++ + ". " + aWaluta.Nazwa);
                }
            }
            catch
            {
                MessageBox.Show("Plik data.xml nie istnieje!\nSprawdź swoje połączenie z internetem, a następnie spróbuj ponownie uruchomić aplikację!", "Plik nie istnieje!", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            double kurs_waluty1 = 0, kurs_waluty2 = 0;
            string kod1 = "", kod2 = "";
            int przelicznik1 = 0, przelicznik2 = 0;
            try
            {
                if (Currency.Text == "" || CurrencyTarget.Text == "")
                {
                    MessageBox.Show("Podaj waluty!", "Brak waluty!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    for (int i = 1; i < 36; i++)
                    {
                        if (Currency.Text.Contains(i.ToString()))
                        {
                            kod1 = listaWalut.waluta[i - 1].Kod_waluty;
                            kurs_waluty1 = listaWalut.waluta[i - 1].Kurs;
                            przelicznik1 = listaWalut.waluta[i - 1].Przelicznik;
                        }
                        if (CurrencyTarget.Text.Contains(i.ToString()))
                        {
                            kod2 = listaWalut.waluta[i - 1].Kod_waluty;
                            kurs_waluty2 = listaWalut.waluta[i - 1].Kurs;
                            przelicznik2 = listaWalut.waluta[i - 1].Przelicznik;
                        }
                    }
                    calculator.Calculate(double.Parse(AmountBox.Text), kurs_waluty1, kurs_waluty2, przelicznik1, przelicznik2, kod1, kod2);
                }
            }
            catch
            {
                    MessageBox.Show("Próbujesz podać nieprawidłowe dane!\nJeżeli chcesz podać wartość z przecinkiem, użyj przecinka zamiast kropki. ", "Błąd wyliczenia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string bufor;
            bufor = Currency.Text;
            Currency.Text = CurrencyTarget.Text;
            CurrencyTarget.Text = bufor;
        }

        void ReadingXML()
        {

        }
    }
}
