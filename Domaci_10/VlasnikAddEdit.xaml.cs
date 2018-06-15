using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Domaci_10
{
   
    public partial class VlasnikAddEdit : Window, INotifyPropertyChanged
    {
        #region CurrentVlasnik
        private Vlasnik _CurrentVlasnik = new Vlasnik();

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
        #endregion

        public event VlasnikHandler VlasnikCreated;


        public VlasnikAddEdit(Vlasnik vlasnik)
        {
            InitializeComponent();

            this.DataContext = this;

            CurrentVlasnik = vlasnik;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentVlasnik.ID == 0)
                CurrentVlasnik.dodajVlasnika();
            else
                CurrentVlasnik.azurirajVlasnika();

            VlasnikCreated(CurrentVlasnik);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
