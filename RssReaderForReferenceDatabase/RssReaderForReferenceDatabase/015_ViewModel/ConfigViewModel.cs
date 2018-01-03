
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
        private string title = "Config";
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
                this.RaisePropertyChanged("Title");
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ConfigViewModel()
        {
            TitleList.Add(item: new _025_Class.EntityViewTitleHierarchy() { Title = title });
        }
        #endregion
    }
}
