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
    public delegate void RokHandler(Rok rok);

    /// <summary>
    /// Interaction logic for frmRok.xaml
    /// </summary>
    public partial class frmRok : UserControl, INotifyPropertyChanged
    {
        #region CurrentRok
        private Rok _CurrentRok;

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

        #region Roks
        private ObservableCollection<Rok> _Roks;

        public ObservableCollection<Rok> Roks
        {
            get { return _Roks; }
            set
            {
                if (_Roks != value)
                {
                    _Roks = value;
                    NotifyPropertyChanged("Roks");
                }
            }
        }
        #endregion

        public frmRok()
        {
            InitializeComponent();

            this.DataContext = this;

            Roks = new Rok().ucitajRokove();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            RokAddEdit frmRokAddEdit = new RokAddEdit(new Rok());
            frmRokAddEdit.RokCreated += new RokHandler(Refresh);
            frmRokAddEdit.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            RokAddEdit frmRokAddEdit = new RokAddEdit(CurrentRok);
            frmRokAddEdit.RokCreated += new RokHandler(Refresh);
            frmRokAddEdit.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CurrentRok.obrisiRok();
            Roks = new Rok().ucitajRokove();
        }

        private void Refresh(Rok prof)
        {
            Roks = new Rok().ucitajRokove();
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
