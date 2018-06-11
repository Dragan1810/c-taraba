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
    /// Interaction logic for StudentAddEdit.xaml
    /// </summary>
    public partial class StudentAddEdit : Window, INotifyPropertyChanged
    {
        #region CurrentStudent
        private Student _CurrentStudent = new Student();

        public Student CurrentStudent
        {
            get { return _CurrentStudent; }
            set
            {
                if (_CurrentStudent != value)
                {
                    _CurrentStudent = value;
                    NotifyPropertyChanged("CurrentStudent");
                }
            }
        }
        #endregion

        public event StudentHandler StudentCreated;


        public StudentAddEdit(Student student)
        {
            InitializeComponent();

            this.DataContext = this;

            CurrentStudent = student;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentStudent.ID == 0)
                CurrentStudent.dodajStudenta();
            else
                CurrentStudent.azurirajStudenta();

            StudentCreated(CurrentStudent);
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
