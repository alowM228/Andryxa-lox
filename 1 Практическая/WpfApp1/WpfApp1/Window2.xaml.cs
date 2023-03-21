using System;
using System.Collections.Generic;
using System.Data;
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
using WpfApp1.sq1DataSetTableAdapters;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        estimatesTableAdapter sq2 = new estimatesTableAdapter();
        teacherTableAdapter sq3 = new teacherTableAdapter();
        studentTableAdapter sq4 = new studentTableAdapter();

        private int idstudent;
        private int idteacher;
        public Window2()
        {
            InitializeComponent();
            Aqw.ItemsSource = sq2.GetData();
            boxmaster.ItemsSource = sq3.GetData();
            boxmaster.DisplayMemberPath = "second_name";

            boxmaster1.ItemsSource = sq4.GetData();
            boxmaster1.DisplayMemberPath = "second_name";

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            sq2.InsertQuery(DateTime.Now,idstudent,idteacher, NameTbx.Text, Convert.ToInt32(NameTbx1.Text)) ;
            Aqw.ItemsSource = sq2.GetData();
        }

        private void boxmaster_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            idteacher = (int)(boxmaster.SelectedItem as DataRowView).Row[0];
        }
        private void boxmaster1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                idstudent = (int)(boxmaster1.SelectedItem as DataRowView).Row[0];
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            object id = (Aqw.SelectedItem as DataRowView).Row[0];
            sq2.DeleteQuery(Convert.ToInt32(id));
            Aqw.ItemsSource = sq2.GetData();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            object id = (Aqw.SelectedItem as DataRowView).Row[0];
            sq2.UpdateQuery(DateTime.Now, idstudent, idteacher, NameTbx.Text, Convert.ToInt32(NameTbx1.Text), Convert.ToInt32(id));
            Aqw.ItemsSource = sq2.GetData();
        }

        private void Aqw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                NameTbx.Text = (Aqw.SelectedItem as DataRowView).Row[4].ToString();
                NameTbx1.Text = (Aqw.SelectedItem as DataRowView).Row[5].ToString();


            }
            catch
            {
                NameTbx.Text = null;
                NameTbx1.Text = null;
            }

        }
    }
}
