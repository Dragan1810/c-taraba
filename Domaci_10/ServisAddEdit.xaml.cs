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
    public partial class ServisAddEdit : Window, INotifyPropertyChanged
    {
        #region VlasniciFromDB
        private ObservableCollection<Vlasnik> _VlasniciFromDB;

        public ObservableCollection<Vlasnik> VlasniciFromDB
        {
            get { return _VlasniciFromDB; }
            set
            {
                if (_VlasniciFromDB != value)
                {
                    _VlasniciFromDB = value;
                    NotifyPropertyChanged("VlasniciFromDB");
                }
            }
        }
        #endregion

        #region VrsteFromDB
        private ObservableCollection<Vrsta> _VrsteFromDB;

        public ObservableCollection<Vrsta> VrsteFromDB
        {
            get { return _VrsteFromDB; }
            set
            {
                if (_VrsteFromDB != value)
                {
                    _VrsteFromDB = value;
                    NotifyPropertyChanged("VrsteFromDB");
                }
            }
        }
        #endregion

        #region Autos
        private ObservableCollection<Auto> _Autos;

        public ObservableCollection<Auto> Autos
        {
            get { return _Autos; }
            set
            {
                if (_Autos != value)
                {
                    _Autos = value;
                    NotifyPropertyChanged("Autos");
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

        #region CurrentServis
        private Servis _CurrentServis;

        public Servis CurrentServis
        {
            get { return _CurrentServis; }
            set
            {
                if (_CurrentServis != value)
                {
                    _CurrentServis = value;
                    NotifyPropertyChanged("CurrentServis");
                }
            }
        }
        #endregion

        public event ServisHandler ServisCreated;

        public ServisAddEdit(Servis servis)
        {
            InitializeComponent();

            this.DataContext = this;

            VlasniciFromDB = new Vlasnik().ucitajVlasnike();
            VrsteFromDB = new Vrsta().ucitajVrste();
            Autos = new Auto().ucitajAuto();
            CurrentServis = servis;
            CurrentServis.Vlasnik = VlasniciFromDB.FirstOrDefault(x => x.ID == servis.Vlasnik?.ID);
            CurrentServis.Vrsta = VrsteFromDB.FirstOrDefault(x => x.ID == servis.Vrsta?.ID);

            foreach (var item in servis.Autos ?? new ObservableCollection<Auto>())
            {
                Autos.FirstOrDefault(x => x.ID == item.ID).Selektovan = true;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CurrentServis.Autos = new ObservableCollection<Auto>(Autos.Where(x => x.Selektovan));

            if (CurrentServis.ID == 0)
                CurrentServis.dodajServis();
            else
                CurrentServis.azurirajServis();

            ServisCreated(CurrentServis);
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
