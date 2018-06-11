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
    /// <summary>
    /// Interaction logic for PredmetAddEdit.xaml
    /// </summary>
    public partial class PredmetAddEdit : Window, INotifyPropertyChanged
    {
        #region ProfesorsFromDB
        private ObservableCollection<Profesor> _ProfesorsFromDB;

        public ObservableCollection<Profesor> ProfesorsFromDB
        {
            get { return _ProfesorsFromDB; }
            set
            {
                if (_ProfesorsFromDB != value)
                {
                    _ProfesorsFromDB = value;
                    NotifyPropertyChanged("ProfesorsFromDB");
                }
            }
        }
        #endregion

        #region CurrentPredmet
        private Predmet _CurrentPredmet;

        public Predmet CurrentPredmet
        {
            get { return _CurrentPredmet; }
            set
            {
                if (_CurrentPredmet != value)
                {
                    _CurrentPredmet = value;
                    NotifyPropertyChanged("CurrentPredmet");
                }
            }
        }
        #endregion

        public event PredmetHandler PredmetCreated;

        public PredmetAddEdit(Predmet predmet)
        {
            InitializeComponent();

            this.DataContext = this;

            ProfesorsFromDB = new Profesor().ucitajProfesore();
            CurrentPredmet = predmet;
            CurrentPredmet.Profesor = ProfesorsFromDB.FirstOrDefault(x => x.ID == predmet.Profesor?.ID);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPredmet.ID == 0)
                CurrentPredmet.dodajPredmet();
            else
                CurrentPredmet.azurirajPredmet();

            PredmetCreated(CurrentPredmet);
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
