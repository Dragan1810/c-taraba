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
    public delegate void ProfesorHandler(Profesor profesor);

    public partial class frmProfesor : UserControl, INotifyPropertyChanged
    {
        #region CurrentProfesor
        private Profesor _CurrentProfesor;

        public Profesor CurrentProfesor
        {
            get { return _CurrentProfesor; }
            set
            {
                if (_CurrentProfesor != value)
                {
                    _CurrentProfesor = value;
                    NotifyPropertyChanged("CurrentProfesor");
                }
            }
        }
        #endregion

        #region Profesors
        private ObservableCollection<Profesor> _Profesors;

        public ObservableCollection<Profesor> Profesors
        {
            get { return _Profesors; }
            set
            {
                if (_Profesors != value)
                {
                    _Profesors = value;
                    NotifyPropertyChanged("Profesors");
                }
            }
        }
        #endregion

        public frmProfesor()
        {
            InitializeComponent();

            this.DataContext = this;

            Profesors = new Profesor().ucitajProfesore();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            ProfesorAddEdit frmProfesorAddEdit = new ProfesorAddEdit(new Profesor());
            frmProfesorAddEdit.ProfesorCreated += new ProfesorHandler(Refresh);
            frmProfesorAddEdit.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ProfesorAddEdit frmProfesorAddEdit = new ProfesorAddEdit(CurrentProfesor);
            frmProfesorAddEdit.ProfesorCreated += new ProfesorHandler(Refresh);
            frmProfesorAddEdit.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CurrentProfesor.obrisiProfesora();
            Profesors = new Profesor().ucitajProfesore();
        }

        private void Refresh(Profesor prof)
        {
            Profesors = new Profesor().ucitajProfesore();
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
