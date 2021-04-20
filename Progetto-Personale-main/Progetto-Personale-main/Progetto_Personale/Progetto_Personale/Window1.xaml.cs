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
using System.Windows.Shapes;

namespace Progetto_Personale
{
    /// <summary>
    /// Logica di interazione per Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1(PersonaleAziendale personaleAziendale)
        {
            lbwindow.Items.Add(personaleAziendale.ToString());
            InitializeComponent();
        }

        private void btnNuovoInserimento_Click(object sender, RoutedEventArgs e)
        {
            lbwindow.Items.Clear();
        }
    }
}
