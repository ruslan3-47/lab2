using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Matrix
    {
        public int Row {  get; set; }
        public int Col { get; set; }
        public int[,] Data;
        public Matrix(int row,int column) {
            Row = row;
            Col = column;
            Data = new int[row,column];
        }
        public int this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= Row || column < 0 || column >= Col)
                    throw new ArgumentException("Индексы выходят за границы матрицы.");
                return Data[row,column];
            }
            set
            {
                if (row < 0 || row >= Row || column < 0 || column >= Col)
                    throw new ArgumentException("Индексы выходят за границы матрицы.");
                Data[row,column] = value;
            }
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if(a.Col != b.Col || a.Row != b.Row)
            {
                throw new ArgumentException("Введите корректные размерности");
            }
            Matrix result = new Matrix(a.Row,a.Col);
            for (int i = 0; i < a.Row; i++) 
                  { 
                    for (int j = 0; j < a.Col; j++)
                    {
                        result[i, j] = a[i, j] + b[i, j];
                    }
                }
            return result;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Col != b.Row)
            {
                throw new ArgumentException("Введите корректные размерности");
            }
            Matrix result = new Matrix(a.Row, b.Col);
            for (int i = 0;i < a.Row;i++)
            {
                for (int j = 0;j < b.Col;j++)
                {
                    for (int k = 0;k < a.Col;k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0;i< Row; i++) 
            {
                for (int j = 0;j< Col;j++)
                {
                    result += Data[i, j] + "\t";
                }
                result += "\n";
            }
            return result;
        }
        public void saveCSV(string filepath) 
        {
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                    {
                        writer.Write(Data[i, j]);
                        if (j < Col - 1)
                        {
                            writer.Write(";");
                        }

                    }
                    writer.Write("\n");
                }
                writer.WriteLine();
            }
        }
    }
}
