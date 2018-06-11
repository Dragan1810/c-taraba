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

namespace Domaci_10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mniStudenti_Click(object sender, RoutedEventArgs e)
        {
            cntCtrl.Content = new frmStudent();
        }

        private void mniProfesori_Click(object sender, RoutedEventArgs e)
        {
            cntCtrl.Content = new frmProfesor();
        }

        private void mniRokovi_Click(object sender, RoutedEventArgs e)
        {
            cntCtrl.Content = new frmRok();
        }

        private void mniPredmeti_Click(object sender, RoutedEventArgs e)
        {
            cntCtrl.Content = new frmPredmet();
        }

        private void mniPrijave_Click(object sender, RoutedEventArgs e)
        {
            cntCtrl.Content = new frmPrijava();
        }
    }

}
