using RssReaderForReferenceDatabase._035_Enum;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

/// <summary>
/// RssReaderForReferenceDatabase._025_Class
/// </summary>
namespace RssReaderForReferenceDatabase._025_Class
{
    /// <summary>
    /// EqualConverter : IMultiValueConverter
    /// </summary>
    class EqualConverter : IMultiValueConverter
    {
        #region IMultiValueConverter.Convert
        /// <summary>
        /// IMultiValueConverter.Convert
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        object IMultiValueConverter.Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var target = (ObservableCollection<EntityViewTitleHierarchy>)values[2];
                if (target[(int)values[0]].Title == Convert.ToString(values[1]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region IMultiValueConverter.ConvertBack
        /// <summary>
        /// 使用想定せず
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetTypes"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    /// <summary>
    /// ArrayConverter : IMultiValueConverter
    /// </summary>
    class ArrayConverter : IMultiValueConverter
    {
        #region IMultiValueConverter.Convert
        /// <summary>
        /// IMultiValueConverter.Convert
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        object IMultiValueConverter.Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return NameTitle.Title;
        }
        #endregion

        #region IMultiValueConverter.ConvertBack
        /// <summary>
        /// 使用想定せず
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetTypes"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}
