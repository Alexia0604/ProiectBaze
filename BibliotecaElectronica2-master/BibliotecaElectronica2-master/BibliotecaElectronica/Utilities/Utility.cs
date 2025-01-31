using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;



namespace BibliotecaElectronica.Utilities
{
    public class Utility
    {
        public int getMonthByName(string month)
        {
            switch (month)
            {
                case "ianuarie":
                    return 1;
                case "februarie":
                    return 2;
                case "martie":
                    return 3;
                case "aprilie":
                    return 4;
                case "mai":
                    return 5;
                case "iunie":
                    return 6;
                case "iulie":
                    return 7;
                case "august":
                    return 8;
                case "septembrie":
                    return 9;
                case "octombrie":
                    return 10;
                case "noiembrie":
                    return 11;
                case "decembrie":
                    return 12;
                default:
                    return 0;

            }
        }
        public bool IsValidDate(int year, int month, int day)
        {
            return year > 0 && month >= 1 && month <= 12 && day >= 1 && day <= DateTime.DaysInMonth(year, month);
        }
        public bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*(),.?"":{}|<>])[A-Za-z\d!@#$%^&*(),.?"":{}|<>]{8,}$";
            return Regex.IsMatch(password, pattern);
        }
        public bool IsValidNr(string nr)
        {
            string pattern = @"^(?:\+40|0040|0)?\s?[2-7][0-9]{2}[-.\s]?[0-9]{3}[-.\s]?[0-9]{3}$";
            return Regex.IsMatch(nr, pattern);
        }
        public bool IsValidUsername(string username)
        {
            var db = new BibliotecaElectronicaClassesDataContext();
            var persoana=db.Persoanas.Where(p=>p.Username==username).FirstOrDefault();
            if (persoana != null)
                return false;
            return true;
        }

        public void gotFocus(object sender)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                txt.Text = "";
           //     txt.FontWeight = FontWeights.Regular;
                txt.Foreground = new SolidColorBrush(Colors.Black); 
                txt.FontStyle = FontStyles.Normal; 
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
