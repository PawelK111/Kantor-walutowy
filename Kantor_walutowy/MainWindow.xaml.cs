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
using System.Net;
using System.IO;

namespace Kantor_walutowy
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListaWalut listaWalut;
        Polaczenie polaczenie;
        static string website = "http://nbp.pl/kursy/xml/lasta.xml";
        public MainWindow()
        {
            InitializeComponent();
            UpdateExchanges();
            DataTXT();
            try
            {
                if (CheckInternetCoonnection() == false) // create object from previously downloaded XML file on HDD
                    listaWalut = new ListaWalut();
                foreach (var aWaluta in listaWalut.waluta)
                {
                   Currency.Items.Add(aWaluta.Key + ". " + aWaluta.Value.Nazwa);
                   CurrencyTarget.Items.Add(aWaluta.Key + ". " + aWaluta.Value.Nazwa);
                }
            }
            catch
            {
                MessageBox.Show("Plik Waluty.xml nie istnieje!\nSprawdź swoje połączenie z internetem, a następnie spróbuj ponownie uruchomić aplikację!", "Plik nie istnieje!", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Waluta wal1 = null, wal2 = null;
                if (Currency.Text == "" || CurrencyTarget.Text == "")
                    MessageBox.Show("Podaj waluty!", "Brak waluty!", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    for (int i = 0; i < 35; i++)
                    {
                        if (Currency.Text.Contains(i.ToString()))
                            wal1 = listaWalut.waluta[i];
                        if (CurrencyTarget.Text.Contains(i.ToString()))
                            wal2 = listaWalut.waluta[i];
                    }
                    Calculator.Calculate(decimal.Parse(AmountBox.Text.Replace(',', '.')), wal1, wal2);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            string bufor = Currency.Text;
            Currency.Text = CurrencyTarget.Text;
            CurrencyTarget.Text = bufor;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateExchanges();
        } 

        private void UpdateExchanges()
        {
            DateTime date = DateTime.Now;
            CheckInternetCoonnection();
            if (CheckInternetCoonnection() == true)
            {
                polaczenie = new Polaczenie(website);
                listaWalut = new ListaWalut();
                UpdateOfExchangeLabel.Content = date.Date.ToString("MM/dd/yyyy");
            }
        }

        private bool CheckInternetCoonnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead(website))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        private void DataTXT() 
        {
            try
            {
                if (CheckInternetCoonnection() == true) // save the date of last update into TXT file
                    File.WriteAllText(@"DateOfLastUptade.txt", UpdateOfExchangeLabel.Content.ToString());
                else // read the date of last update from TXT file
                    UpdateOfExchangeLabel.Content = File.ReadAllText(@"DateOfLastUptade.txt");
            }
            catch
            {
                UpdateOfExchangeLabel.Content = "#ERROR!";
            }
        }
    }
}
