using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BibliotecaElectronica.Utilities
{
    public class PercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                return 0; 
            }

            int numberOfRatings = (int)value;
            int totalRatings = int.Parse(parameter.ToString());
            if (totalRatings == 0) return 0;
            return (double)numberOfRatings / totalRatings * 100;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
