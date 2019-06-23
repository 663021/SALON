using System;
using System.Collections.Generic;
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
using System.Data.OleDb;

namespace SALON
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        OleDbConnection SqlConnection;

        public string for_path = Environment.CurrentDirectory.Remove(Environment.CurrentDirectory.LastIndexOf("i") - 1);

        public string connectString;

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command1 = new OleDbCommand("SELECT * FROM [Пользователи]", SqlConnection);

            sqlReader = command1.ExecuteReader();

            while (sqlReader.Read())
            {
                if (textBox.Text == Convert.ToString(sqlReader["Логин"]))
                {
                    if (passwordBox.Password.ToString() == Convert.ToString(sqlReader["Пароль"]))
                    {
                        Window1 o = new Window1();
                        o.Show();
                        this.Close();
                        return;
                    }
                }
            }

            textBox.Background = Brushes.Red;
            textBox.Opacity = 0.4;

            passwordBox.Background = Brushes.Red;
            passwordBox.Opacity = 0.4;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + for_path + @"Салон.mdb";

            image_close.Source = new BitmapImage(new Uri(for_path + "icon.png"));
            image_drop.Source = new BitmapImage(new Uri(for_path + "drop.png"));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            textBox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox.Opacity = 1;
            passwordBox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            passwordBox.Opacity = 1;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            textBox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox.Opacity = 1;
            passwordBox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            passwordBox.Opacity = 1;
        }

        private void Button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Window2 o = new Window2();
            o.Show();
            this.Close();
            return;
        }

        private void Image_log_out_MouseEnter1(object sender, MouseEventArgs e)
        {
            image_close.Source = new BitmapImage(new Uri(for_path + "icon1.png"));
        }

        private void Image_log_out_MouseLeave1(object sender, MouseEventArgs e)
        {
            image_close.Source = new BitmapImage(new Uri(for_path + "icon.png"));
        }

        private void Image_log_out_MouseDown1(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_log_out_MouseEnter_drop(object sender, MouseEventArgs e)
        {
            image_drop.Source = new BitmapImage(new Uri(for_path + "drop1.png"));
        }

        private void Image_log_out_MouseLeave_drop(object sender, MouseEventArgs e)
        {
            image_drop.Source = new BitmapImage(new Uri(for_path + "drop.png"));
        }

        private void Image_log_out_MouseDown_drop(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TextBox_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

        }
    }
}
