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
    /// Interaction logic for PrijavaAddEdit.xaml
    /// </summary>
    public partial class PrijavaAddEdit : Window, INotifyPropertyChanged
    {
        #region StudentsFromDB
        private ObservableCollection<Student> _StudentsFromDB;

        public ObservableCollection<Student> StudentsFromDB
        {
            get { return _StudentsFromDB; }
            set
            {
                if (_StudentsFromDB != value)
                {
                    _StudentsFromDB = value;
                    NotifyPropertyChanged("StudentsFromDB");
                }
            }
        }
        #endregion

        #region RoksFromDB
        private ObservableCollection<Rok> _RoksFromDB;

        public ObservableCollection<Rok> RoksFromDB
        {
            get { return _RoksFromDB; }
            set
            {
                if (_RoksFromDB != value)
                {
                    _RoksFromDB = value;
                    NotifyPropertyChanged("RoksFromDB");
                }
            }
        }
        #endregion

        #region Predmets
        private ObservableCollection<Predmet> _Predmets;

        public ObservableCollection<Predmet> Predmets
        {
            get { return _Predmets; }
            set
            {
                if (_Predmets != value)
                {
                    _Predmets = value;
                    NotifyPropertyChanged("Predmets");
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

        #region CurrentPrijava
        private Prijava _CurrentPrijava;

        public Prijava CurrentPrijava
        {
            get { return _CurrentPrijava; }
            set
            {
                if (_CurrentPrijava != value)
                {
                    _CurrentPrijava = value;
                    NotifyPropertyChanged("CurrentPrijava");
                }
            }
        }
        #endregion

        public event PrijavaHandler PrijavaCreated;

        public PrijavaAddEdit(Prijava prijava)
        {
            InitializeComponent();

            this.DataContext = this;

            StudentsFromDB = new Student().ucitajStudente();
            RoksFromDB = new Rok().ucitajRokove();
            Predmets = new Predmet().ucitajPredmete();
            CurrentPrijava = prijava;
            CurrentPrijava.Student = StudentsFromDB.FirstOrDefault(x => x.ID == prijava.Student?.ID);
            CurrentPrijava.Rok = RoksFromDB.FirstOrDefault(x => x.ID == prijava.Rok?.ID);

            foreach (var item in prijava.Predmeti ?? new ObservableCollection<Predmet>())
            {
                Predmets.FirstOrDefault(x => x.ID == item.ID).Selektovan = true;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CurrentPrijava.Predmeti = new ObservableCollection<Predmet>(Predmets.Where(x => x.Selektovan));

            if (CurrentPrijava.ID == 0)
                CurrentPrijava.dodajPrijavu();
            else
                CurrentPrijava.azurirajPrijavu();

            PrijavaCreated(CurrentPrijava);
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
