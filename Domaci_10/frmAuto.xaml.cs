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
    public delegate void AutoHandler(Auto auto);

    public partial class frmAuto : UserControl, INotifyPropertyChanged
    {
        #region CurrentPredmet
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

        #region Predmets
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

        public frmAuto()
        {
            InitializeComponent();

            this.DataContext = this;

            Autos = new Auto().ucitajAuto();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            AutoAddEdit frmAutoAddEdit = new AutoAddEdit(new Auto());
            frmAutoAddEdit.AutoCreated += new AutoHandler(Refresh);
            frmAutoAddEdit.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            AutoAddEdit frmPredmetAddEdit = new AutoAddEdit(CurrentAuto);
            frmPredmetAddEdit.AutoCreated += new AutoHandler(Refresh);
            frmPredmetAddEdit.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CurrentAuto.obrisiAuto();
            Autos = new Auto().ucitajAuto();
        }

        private void Refresh(Auto mehanicar)
        {
            Autos = new Auto().ucitajAuto();
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
