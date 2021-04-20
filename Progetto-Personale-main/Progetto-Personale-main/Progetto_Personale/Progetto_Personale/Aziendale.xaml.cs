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
using System.Windows.Shapes;

namespace Progetto_Personale
{
    /// <summary>
    /// Logica di interazione per Window2.xaml
    /// </summary>
    public partial class Aziendale : Window
    {
        private string[] qualifiche = new string[] { "Dirigente", "Quadro", "Amministrativo", "Operaio" };
        private PersonaleAziendale p;
        public Aziendale(PersonaleAziendale personaleaziendale) // passo le variabili del personale aziendale tramite il costruttore, che serviranno per i parametri dichiarati nel form
        {
            p = personaleaziendale;
            Qualifica();
            InitializeComponent();
        }

        private void Inserisci_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1(p);
            window1.ShowDialog();
            p.Qualifica = qualifiche[cmbQualifica.SelectedIndex];
            p.Area = txtArea.Text;
            txtArea.Text = "";
        }

        private void btnMostraFIle_Click(object sender, RoutedEventArgs e)
        {
            StreamReader Read = new StreamReader(Costanti.DIRECTORY + Costanti.FILE);
            Read.ReadLine();
            lb1.Items.Add(p.ToString());
        }

        private void Qualifica()
        {
            foreach(string q in qualifiche)
            {
                cmbQualifica.Items.Add(q);
            }
        }

        private void btnNuovoInserimento_Click(object sender, RoutedEventArgs e)
        {
            txtArea.Text = "";
            lb1.Items.Clear();
        }
    }
}
