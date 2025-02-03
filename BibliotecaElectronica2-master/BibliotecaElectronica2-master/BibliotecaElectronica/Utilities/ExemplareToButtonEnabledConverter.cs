using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BibliotecaElectronica.Utilities
{
    public class ExemplareToButtonEnabledConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
                return false;

            if (values[0] is int nrExemplare && values[1] is bool borrowed)
            {
                return nrExemplare > 0 && borrowed == true ;
            }

            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        //public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    if (value is int nrExemplare)
        //    {
        //        return nrExemplare > 0; 
        //    }
        //    return false; 
        //}

        //public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    return value; 
        //}
    }
}
