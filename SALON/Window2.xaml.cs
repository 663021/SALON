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
using System.Windows.Shapes;
using System.Data.OleDb;

namespace SALON
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        OleDbConnection SqlConnection;

        public string for_path = Environment.CurrentDirectory.Remove(Environment.CurrentDirectory.LastIndexOf("i") - 1);

        public string connectString;

        public void alert()
        {
            textBox.Background = Brushes.Red;
            textBox.Opacity = 0.4;

            passwordBox_Copy.Background = Brushes.Red;
            passwordBox_Copy.Opacity = 0.4;

            textBox_Copy.Background = Brushes.Red;
            textBox_Copy.Opacity = 0.4;

            passwordBox_Copy1.Background = Brushes.Red;
            passwordBox_Copy1.Opacity = 0.4;
        }

        public void alert_password()
        {
            passwordBox_Copy.Background = Brushes.Red;
            passwordBox_Copy.Opacity = 0.4;

            passwordBox_Copy1.Background = Brushes.Red;
            passwordBox_Copy1.Opacity = 0.4;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            #region close
            if (textBox.Text == "")
            {
                alert();
                return;
            }
            if (textBox_Copy.Text == "")
            {
                alert();
                return;
            }
            if (passwordBox_Copy.Password.ToString() == "")
            {
                alert();
                return;
            }
            if (passwordBox_Copy1.Password.ToString() == "")
            {
                alert();
                return;
            }

            if (passwordBox_Copy1.Password.ToString() != passwordBox_Copy.Password.ToString())
            {
                alert_password();
                return;
            }
            #endregion

            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();

            OleDbCommand command1 = new OleDbCommand("INSERT INTO [Пользователи] (ФИО,Логин,Пароль)VALUES(@1,@2,@3)", SqlConnection);

            command1.Parameters.AddWithValue("@1", textBox.Text);
            command1.Parameters.AddWithValue("@2", textBox_Copy.Text);
            command1.Parameters.AddWithValue("@3", passwordBox_Copy.Password.ToString());

            await command1.ExecuteNonQueryAsync();

            Window1 o = new Window1();
            o.Show();
            this.Hide();


            return;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + for_path + @"Салон.mdb";

            image_log_out.Source = new BitmapImage(new Uri(for_path + "back-arrow.png"));
            image_close.Source = new BitmapImage(new Uri(for_path + "icon.png"));
            image_drop.Source = new BitmapImage(new Uri(for_path + "drop.png"));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            textBox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox.Opacity = 1;

            textBox_Copy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy.Opacity = 1;

            passwordBox_Copy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            passwordBox_Copy.Opacity = 1;

            passwordBox_Copy1.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            passwordBox_Copy1.Opacity = 1;
        }

        private void PasswordBox_Copy1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            textBox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox.Opacity = 1;

            textBox_Copy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy.Opacity = 1;

            passwordBox_Copy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            passwordBox_Copy.Opacity = 1;

            passwordBox_Copy1.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            passwordBox_Copy1.Opacity = 1;
        }

        private void Image_log_out_MouseEnter(object sender, MouseEventArgs e)
        {
            image_log_out.Source = new BitmapImage(new Uri(for_path + "back-arrow1.png"));
        }

        private void Image_log_out_MouseLeave(object sender, MouseEventArgs e)
        {
            image_log_out.Source = new BitmapImage(new Uri(for_path + "back-arrow.png"));
        }

        private void Image_log_out_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
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
    }
}
