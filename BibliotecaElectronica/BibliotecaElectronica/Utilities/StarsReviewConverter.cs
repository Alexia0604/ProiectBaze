using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace BibliotecaElectronica.Utilities
{
    public class StarReviewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int starCount && starCount >5)
            {
                return new SolidColorBrush(Colors.Gold); // Culoare gold când valoarea este 6
            }
            else if (value is bool isFilled && isFilled)
            {
                return new SolidColorBrush(Colors.Gold); // Culoare gold când steaua este activă
            }
            return new SolidColorBrush(Colors.Gray); // Culoare gray atunci când nu este activă
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
