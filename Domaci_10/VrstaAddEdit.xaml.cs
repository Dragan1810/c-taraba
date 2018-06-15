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
    public partial class VrstaAddEdit : Window, INotifyPropertyChanged
    {
        #region CurrentVrsta
        private Vrsta _CurrentVrsta = new Vrsta();

        public Vrsta CurrentVrsta
        {
            get { return _CurrentVrsta; }
            set
            {
                if (_CurrentVrsta != value)
                {
                    _CurrentVrsta = value;
                    NotifyPropertyChanged("CurrentVrsta");
                }
            }
        }
        #endregion

        public event VrstaHandler VrstaCreated;


        public VrstaAddEdit(Vrsta vrsta)
        {
            InitializeComponent();

            this.DataContext = this;

            CurrentVrsta = vrsta;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentVrsta.ID == 0)
                CurrentVrsta.dodajVrstu();
            else
                CurrentVrsta.azurirajVrstu();

            VrstaCreated(CurrentVrsta);
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
