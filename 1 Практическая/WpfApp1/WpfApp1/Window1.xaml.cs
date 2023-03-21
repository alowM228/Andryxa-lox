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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        teacherTableAdapter sq2 = new teacherTableAdapter();
    
        public Window1()
        {
            InitializeComponent();
            Aqw.ItemsSource = sq2.GetData();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            sq2.InsertQuery(NameTbx.Text, NameTbx1.Text, NameTbx2.Text);
            Aqw.ItemsSource = sq2.GetData();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.ShowDialog();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            object id = (Aqw.SelectedItem as DataRowView).Row[0];
            sq2.DeleteQuery(Convert.ToInt32(id));
            Aqw.ItemsSource = sq2.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object id = (Aqw.SelectedItem as DataRowView).Row[0];
            sq2.UpdateQuery(NameTbx.Text, NameTbx1.Text, NameTbx2.Text, Convert.ToInt32(id));
            Aqw.ItemsSource = sq2.GetData();

        }

        private void Aqw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                NameTbx.Text = (Aqw.SelectedItem as DataRowView).Row[1].ToString();
                NameTbx1.Text = (Aqw.SelectedItem as DataRowView).Row[2].ToString();
                NameTbx2.Text = (Aqw.SelectedItem as DataRowView).Row[3].ToString();
                



            }
            catch
            {
                NameTbx.Text = null;
                NameTbx1.Text = null;
                NameTbx2.Text = null;
             

            }
        }
    }
}
