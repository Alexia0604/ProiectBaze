using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;


namespace BibliotecaElectronica.Utilities
{
    public class Utility
    {
        public void gotFocus(object sender)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                txt.Text = "";
                txt.Foreground = new SolidColorBrush(Colors.Black); // Schimbă culoarea textului la negru
                txt.FontStyle = FontStyles.Normal; // Elimină stilul italic
            }
        }

        public void lostFocus(object sender,string _field) 
        {
            TextBox txt = sender as TextBox;
            if (txt != null && string.IsNullOrEmpty(txt.Text))
            {
                txt.Text = _field;
                txt.Foreground = new SolidColorBrush(Colors.Gray);
                txt.FontStyle = FontStyles.Italic;
            }
        }

        public string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
}
