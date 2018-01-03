
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
        private string title = "title";
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
        public TitleViewModel()
        {
            TitleList.Add(item: new _025_Class.EntityViewTitleHierarchy() { Title = title });
        }
        #endregion
    }
}
