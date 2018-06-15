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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MniVlasnici_Click(object sender, RoutedEventArgs e)
        {
            cntCtrl.Content = new frmVlasnik();
        }

        private void MniMehanicari_Click(object sender, RoutedEventArgs e)
        {
            cntCtrl.Content = new frmMehanicari();
        }

        private void MniVrsta_Click(object sender, RoutedEventArgs e)
        {
            cntCtrl.Content = new frmVrsta();
        }

        private void MniAuto_Click(object sender, RoutedEventArgs e)
        {
            cntCtrl.Content = new frmAuto();
        }

        private void MniServis_Click(object sender, RoutedEventArgs e)
        {
            cntCtrl.Content = new frmServis();
        }
    }

}
