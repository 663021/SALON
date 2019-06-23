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
using Microsoft.Win32;
using Xceed.Words.NET;

namespace SALON
{
    /// <summary>
    /// Логика взаимодействия для Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        public Window6()
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
            public string a_4 { get; set; }
            public string a_5 { get; set; }
            public string a_6 { get; set; }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + for_path + @"Салон.mdb";

            DataGridTextColumn c1 = new DataGridTextColumn();
            c1.Header = "ФИО";
            c1.Binding = new Binding("a_1");
            c1.Width = 100;
            DataGrid1.Columns.Add(c1);

            DataGridTextColumn c2 = new DataGridTextColumn();
            c2.Header = "Телефон";
            c2.Width = 100;
            c2.Binding = new Binding("a_2");
            DataGrid1.Columns.Add(c2);

            DataGridTextColumn c3 = new DataGridTextColumn();
            c3.Header = "Мастер";
            c3.Width = 100;
            c3.Binding = new Binding("a_3");
            DataGrid1.Columns.Add(c3);

            DataGridTextColumn c4 = new DataGridTextColumn();
            c4.Header = "Услуга";
            c4.Width = 100;
            c4.Binding = new Binding("a_4");
            DataGrid1.Columns.Add(c4);

            DataGridTextColumn c5 = new DataGridTextColumn();
            c5.Header = "Цена";
            c5.Width = 65;
            c5.Binding = new Binding("a_5");
            DataGrid1.Columns.Add(c5);

            DataGridTextColumn c6 = new DataGridTextColumn();
            c6.Header = "Дата";
            c6.Width = 140;
            c6.Binding = new Binding("a_6");
            DataGrid1.Columns.Add(c6);

            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command1 = new OleDbCommand("SELECT * FROM [Салон]", SqlConnection);

            sqlReader = command1.ExecuteReader();

            while (sqlReader.Read())
            {
                if (Convert.ToString(sqlReader["Мастер"]) == this.Tag.ToString())
                {
                    DataGrid1.Items.Add(new Item() { a_1 = Convert.ToString(sqlReader["Клиент"]), a_2 = Convert.ToString(sqlReader["Телефон"]), a_3 = Convert.ToString(sqlReader["Мастер"]), a_4 = Convert.ToString(sqlReader["Услуга"]), a_5 = Convert.ToString(sqlReader["Цена"]), a_6 = Convert.ToString(sqlReader["Дата"]) });
                    textBox.Text = Convert.ToString(Convert.ToInt32(textBox.Text) + 1);
                }
            }

            image_log_out.Source = new BitmapImage(new Uri(for_path + "exit.png"));
            image_close.Source = new BitmapImage(new Uri(for_path + "icon.png"));
            image_back.Source = new BitmapImage(new Uri(for_path + "back-arrow.png"));
            image_drop.Source = new BitmapImage(new Uri(for_path + "drop.png"));
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

        private async void Button_Copy2_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == false)
                return;

            string filename = saveFileDialog1.FileName;
            string pathDocument = filename + ".docx";
            DocX document = DocX.Create(pathDocument);

            document.InsertParagraph("Записи сотрудника: " + this.Tag.ToString()).
                FontSize(24).
                Bold().
                Alignment = Alignment.center;


            Xceed.Words.NET.Paragraph paragraph = document.InsertParagraph();
            paragraph.Alignment = Alignment.right;

            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command1 = new OleDbCommand("SELECT * FROM [Салон]", SqlConnection);

            sqlReader = command1.ExecuteReader();

            int for_sum = 0;

            while (sqlReader.Read())
            {
                if (Convert.ToString(sqlReader["Мастер"]) == this.Tag.ToString())
                {
                    document.InsertParagraph("Клиент: " + Convert.ToString(sqlReader["Клиент"]));
                    document.InsertParagraph("Телефон: " + Convert.ToString(sqlReader["Телефон"]));
                    document.InsertParagraph("Мастер: " + Convert.ToString(sqlReader["Мастер"]));
                    document.InsertParagraph("Услуги: " + Convert.ToString(sqlReader["Услуга"]));
                    document.InsertParagraph("Цена: " + Convert.ToString(sqlReader["Цена"]));
                    document.InsertParagraph("Дата: " + Convert.ToString(sqlReader["Дата"]));
                    document.InsertParagraph("");

                    for_sum += Convert.ToInt32(sqlReader["Цена"]);
                }
            }

            document.InsertParagraph("Итог: " + Convert.ToString(for_sum));

            document.Save();
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
