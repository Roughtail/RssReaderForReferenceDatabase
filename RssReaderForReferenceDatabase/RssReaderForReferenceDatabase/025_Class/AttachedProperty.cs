using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

/// <summary>
/// RssReaderForReferenceDatabase._025_Class
/// </summary>
namespace RssReaderForReferenceDatabase._025_Class
{
    public class AttachedProperty
    {
        #region Property
        /// <summary>
        /// GetMyProperty
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetBehaviorCloseProperty(DependencyObject obj)
        {
            return (bool)obj.GetValue(BehaviorCloseProperty);
        }

        /// <summary>
        /// SetMyProperty
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetBehaviorCloseProperty(DependencyObject obj, bool value)
        {
            obj.SetValue(BehaviorCloseProperty, value);
        }

        /// <summary>
        /// FlagBehaviorCloseProperty
        /// </summary>
        public static readonly DependencyProperty BehaviorCloseProperty
            = DependencyProperty.RegisterAttached
            (
                "BehaviorCloseProperty"
                , typeof(bool)
                , typeof(AttachedProperty)
                , new PropertyMetadata(false, OnCloseChanged)
                );
        #endregion

        #region Event
        /// <summary>
        /// OnCloseChanged
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnCloseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var win = d as Window;
            if (win == null)
            {
                win = Window.GetWindow(d);
            }

            if (GetBehaviorCloseProperty(d))
            {
                win.Close();
            }
        }
        #endregion
    }
}
