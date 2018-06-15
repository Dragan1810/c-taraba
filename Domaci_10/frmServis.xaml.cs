using Microsoft.Office.Interop.Excel;
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
    public delegate void ServisHandler(Servis servis);

    public partial class frmServis : UserControl, INotifyPropertyChanged
    {
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

                    Autos = _CurrentServis.Autos;
                }
            }
        }
        #endregion

        #region Servisi
        private ObservableCollection<Servis> _Servisi;

        public ObservableCollection<Servis> Servisi
        {
            get { return _Servisi; }
            set
            {
                if (_Servisi != value)
                {
                    _Servisi = value;
                    NotifyPropertyChanged("Servisi");
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


        public frmServis()
        {
            InitializeComponent();

            this.DataContext = this;

            Servisi = new Servis().ucitajServise();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            ServisAddEdit frmServisAddEdit = new ServisAddEdit(new Servis() { Datum = DateTime.Now });
            frmServisAddEdit.ServisCreated += new ServisHandler(Refresh);
            frmServisAddEdit.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ServisAddEdit frmPrijavaAddEdit = new ServisAddEdit(CurrentServis);
            frmPrijavaAddEdit.ServisCreated += new ServisHandler(Refresh);
            frmPrijavaAddEdit.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CurrentServis.obrisiServis();
            Servisi = new Servis().ucitajServise();
        }

        private void Refresh(Servis servis)
        {
            Servisi = new Servis().ucitajServise();
        }

        private void btnIzvestaj_Click(object sender, RoutedEventArgs e)
        {
            // Create excel workbook and sheet
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            // Insert document headers
            sheet1.Range[sheet1.Cells[1, 1], sheet1.Cells[1, 3]].Merge();
            sheet1.Cells[1, 1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
            sheet1.Cells[1, 1].Font.Bold = true;
            sheet1.Cells[1, 1] = "Podaci o Servisima";

            // Insert row headers
            sheet1.Rows[3].Font.Bold = true;
            sheet1.Cells[3, 1] = "Ime";
            sheet1.Cells[3, 2] = "Prezime";
            sheet1.Cells[3, 3] = "Vrsta Servisa";

            Servisi = new Servis().ucitajServise();
 
             for (int i = 0; i < Servisi.Count; i++)
             {
                 sheet1.Cells[i + 4, 1] = Servisi[i].Vlasnik.Ime;
                 sheet1.Cells[i + 4, 2] = Servisi[i].Vlasnik.Prezime;
                 sheet1.Cells[i + 4, 3] = Servisi[i].Vrsta.Naziv;
             }
            

            // Set additional options
            sheet1.Columns.AutoFit();

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
