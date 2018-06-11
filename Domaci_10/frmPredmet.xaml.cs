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
    public delegate void PredmetHandler(Predmet predmet);

    /// <summary>
    /// Interaction logic for frmPredmet.xaml
    /// </summary>
    public partial class frmPredmet : UserControl, INotifyPropertyChanged
    {
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

        public frmPredmet()
        {
            InitializeComponent();

            this.DataContext = this;

            Predmets = new Predmet().ucitajPredmete();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            PredmetAddEdit frmPredmetAddEdit = new PredmetAddEdit(new Predmet());
            frmPredmetAddEdit.PredmetCreated += new PredmetHandler(Refresh);
            frmPredmetAddEdit.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            PredmetAddEdit frmPredmetAddEdit = new PredmetAddEdit(CurrentPredmet);
            frmPredmetAddEdit.PredmetCreated += new PredmetHandler(Refresh);
            frmPredmetAddEdit.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CurrentPredmet.obrisiPredmet();
            Predmets = new Predmet().ucitajPredmete();
        }

        private void Refresh(Predmet prof)
        {
            Predmets = new Predmet().ucitajPredmete();
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
