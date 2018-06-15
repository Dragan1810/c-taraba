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
    public delegate void VrstaHandler(Vrsta rok);
    public partial class frmVrsta : UserControl, INotifyPropertyChanged
    {
        #region CurrentVrsta
        private Vrsta _CurrentVrsta;

        public Vrsta CurrentVrsta
        {
            get { return _CurrentVrsta; }
            set
            {
                if (_CurrentVrsta != value)
                {
                    _CurrentVrsta = value;
                    NotifyPropertyChanged("CurrentVrsta");
                }
            }
        }
        #endregion

        #region Roks
        private ObservableCollection<Vrsta> _Vrste;

        public ObservableCollection<Vrsta> Vrste
        {
            get { return _Vrste; }
            set
            {
                if (_Vrste != value)
                {
                    _Vrste = value;
                    NotifyPropertyChanged("Vrste");
                }
            }
        }
        #endregion

        public frmVrsta()
        {
            InitializeComponent();

            this.DataContext = this;

            Vrste = new Vrsta().ucitajVrste();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            VrstaAddEdit frmVrstaAddEdit = new VrstaAddEdit(new Vrsta());
            frmVrstaAddEdit.VrstaCreated += new VrstaHandler(Refresh);
            frmVrstaAddEdit.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            VrstaAddEdit frmVrstaAddEdit = new VrstaAddEdit(CurrentVrsta);
            frmVrstaAddEdit.VrstaCreated += new VrstaHandler(Refresh);
            frmVrstaAddEdit.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CurrentVrsta.obrisiVrstu();
            Vrste = new Vrsta().ucitajVrste();
        }

        private void Refresh(Vrsta vrsta)
        {
            Vrste = new Vrsta().ucitajVrste();
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
