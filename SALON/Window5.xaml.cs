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
    public partial class Window5 : Window
    {
        public Window5()
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
            public string a_3 { get; set; }
        }

        string[] strArr = null;

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

            DataGridTextColumn c3 = new DataGridTextColumn();
            c3.Header = " ";
            c3.Width = 120;
            c3.Binding = new Binding("a_3");
            DataGrid1.Columns.Add(c3);

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
                        DataGrid1.Items.Add(new Item() { a_1 = Convert.ToString(sqlReader["Услуга"]), a_2 = Convert.ToString(sqlReader["Цена"]),a_3 = ""});
                    }
                }
            }
            else
            {
                while (sqlReader.Read())
                {
                    if (Convert.ToBoolean(sqlReader["Салон"]) == false)
                    {
                        DataGrid1.Items.Add(new Item() { a_1 = Convert.ToString(sqlReader["Услуга"]), a_2 = Convert.ToString(sqlReader["Цена"]), a_3 = "" });
                    }
                }
            }

            sqlReader.Close();

            command1 = new OleDbCommand("SELECT * FROM [Персонал]", SqlConnection);

            sqlReader = command1.ExecuteReader();

            if (this.Tag.ToString() == "true")
            {
                while (sqlReader.Read())
                {
                    if (Convert.ToBoolean(sqlReader["Салон"]) == true)
                    {
                        combo.Items.Add(Convert.ToString(sqlReader["ФИО"]));
                    }
                }
            }
            else
            {
                while (sqlReader.Read())
                {
                    if (Convert.ToBoolean(sqlReader["Салон"]) == false)
                    {
                        combo.Items.Add(Convert.ToString(sqlReader["ФИО"]));
                    }
                }
            }

            strArr = new string[DataGrid1.Items.Count];
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

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(combo.Text == "")
            {
                combo.Background = Brushes.Red;
                combo.Opacity = 0.2;
                return;
            }
            if (label_time.Text == "")
            {
                label_time.Background = Brushes.Red;
                label_time.Opacity = 0.4;
                return;
            }
            if (textBox_Copy.Text == "")
            {
                textBox_Copy.Background = Brushes.Red;
                textBox_Copy.Opacity = 0.4;
                return;
            }
            if (textBox_Copyy.Text == "")
            {
                textBox_Copyy.Background = Brushes.Red;
                textBox_Copyy.Opacity = 0.4;
                return;
            }
            if (textBox_Copy3.Text == "0")
            {
                textBox_Copy3.Background = Brushes.Red;
                textBox_Copy3.Opacity = 0.4;
                return;
            }
            if (textBox_Copy1.Text == "")
            {
                textBox_Copy1.Background = Brushes.Red;
                textBox_Copy1.Opacity = 0.4;
                return;
            }
            if (textBox_Copy2.Text == "")
            {
                textBox_Copy2.Background = Brushes.Red;
                textBox_Copy2.Opacity = 0.4;
                return;
            }

            SqlConnection = new OleDbConnection(connectString);
            SqlConnection.Open();

            OleDbDataReader sqlReader = null;

            OleDbCommand command1 = new OleDbCommand("SELECT * FROM [Салон]", SqlConnection);

            sqlReader = command1.ExecuteReader();

            while (sqlReader.Read())
            {
                if ((textBox_Copy.Text + ":" + textBox_Copyy.Text + " " + label_time.Text) == Convert.ToString(sqlReader["Дата"]))
                {
                    MessageBox.Show("Это время занято другой записью");
                    return;
                }
            }

            command1 = new OleDbCommand("INSERT INTO [Салон] (Клиент,Телефон,Мастер,Салон,Услуга,Цена,Дата)VALUES(@1,@2,@3,@4,@5,@6,@7)", SqlConnection);
            command1.Parameters.AddWithValue("1", textBox_Copy1.Text);
            command1.Parameters.AddWithValue("2", textBox_Copy2.Text);
            command1.Parameters.AddWithValue("3", combo.Text);
            

            if (this.Tag.ToString() == "false")
                command1.Parameters.AddWithValue("4", false);
            else
                command1.Parameters.AddWithValue("4", true);

            string for_str = "";
            for (int i = 0; i < strArr.Count(); i++)
            {
                if (strArr[i] != null) {
                    for_str += strArr[i] + "/";
                }
            }
            command1.Parameters.AddWithValue("5", for_str);
            command1.Parameters.AddWithValue("6", Convert.ToInt32(textBox_Copy3.Text));
            command1.Parameters.AddWithValue("7", textBox_Copy.Text + ":" + textBox_Copyy.Text + " " + label_time.Text);

            await command1.ExecuteNonQueryAsync();

            MessageBox.Show("Запись успешно добалена!");

            Window5 a = new Window5();
            a.Tag = this.Tag;
            a.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            combo.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            combo.Opacity = 1;
            
            label_time.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            label_time.Opacity = 1;

            textBox_Copy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy.Opacity = 1;

            textBox_Copyy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copyy.Opacity = 1;

            textBox_Copy3.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy3.Opacity = 1;

            textBox_Copy1.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy1.Opacity = 1;

            textBox_Copy2.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy2.Opacity = 1;
        }

        public int for_price = 0;

        

        private  void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var id_del = DataGrid1.SelectedIndex;
            var ci = new DataGridCellInfo(DataGrid1.Items[id_del], DataGrid1.Columns[2]);
            var content = ci.Column.GetCellContent(ci.Item) as TextBlock;

            for_price += Convert.ToInt32(content.Text);
            textBox_Copy3.Text = for_price.ToString();

            ci = new DataGridCellInfo(DataGrid1.Items[id_del], DataGrid1.Columns[1]);
            content = ci.Column.GetCellContent(ci.Item) as TextBlock;

            strArr[id_del] = content.Text;

            var bc = new BrushConverter();

            combo.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            combo.Opacity = 1;

            label_time.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            label_time.Opacity = 1;

            textBox_Copy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy.Opacity = 1;

            textBox_Copyy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copyy.Opacity = 1;

            textBox_Copy3.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy3.Opacity = 1;

            textBox_Copy1.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy1.Opacity = 1;

            textBox_Copy2.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy2.Opacity = 1;
        }

        private void CheckBox_Checked1(object sender, RoutedEventArgs e)
        {
            var id_del = DataGrid1.SelectedIndex;
            var ci = new DataGridCellInfo(DataGrid1.Items[id_del], DataGrid1.Columns[2]);
            var content = ci.Column.GetCellContent(ci.Item) as TextBlock;

            for_price -= Convert.ToInt32(content.Text);
            textBox_Copy3.Text = for_price.ToString();

            strArr[id_del] = null;

            var bc = new BrushConverter();

            combo.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            combo.Opacity = 1;

            label_time.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            label_time.Opacity = 1;

            textBox_Copy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy.Opacity = 1;

            textBox_Copyy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copyy.Opacity = 1;

            textBox_Copy3.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy3.Opacity = 1;

            textBox_Copy1.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy1.Opacity = 1;

            textBox_Copy2.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy2.Opacity = 1;
        }

        private void Label_time_CalendarOpened(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            combo.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            combo.Opacity = 1;

            label_time.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            label_time.Opacity = 1;

            textBox_Copy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy.Opacity = 1;

            textBox_Copyy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copyy.Opacity = 1;

            textBox_Copy3.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy3.Opacity = 1;

            textBox_Copy1.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy1.Opacity = 1;

            textBox_Copy2.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy2.Opacity = 1;
        }

        private void Combo_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            
        }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var bc = new BrushConverter();

            combo.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            combo.Opacity = 1;

            label_time.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            label_time.Opacity = 1;

            textBox_Copy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy.Opacity = 1;

            textBox_Copyy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copyy.Opacity = 1;

            textBox_Copy3.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy3.Opacity = 1;

            textBox_Copy1.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy1.Opacity = 1;

            textBox_Copy2.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy2.Opacity = 1;
        }

        private void TextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            combo.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            combo.Opacity = 1;

            label_time.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            label_time.Opacity = 1;

            textBox_Copy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy.Opacity = 1;

            textBox_Copyy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copyy.Opacity = 1;

            textBox_Copy3.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy3.Opacity = 1;

            textBox_Copy1.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy1.Opacity = 1;

            textBox_Copy2.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy2.Opacity = 1;

            try
            {
                if (Convert.ToInt32(textBox_Copy.Text) > 24)
                {
                    textBox_Copy.Text = "";
                }
            }
            catch
            {

            }
        }


        private void TextBox_TextChanged2(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            combo.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            combo.Opacity = 1;

            label_time.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            label_time.Opacity = 1;

            textBox_Copy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy.Opacity = 1;

            textBox_Copyy.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copyy.Opacity = 1;

            textBox_Copy3.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy3.Opacity = 1;

            textBox_Copy1.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy1.Opacity = 1;

            textBox_Copy2.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            textBox_Copy2.Opacity = 1;

            try
            {
                if (Convert.ToInt32(textBox_Copyy.Text) > 60)
                {
                    textBox_Copyy.Text = "";
                }
            }
            catch
            {

            }
        }

        private void TextBox_Copy_KeyDown(object sender, KeyEventArgs e)
        {
            
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
