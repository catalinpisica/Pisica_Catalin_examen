using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
using BazaDateModel;

namespace Pisica_Catalin_examen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
 enum ActionState
 {
 New,
 Edit,
 Delete,
 Nothing
}
public partial class MainWindow : Window
    {
        //using BazaDateModel;
        BazaDateEntitiesModel ctx = new BazaDateEntitiesModel();
        CollectionViewSource angajatiViewSource;
        ActionState action = ActionState.Nothing;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //using System.Data.Entity;
            angajatiViewSource =
((System.Windows.Data.CollectionViewSource)(this.FindResource("angajatiViewSource")));
            angajatiViewSource.Source = ctx.Angajati.Local;
            ctx.Angajati.Load();
            angajatiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("angajatiViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // angajatiViewSource.Source = [generic data source]

        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
            btnCancel.IsEnabled = true;
            btnSave.IsEnabled = true;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnPrevious.IsEnabled = false;
            btnNext.IsEnabled = false;
            BindingOperations.ClearBinding(numeTextBox, TextBox.TextProperty);
            BindingOperations.ClearBinding(prenumeTextBox, TextBox.TextProperty);
            BindingOperations.ClearBinding(angIdTextBox, TextBox.TextProperty);
            BindingOperations.ClearBinding(functiaTextBox, TextBox.TextProperty);
            BindingOperations.ClearBinding(varstaTextBox, TextBox.TextProperty);
            BindingOperations.ClearBinding(salariu_brut_RONTextBox,
           TextBox.TextProperty);
            BindingOperations.ClearBinding(data_angajariiDatePicker,
           DatePicker.SelectedDateProperty);
            Keyboard.Focus(data_angajariiDatePicker);
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
            btnCancel.IsEnabled = true;
            btnSave.IsEnabled = true;
            btnNew.IsEnabled = false;
            btnDelete.IsEnabled = false;
            angajatiDataGrid.IsEnabled = false;
            btnPrevious.IsEnabled = false;
            btnNext.IsEnabled = false;

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
            btnCancel.IsEnabled = true;
            btnSave.IsEnabled = true;
            btnNew.IsEnabled = false;
            btnEdit.IsEnabled = false;
            angajatiDataGrid.IsEnabled = false;
            btnPrevious.IsEnabled = false;
            btnNext.IsEnabled = false;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Nothing;
            btnNew.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            btnNext.IsEnabled = true;
            btnPrevious.IsEnabled = true;
            angajatiDataGrid.IsEnabled = true;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Angajati angajat = null;
            if (action == ActionState.New)
            {
                try
                {
                   
                    angajat = new Angajati()
                    {
                        Nume = numeTextBox.Text.Trim(),
                        Prenume = prenumeTextBox.Text.Trim(),
                        Salariu_brut_RON = Decimal.Parse(salariu_brut_RONTextBox.Text.Trim()),
                        Data_angajarii = data_angajariiDatePicker.SelectedDate,
                        Functia = functiaTextBox.Text.Trim(),
                        Varsta = Decimal.Parse(varstaTextBox.Text.Trim())
                    };                
                    ctx.Angajati.Add(angajat);
                    angajatiViewSource.View.Refresh();                   
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            if (action == ActionState.Edit)
            {
                try
                {
                    angajat = (Angajati)angajatiDataGrid.SelectedItem;
                    angajat.Nume = numeTextBox.Text.Trim();
                    angajat.Prenume = prenumeTextBox.Text.Trim();
                    angajat.Salariu_brut_RON = Decimal.Parse(salariu_brut_RONTextBox.Text.Trim());
                    angajat.Data_angajarii = data_angajariiDatePicker.SelectedDate;
                    angajat.Functia = functiaTextBox.Text.Trim();
                    angajat.Varsta = Decimal.Parse(varstaTextBox.Text.Trim());
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                angajatiViewSource.View.Refresh();
                angajatiViewSource.View.MoveCurrentTo(angajat);
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    angajat = (Angajati)angajatiDataGrid.SelectedItem;
                    ctx.Angajati.Remove(angajat);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                angajatiViewSource.View.Refresh();

            }
            btnNew.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            btnNext.IsEnabled = true;
            btnPrevious.IsEnabled = true;
            angajatiDataGrid.IsEnabled = true;
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            angajatiViewSource.View.MoveCurrentToNext();
        }
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            angajatiViewSource.View.MoveCurrentToPrevious();
        }
    }
}
