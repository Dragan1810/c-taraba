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
    public delegate void PrijavaHandler(Prijava prijava);

    /// <summary>
    /// Interaction logic for frmPrijava.xaml
    /// </summary>
    public partial class frmPrijava : UserControl, INotifyPropertyChanged
    {
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

                    Predmets = _CurrentPrijava.Predmeti;
                }
            }
        }
        #endregion

        #region Prijavas
        private ObservableCollection<Prijava> _Prijavas;

        public ObservableCollection<Prijava> Prijavas
        {
            get { return _Prijavas; }
            set
            {
                if (_Prijavas != value)
                {
                    _Prijavas = value;
                    NotifyPropertyChanged("Prijavas");
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


        public frmPrijava()
        {
            InitializeComponent();

            this.DataContext = this;

            Prijavas = new Prijava().ucitajPrijave();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            PrijavaAddEdit frmPrijavaAddEdit = new PrijavaAddEdit(new Prijava() { Datum = DateTime.Now });
            frmPrijavaAddEdit.PrijavaCreated += new PrijavaHandler(Refresh);
            frmPrijavaAddEdit.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            PrijavaAddEdit frmPrijavaAddEdit = new PrijavaAddEdit(CurrentPrijava);
            frmPrijavaAddEdit.PrijavaCreated += new PrijavaHandler(Refresh);
            frmPrijavaAddEdit.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CurrentPrijava.obrisiPrijavu();
            Prijavas = new Prijava().ucitajPrijave();
        }

        private void Refresh(Prijava prijava)
        {
            Prijavas = new Prijava().ucitajPrijave();
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
