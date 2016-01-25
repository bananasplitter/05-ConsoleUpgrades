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
using System.IO;

namespace SortingAlgorithms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[] list;

        public MainWindow()
        {
            list = readNumberFromFile();
            InitializeComponent();
        }

        static int[] readNumberFromFile()
        {
            string fileContents = File.ReadAllText("C:\\dev\\data\\unsorted-number.txt");
            string[] numbersAssString = fileContents.Split(',');
            int[] numbers = new int[numbersAssString.Length];

            for (int i = 0; i < numbersAssString.Length; i++)
            {
                numbers[i] = int.Parse(numbersAssString[i]);
            }

            return numbers;
        }

        private void BubbleSort_Click(object sender, RoutedEventArgs e)
        {
            for (int i = list.Length - 1; i > 0; i--)
            {
                for(int j = 0; j < i; j++)
                {
                    if(list[j]>list[j + 1])
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;

                    }
                }
            }

            textBoxSort.Text = ("Your results:" + string.Join(", ", list));
        }

        private void InsertionSort_Click(object sender, RoutedEventArgs e)
        {
            int temp, j;
            for(int i = 1; i < list.Length; i++)
            {
                temp = list[i];
                j = i - 1;
                while(j > 0 && list[j] > temp)
                {
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = temp;
            }
            textBoxSort.Text = ("You're Results:" + string.Join(",", list));
        }
    }
}
