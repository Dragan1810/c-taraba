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
    public delegate void VlasnikHandler(Vlasnik vlasnik);

    public partial class frmVlasnik : UserControl, INotifyPropertyChanged
    {
        private Vlasnik _CurrentVlasnik;

        public Vlasnik CurrentVlasnik
        {
            get { return _CurrentVlasnik; }
            set
            {
                if (_CurrentVlasnik != value)
                {
                    _CurrentVlasnik = value;
                    NotifyPropertyChanged("CurrentVlasnik");
                }
            }
        }

        #region Students
        private ObservableCollection<Vlasnik> _Vlasnici;

        public ObservableCollection<Vlasnik> Vlasnici
        {
            get { return _Vlasnici; }
            set
            {
                if (_Vlasnici != value)
                {
                    _Vlasnici = value;
                    NotifyPropertyChanged("Vlasnici");
                }
            }
        }
        #endregion


        public frmVlasnik()
        {
            InitializeComponent();

            this.DataContext = this;

            Vlasnici = new Vlasnik().ucitajVlasnike();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            VlasnikAddEdit frmVlasnikAddEdit = new VlasnikAddEdit(new Vlasnik());
            frmVlasnikAddEdit.VlasnikCreated += new VlasnikHandler(Refresh);
            frmVlasnikAddEdit.Show();
        }

        private void btnEditSpecification_Click(object sender, RoutedEventArgs e)
        {
            VlasnikAddEdit frmVlasnikAddEdit = new VlasnikAddEdit(CurrentVlasnik);
            frmVlasnikAddEdit.VlasnikCreated += new VlasnikHandler(Refresh);
            frmVlasnikAddEdit.Show();
        }

        private void Refresh(Vlasnik vlasnik)
        {
            Vlasnici = new Vlasnik().ucitajVlasnike();
        }

        private void btnDeleteSpecification_Click(object sender, RoutedEventArgs e)
        {
            CurrentVlasnik.obrisiVlasnika();
            Vlasnici = new Vlasnik().ucitajVlasnike();
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
