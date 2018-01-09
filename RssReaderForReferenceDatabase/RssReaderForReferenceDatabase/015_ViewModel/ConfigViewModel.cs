

/// <summary>
/// RssReaderForReferenceDatabase._015_ViewModel
/// </summary>
namespace RssReaderForReferenceDatabase._015_ViewModel
{
    /// <summary>
    /// ConfigViewModel
    /// </summary>
    public class ConfigViewModel
        : BaseViewModel
    {
        #region Field
        private string windowTitle = "Config";
        public string WindowTitle
        {
            get
            {
                return this.windowTitle;
            }

            set
            {
                this.windowTitle = value;
                this.RaisePropertyChanged("WindowTite");
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ConfigViewModel()
        {
            TitleList.Add(item: new _025_Class.EntityViewTitleHierarchy() { Title = windowTitle });
        }
        #endregion
    }
}
