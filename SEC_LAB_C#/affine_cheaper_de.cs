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
using Microsoft.Win32;
using System.IO.Packaging;
using System.Diagnostics;

namespace SEC_LAB_C
{
    public class affine_cheaper_de
    {
        public static string AFFINE_ENCRYPTED(string input_msg, int key_a, int key_b)
        {
            string encrypted_output_msg = "";
            foreach (char c in input_msg)
            {
                if (Char.IsLetter(c))
                {
                    int shiftedChar = ((key_a * ((int)Char.ToLower(c) - 97) + key_b) % 26) + 97;
                    encrypted_output_msg += Char.IsUpper(c) ? Char.ToUpper((char)shiftedChar) : (char)shiftedChar;
                }
                else
                {
                    encrypted_output_msg += c;
                }
            }
            return encrypted_output_msg;
        }

        public static string AFFINE_DECRYPTED(string input_encrypted_msg, int key_a, int key_b)
        {
            string decrypted_output_msg = "";
            int aInv = 0;
            for (int i = 1; i < 26; i++)
            {
                if ((key_a * i) % 26 == 1)
                {
                    aInv = i;
                    break;
                }
            }
            foreach (char c in input_encrypted_msg)
            {
                if (Char.IsLetter(c))
                {
                    int shiftedChar = ((aInv * ((int)Char.ToLower(c) - 97 - key_b + 26)) % 26) + 97;
                    decrypted_output_msg += Char.IsUpper(c) ? Char.ToUpper((char)shiftedChar) : (char)shiftedChar;
                }
                else
                {
                    decrypted_output_msg += c;
                }
            }

            return decrypted_output_msg;
        }


    }

}
