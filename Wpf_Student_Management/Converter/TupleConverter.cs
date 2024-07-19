using System.Globalization;
using System.Windows.Data;

namespace Wpf_Student_Management.Converter
{
    public class TupleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2)
            {
                return Tuple.Create(values[0], values[1]);
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

