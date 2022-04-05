using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Win32;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Secretary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public String TextToConvert = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextToConvert = TextboxInput.Text;
            Trim(ref TextToConvert);
            TextBoxOutput.Text = TextToConvert;
        }
        public static void Trim(ref String text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text = text.Replace("  ", " ");
                switch (text[i])
                {
                    case '.':
                    case ',':
                    case ':':
                    case ';':
                    case '!':
                    case '?':
                        if (i + 1 == text.Length)
                        {
                            break;
                        }
                        if (text[i + 1] != ' ')
                        {
                            text = text.Insert(i + 1, " ");
                        }
                        if (text[i - 1] == ' ')
                        {
                            text = text.Remove(i - 1, 1);
                            i--;
                        }
                        break;
                    case '-':
                        if (text[i - 1] != ' ')
                        {
                            text = text.Insert(i, " ");
                        }
                        if (text[i + 1] != ' ')
                        {
                            text = text.Insert(i + 1, " ");
                        }
                        break;
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TextboxInput.Text = null;
            TextBoxOutput.Text = null;
        }

        private void GetFile_Button_Click(object sender, RoutedEventArgs e)
        {
            Import();
            TextboxInput.Text = TextToConvert;

        }
        public void Import()
        {
            OpenFileDialog ofd = new OpenFileDialog(); // создаём процесс  
            ofd.ShowDialog(); // открываем проводник    
            if (ofd.FileName != "") // проверка на выбор файла  
            {
                StreamReader sr = new StreamReader(ofd.FileName); // открываем файл   
                while (!sr.EndOfStream) // перебираем строки, пока они не закончены       
                {
                    TextToConvert += sr.ReadLine();
                }
            }
            else MessageBox.Show("Файл не выбран");
        }
    }
}
