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
    public delegate void StudentHandler(Student student);

    /// <summary>
    /// Interaction logic for frmStudent.xaml
    /// </summary>
    public partial class frmStudent : UserControl, INotifyPropertyChanged
    {
        #region CurrentStudent
        private Student _CurrentStudent;

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

        #region Students
        private ObservableCollection<Student> _Students;

        public ObservableCollection<Student> Students
        {
            get { return _Students; }
            set
            {
                if (_Students != value)
                {
                    _Students = value;
                    NotifyPropertyChanged("Students");
                }
            }
        }
        #endregion


        public frmStudent()
        {
            InitializeComponent();

            this.DataContext = this;

            Students = new Student().ucitajStudente();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            StudentAddEdit frmStudentAddEdit = new StudentAddEdit(new Student());
            frmStudentAddEdit.StudentCreated += new StudentHandler(Refresh);
            frmStudentAddEdit.Show();
        }

        private void btnEditSpecification_Click(object sender, RoutedEventArgs e)
        {
            StudentAddEdit frmStudentAddEdit = new StudentAddEdit(CurrentStudent);
            frmStudentAddEdit.StudentCreated += new StudentHandler(Refresh);
            frmStudentAddEdit.Show();
        }

        private void Refresh(Student stud)
        {
            Students = new Student().ucitajStudente();
        }

        private void btnDeleteSpecification_Click(object sender, RoutedEventArgs e)
        {
            CurrentStudent.obrisiStudenta();
            Students = new Student().ucitajStudente();
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
