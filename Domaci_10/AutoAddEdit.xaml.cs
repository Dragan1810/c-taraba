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
using System.Windows.Shapes;

namespace Domaci_10
{
  
    public partial class AutoAddEdit : Window, INotifyPropertyChanged
    {
        #region MehanicariFromDB
        private ObservableCollection<Mehanicar> _MehanicariFromDB;

        public ObservableCollection<Mehanicar> MehanicariFromDB
        {
            get { return _MehanicariFromDB; }
            set
            {
                if (_MehanicariFromDB != value)
                {
                    _MehanicariFromDB = value;
                    NotifyPropertyChanged("MehanicariFromDB");
                }
            }
        }
        #endregion

        #region CurrentAuto
        private Auto _CurrentAuto;

        public Auto CurrentAuto
        {
            get { return _CurrentAuto; }
            set
            {
                if (_CurrentAuto != value)
                {
                    _CurrentAuto = value;
                    NotifyPropertyChanged("CurrentAuto");
                }
            }
        }
        #endregion

        public event AutoHandler AutoCreated;

        public AutoAddEdit(Auto auto)
        {
            InitializeComponent();

            this.DataContext = this;

            MehanicariFromDB = new Mehanicar().UcitajMehanicare();
            CurrentAuto = auto;
            CurrentAuto.Mehanicar = MehanicariFromDB.FirstOrDefault(x => x.ID == auto.Mehanicar?.ID);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentAuto.ID == 0)
                CurrentAuto.dodajAuto();
            else
                CurrentAuto.azurirajAuto();

            AutoCreated(CurrentAuto);
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
