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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        OleDbConnection SqlConnection;

        public string for_path = Environment.CurrentDirectory.Remove(Environment.CurrentDirectory.LastIndexOf("i") - 1);

        public string connectString;

        public class Item
        {
            public string a_1 { get; set; }
            public string a_2 { get; set; }
        }

        public void grid_add()
        {
            DataGridTextColumn c1 = new DataGridTextColumn();
            c1.Header = "Услуга";
            c1.Binding = new Binding("a_1");
            c1.Width = 200;
            DataGrid1.Columns.Add(c1);

            DataGridTextColumn c2 = new DataGridTextColumn();
            c2.Header = "Цена";
            c2.Width = 120;
            c2.Binding = new Binding("a_2");
            DataGrid1.Columns.Add(c2);

            SqlConnection = new OleDbConnection(connectString);
            SqlConnection.Open();
            OleDbDataReader sqlReader = null;

            OleDbCommand command1 = new OleDbCommand("SELECT * FROM [Услуги]", SqlConnection);

            sqlReader = command1.ExecuteReader();

            if (this.Tag.ToString() == "true")
            {
                while (sqlReader.Read())
                {
                    if (Convert.ToBoolean(sqlReader["Салон"]) == true)
                    {
                        DataGrid1.Items.Add(new Item() { a_1 = Convert.ToString(sqlReader["Услуга"]), a_2 = Convert.ToString(sqlReader["Цена"]) });
                    }
                }
            }
            else
            {
                while (sqlReader.Read())
                {
                    if (Convert.ToBoolean(sqlReader["Салон"]) == false)
                    {
                        DataGrid1.Items.Add(new Item() { a_1 = Convert.ToString(sqlReader["Услуга"]), a_2 = Convert.ToString(sqlReader["Цена"]) });
                    }
                }
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + for_path + @"Салон.mdb";

            image_log_out.Source = new BitmapImage(new Uri(for_path + "exit.png"));
            image_close.Source = new BitmapImage(new Uri(for_path + "icon.png"));
            image_back.Source = new BitmapImage(new Uri(for_path + "back-arrow.png"));
            image_drop.Source = new BitmapImage(new Uri(for_path + "drop.png"));

            grid_add();
        }

        private void Image_log_out_MouseEnter(object sender, MouseEventArgs e)
        {
            image_log_out.Source = new BitmapImage(new Uri(for_path + "exit1.png"));
        }

        private void Image_log_out_MouseLeave(object sender, MouseEventArgs e)
        {
            image_log_out.Source = new BitmapImage(new Uri(for_path + "exit.png"));
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

        private void Image_log_out_MouseEnter2(object sender, MouseEventArgs e)
        {
            image_back.Source = new BitmapImage(new Uri(for_path + "back-arrow1.png"));
        }

        private void Image_log_out_MouseLeave2(object sender, MouseEventArgs e)
        {
            image_back.Source = new BitmapImage(new Uri(for_path + "back-arrow.png"));
        }

        private void Image_log_out_MouseDown2(object sender, MouseButtonEventArgs e)
        {
            Window1 a = new Window1();
            a.Show();
            this.Close();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить запись из базы?", "Внимание!", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                var id_del = DataGrid1.SelectedIndex;
                var ci = new DataGridCellInfo(DataGrid1.Items[id_del], DataGrid1.Columns[1]);
                var content = ci.Column.GetCellContent(ci.Item) as TextBlock;

                SqlConnection = new OleDbConnection(connectString);
                await SqlConnection.OpenAsync();

                OleDbCommand command1 = new OleDbCommand("DELETE * FROM [Услуги] WHERE [Услуга]=@1", SqlConnection);
                command1.Parameters.AddWithValue("1", content.Text);
                await command1.ExecuteNonQueryAsync();

                DataGrid1.Items.RemoveAt(id_del);
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "")
            {
                textBox.Background = Brushes.Red;
                textBox.Opacity = 0.4;
                textBox_Copy.Background = Brushes.Red;
                textBox_Copy.Opacity = 0.4;
                return;
            }

            if (textBox_Copy.Text == "")
            {
                textBox_Copy.Background = Brushes.Red;
                textBox_Copy.Opacity = 0.4;
                textBox.Background = Brushes.Red;
                textBox.Opacity = 0.4;
                return;
            }

            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();

            OleDbCommand command1 = new OleDbCommand("INSERT INTO [Услуги] (Услуга,Цена,Салон)VALUES(@1,@2,@3)", SqlConnection);
            command1.Parameters.AddWithValue("1", textBox.Text);
            command1.Parameters.AddWithValue("2", textBox_Copy.Text);

            if (this.Tag.ToString() == "false")
                command1.Parameters.AddWithValue("3", false);
            else
                command1.Parameters.AddWithValue("3", true);

            await command1.ExecuteNonQueryAsync();

            DataGrid1.Items.Add(new Item() { a_1 = textBox.Text, a_2 = textBox_Copy.Text });

            textBox.Text = "";
            textBox_Copy.Text = "";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            textBox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox.Opacity = 1;
            textBox_Copy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy.Opacity = 1;
        }

        private void TextBox_Copy_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
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
