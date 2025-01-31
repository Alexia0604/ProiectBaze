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
                return new SolidColorBrush(Colors.Gold); // Culoare gold cand valoarea este 6
            }
            else if (value is bool isFilled && isFilled)
            {
                return new SolidColorBrush(Colors.Gold); // Culoare gold cand steaua este activă
            }
            return new SolidColorBrush(Colors.Gray); // Culoare gray atunci cand nu este activă
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
