using Microsoft.Win32;
using SEC_LAB_C;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace SEC_LAB_C
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string file_origin;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string file_path = openFileDialog.FileName;
                file_origin = file_path;
                try
                {
                    string text = File.ReadAllText(file_path);
                    textbox_orginal_txt.Text = text;
                    string fileContent = File.ReadAllText(file_path);
                    int characterCount = fileContent.Length;
                    num_of_symb.Content = characterCount;
                }
                catch (Exception ex)
                {
                    // Обработка ошибки чтения файла
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            string normal_txt = textbox_orginal_txt.Text;

            int key_a = Convert.ToInt32(input_key_a.Text);
            int key_b = Convert.ToInt32(input_key_b.Text);

            //Зашифрование сообщения
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var encrypted_txt = affine_cheaper.AFFINE_ENCRYPTED(normal_txt, key_a, key_b);
            sw.Stop();
            time_encr.Content = sw.ElapsedMilliseconds + " мс";
            //
            
            //Расшифрование сообщения
            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            var decrypted_txt = affine_cheaper.AFFINE_DECRYPTED(encrypted_txt, key_a, key_b);
            sw2 .Stop();
            time_decr.Content = sw2.ElapsedMilliseconds + " мс";
            //

            textbox_encrypted_txt.Text = encrypted_txt;
            textbox_decrypted_txt.Text = decrypted_txt;
        }
    }
}
