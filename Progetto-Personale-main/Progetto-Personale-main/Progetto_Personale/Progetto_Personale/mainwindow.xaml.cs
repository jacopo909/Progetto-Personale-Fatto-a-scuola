using System;
using System.Collections.Generic;
using System.IO;
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

namespace Progetto_Personale
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class Mainwindow : mainwindow
    {
        private string[] tipologia = new string[] { "Aziendale", "SubFornitore", "Fornitore", "Consulente" };
        private HashSet<string> CodiciEsistenti = new HashSet<string>();
        public Mainwindow()
        {
            InitializeComponent();
            Tipologia();
            LeggiFile();
            txtCodiceFiscale.Focus();
        }

        private void btnInserisciPersona_Click(object sender, RoutedEventArgs e)
        {
            switch (cmbTipologia.SelectedIndex)
            {
                case 0:
                    if(txtNome.Text != "" && txtNome.Text != "" && txtCodiceFiscale.Text != "" && cmbTipologia.SelectedIndex != -1)
                    {
                        if (CodiciEsistenti.Contains(txtCodiceFiscale.Text))
                        {
                            PersonaleAziendale p = new PersonaleAziendale(txtCodiceFiscale.Text, txtNome.Text, txtCognome.Text, tipologia[cmbTipologia.SelectedIndex]);
                            Aziendale FormAziendale = new Aziendale(p);
                            FormAziendale.ShowDialog();
                            CodiciEsistenti.Add(p.CodiceFiscale);
                            StreamWriter stremScrittura = new StreamWriter(Costanti.DIRECTORY + Costanti.FILE);
                            stremScrittura.WriteLine($"{txtNome.Text} {txtCognome.Text} {txtCodiceFiscale.Text};");
                        }
                        else
                        {
                            MessageBox.Show("ATTENZIONE il codice fiscale non può esser duplicato, rinserisci le informazioni", "ERRORE", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ATTENZIONE non tutti i campi sono stati compilati", "ATTENZIONE", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    break;
                default:
                    MessageBox.Show("Area ancora in lavorazione!", "INFORMAZIONE", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
            }
        }



        private void btnPulisci_Click(object sender, RoutedEventArgs e)
        {
            txtCodiceFiscale.Text = "";
            txtCognome.Text = "";
            txtNome.Text = "";
            cmbTipologia.SelectedIndex = -1;
        }

        private void btnEsci_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LeggiFile()
        {
            string line;
            StreamReader stremLettura = new StreamReader(Costanti.DIRECTORY + Costanti.FILE);

            do
            {
                line = stremLettura.ReadLine();
                if (line != null)
                {
                    string[] personale = line.Split(';');
                    CodiciEsistenti.Add(personale[0]);
                }
            } while (line != null);
            stremLettura.Close();
        }

        private void Tipologia()
        {
            foreach (var tipo in tipologia)
            {
                cmbTipologia.Items.Add(tipo);
            }
        }
    }
}
