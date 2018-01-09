

/// <summary>
/// RssReaderForReferenceDatabase._015_ViewModel
/// </summary>
namespace RssReaderForReferenceDatabase._015_ViewModel
{
    /// <summary>
    /// TitleViewModel
    /// </summary>
    public class TitleViewModel
        : BaseViewModel
    {
        #region Field
        private string windowTitle = "title";
        public string WindowTitle
        {
            get
            {
                return this.windowTitle;
            }

            set
            {
                this.windowTitle = value;
                this.RaisePropertyChanged("WindowTitle");
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public TitleViewModel()
        {
            TitleList.Add(item: new _025_Class.EntityViewTitleHierarchy() { Title = windowTitle });
        }
        #endregion
    }
}
