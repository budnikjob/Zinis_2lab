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
    public class affine_cheaper
    {
        public static string AFFINE_ENCRYPTED(string input_msg, int key_a, int key_b)
        {
            string outputencr_msg = "";
            foreach (char c in input_msg)
            {
                if (Char.IsLetter(c))
                {
                    int shiftedChar = ((key_a * ((int)Char.ToLower(c) - 1071) + key_b) % 33) + 1071;
                    outputencr_msg += Char.IsUpper(c) ? Char.ToUpper((char)shiftedChar) : (char)shiftedChar;
                }
                else
                {
                    outputencr_msg += c;
                }
            }
            return outputencr_msg;
        }

        public static string AFFINE_DECRYPTED(string inputencr_msg, int key_a, int key_b)
        {
            string outputdecr_msg = "";
            int aInv = 0;

            for (int i = 1; i < 33; i++)
            {
                if ((key_a * i) % 33 == 1)
                {
                    aInv = i;
                    break;
                }
            }
            foreach (char c in inputencr_msg)
            {
                if (Char.IsLetter(c))
                {
                    int shiftedChar = ((aInv * ((int)Char.ToLower(c) - 1071 - key_b + 33)) % 33) + 1071;
                    outputdecr_msg += Char.IsUpper(c) ? Char.ToUpper((char)shiftedChar) : (char)shiftedChar;
                }
                else
                {
                    outputdecr_msg += c;
                }
            }

            return outputdecr_msg;
        }

    }

}
