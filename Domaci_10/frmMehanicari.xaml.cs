using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public delegate void MehanicarHandler(Mehanicar mehanicar);

    public partial class frmMehanicari : UserControl, INotifyPropertyChanged
    {
        private Mehanicar _CurrentMehanicar;

        public Mehanicar CurrentMehanicar
        {
            get { return _CurrentMehanicar; }
            set
            {
                if (_CurrentMehanicar != value)
                {
                    _CurrentMehanicar = value;
                    NotifyPropertyChanged("CurrentMehanicar");
                }
            }
        }
       
        private ObservableCollection<Mehanicar> _Mehanicari;

        public ObservableCollection<Mehanicar> Mehanicari
        {
            get { return _Mehanicari; }
            set
            {
                if (_Mehanicari != value)
                {
                    _Mehanicari = value;
                    NotifyPropertyChanged("Mehanicari");
                }
            }
        }

        public frmMehanicari()
        {
            InitializeComponent();
            this.DataContext = this;

            Mehanicari = new Mehanicar().UcitajMehanicare();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            MehanicarAddEdit frmMehanicarAddEdit = new MehanicarAddEdit(new Mehanicar());
            frmMehanicarAddEdit.MehanicarCreated += new MehanicarHandler(Refresh);
            frmMehanicarAddEdit.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            MehanicarAddEdit frmMehanicarAddEdit = new MehanicarAddEdit(CurrentMehanicar);
            frmMehanicarAddEdit.MehanicarCreated += new MehanicarHandler(Refresh);
            frmMehanicarAddEdit.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CurrentMehanicar.ObrisiMehanicara();
            Mehanicari = new Mehanicar().UcitajMehanicare();
        }

        private void Refresh(Mehanicar mehanicar)
        {
            Mehanicari = new Mehanicar().UcitajMehanicare();
        }

        private void btnDodajJSON_Click(object sender, RoutedEventArgs e)
        {
            new Mehanicar().UpisiJSON();
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged(String propertyName) // [CallerMemberName] 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        
    }

}
