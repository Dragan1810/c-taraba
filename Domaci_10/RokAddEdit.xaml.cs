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
    /// <summary>
    /// Interaction logic for RokAddEdit.xaml
    /// </summary>
    public partial class RokAddEdit : Window, INotifyPropertyChanged
    {
        #region CurrentRok
        private Rok _CurrentRok = new Rok();

        public Rok CurrentRok
        {
            get { return _CurrentRok; }
            set
            {
                if (_CurrentRok != value)
                {
                    _CurrentRok = value;
                    NotifyPropertyChanged("CurrentRok");
                }
            }
        }
        #endregion

        public event RokHandler RokCreated;


        public RokAddEdit(Rok Rok)
        {
            InitializeComponent();

            this.DataContext = this;

            CurrentRok = Rok;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentRok.ID == 0)
                CurrentRok.dodajRok();
            else
                CurrentRok.azurirajRok();

            RokCreated(CurrentRok);
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
