using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;
using ReactiveUIIEnumerableInCommandParameter.ViewModels;

namespace ReactiveUIIEnumerableInCommandParameter.Converters
{
    public class IEnumerableToList:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<Element> enumerable)
                return enumerable.ToList();
            
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}