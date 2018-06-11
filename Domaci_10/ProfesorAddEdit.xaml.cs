using System;
using System.Collections.Generic;
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
    /// Interaction logic for ProfesorAddEdit.xaml
    /// </summary>
    public partial class ProfesorAddEdit : Window, INotifyPropertyChanged
    {
        #region CurrentProfesor
        private Profesor _CurrentProfesor = new Profesor();

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

        public event ProfesorHandler ProfesorCreated;


        public ProfesorAddEdit(Profesor student)
        {
            InitializeComponent();

            this.DataContext = this;

            CurrentProfesor = student;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentProfesor.ID == 0)
                CurrentProfesor.dodajProfesora();
            else
                CurrentProfesor.azurirajProfesora();

            ProfesorCreated(CurrentProfesor);
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
