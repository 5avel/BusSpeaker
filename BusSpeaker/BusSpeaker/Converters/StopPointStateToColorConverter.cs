using BusSpeaker.Models;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BusSpeaker.Converters
{
    public class StopPointStateToColorConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var state = (StopPointState)value;

            if (state.HasFlag(StopPointState.Current))
            {
                
                return Color.Yellow;
            }
            else if (state.HasFlag(StopPointState.Visited))
            {
                return Color.Blue;
            }
            else
            {
                return Color.Gray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Only one way bindings are supported with this converter");
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
