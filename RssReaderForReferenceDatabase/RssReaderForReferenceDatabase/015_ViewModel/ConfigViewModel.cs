using RssReaderForReferenceDatabase._025_Class;
using RssReaderForReferenceDatabase._035_Enum;

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
                this.RaisePropertyChanged("WindowTitle");
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ConfigViewModel()
        {
            TitleList.Add(item: new EntityViewTitleHierarchy()
            {
                Title = windowTitle
                ,
                NameTitle = NameTitle.Config
            });
        }
        #endregion
    }
}
