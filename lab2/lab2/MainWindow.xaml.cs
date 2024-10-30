using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace lab2
{

    public partial class MainWindow : Window
    {
        private Matrix matrix1;
        private Matrix matrix2;
        private Matrix result;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateMatrix_Click(object sender, RoutedEventArgs e)
        {
            int rows = int.Parse(Rows.Text);
            int columns = int.Parse(Columns.Text);

            matrix1 = new Matrix(rows, columns);
            matrix2 = new Matrix(rows, columns);
            CreateGrid(Matrix1grid, matrix1);
            CreateGrid(Matrix2grid, matrix2);
        }
        private static void CreateGrid(Grid grid,Matrix matrix)
        {
            grid.Children.Clear();
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();
            
            for (int i = 0; i < matrix.Row;i++) 
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0;i<matrix.Col;i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0;i<matrix.Row;i++)
            {
                for (int j = 0; j < matrix.Col;j++)
                {
                    var textbox = new TextBox
                    {
                        Text = "0",
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Width = 50,
                        Height = 30,
                        Tag = new Tuple<int,int>(i,j)
                    };
                    textbox.TextChanged += (s, e) =>
                    {
                        if (string.IsNullOrEmpty(textbox.Text))
                        {
                            textbox.Text = "";
                            return;
                        }
                        if (int.TryParse(textbox.Text, out int value))
                        {
                            var index = (Tuple<int, int>)textbox.Tag;
                            matrix[index.Item1, index.Item2] = value;
                        }
                        else
                        {
                            var index = (Tuple<int, int>)textbox.Tag;
                            textbox.Text = matrix[index.Item1,index.Item2].ToString();
                        }
                    };
                    Grid.SetRow(textbox, i);
                    Grid.SetColumn(textbox, j);
                    grid.Children.Add(textbox);
                }
            }
        }

        private void Sum_Click(object sender, RoutedEventArgs e)
        {
            if (matrix1 != null && matrix2 != null)
            {
                try
                {
                    result = matrix1 + matrix2;
                    MessageBox.Show(result.ToString(), "Та-дам");
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Ошибка размерности");
                }
            }
            else
            {
                MessageBox.Show("матрицы небыли созданы");
            }
        }
        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            if (matrix1 != null && matrix2 != null)
            {
                try
                {
                    result = matrix1 * matrix2;
                    MessageBox.Show(result.ToString(), "Та-дам");
                }
                catch(ArgumentException)
                {
                    MessageBox.Show("Ошибка");
                }
            }
            else
            {
                MessageBox.Show("матрицы небыли созданы");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (result != null)
            {
                SaveFileDialog save = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                    DefaultExt = "csv"
                };
                if(save.ShowDialog() == true)
                {
                    result.saveCSV(save.FileName);
                    MessageBox.Show("Матрица сохранена");
                }
            }
            else
            {
                MessageBox.Show("Результирующая матрица не была создана");
            }
        }
    }
    }