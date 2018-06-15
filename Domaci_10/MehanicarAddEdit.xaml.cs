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
 
    public partial class MehanicarAddEdit : Window, INotifyPropertyChanged
    {
        #region CurrentProfesor
        private Mehanicar _CurrentMehanicar = new Mehanicar();

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
        #endregion

        public event MehanicarHandler MehanicarCreated;

        public MehanicarAddEdit(Mehanicar vlasnik)
        {
            InitializeComponent();

            this.DataContext = this;

            CurrentMehanicar = vlasnik;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMehanicar.ID == 0)
                CurrentMehanicar.DodajMehanicara();
            else
                CurrentMehanicar.AzurirajMehanicara();

            MehanicarCreated(CurrentMehanicar);
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
