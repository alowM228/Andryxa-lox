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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.sq1DataSetTableAdapters;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        studentTableAdapter sq2 = new studentTableAdapter();
     
        public MainWindow()
        {
            InitializeComponent();
            Aqw.ItemsSource = sq2.GetData();





        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sq2.InsertQuery(NameTbx.Text, NameTbx1.Text, NameTbx2.Text, Convert.ToInt32(NameTbx3.Text));

            Aqw.ItemsSource = sq2.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.ShowDialog();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object id = (Aqw.SelectedItem as DataRowView).Row[0];
            sq2.DeleteQuery(Convert.ToInt32(id));
            Aqw.ItemsSource = sq2.GetData();
        }



        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            object id = (Aqw.SelectedItem as DataRowView).Row[0];
            sq2.UpdateQuery(NameTbx.Text, NameTbx1.Text, NameTbx2.Text, Convert.ToInt32(NameTbx3.Text), Convert.ToInt32(id));
            Aqw.ItemsSource = sq2.GetData();
        }

        private void Aqw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                NameTbx.Text = (Aqw.SelectedItem as DataRowView).Row[1].ToString();
                NameTbx1.Text = (Aqw.SelectedItem as DataRowView).Row[2].ToString();
                NameTbx2.Text = (Aqw.SelectedItem as DataRowView).Row[3].ToString();
                NameTbx3.Text = (Aqw.SelectedItem as DataRowView).Row[4].ToString();

               


            }
            catch
            {
                NameTbx.Text = null;
                NameTbx1.Text = null;
                NameTbx2.Text = null;
                NameTbx3.Text = null;

            }


        }
    }
}
