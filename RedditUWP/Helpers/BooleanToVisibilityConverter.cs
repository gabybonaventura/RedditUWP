using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace RedditUWP.Helpers
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        #region Properties
        public Visibility OnTrue { get; set; }
        public Visibility OnFalse { get; set; }
        #endregion
        #region Constructors
        public BooleanToVisibilityConverter()
        {
            OnFalse = Visibility.Collapsed;
            OnTrue = Visibility.Visible;
        }
        #endregion
        #region Methods
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var v = (bool)value;
            Console.WriteLine(v);

            return v ? OnTrue : OnFalse;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is Visibility == false)
                return DependencyProperty.UnsetValue;

            if ((Visibility)value == OnTrue)
                return true;
            else
                return false;
        }
        #endregion
    }
}