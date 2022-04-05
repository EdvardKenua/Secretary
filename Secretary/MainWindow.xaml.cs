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

namespace Secretary
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String TextToConvert = TextboxInput.Text;
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
    }
}
