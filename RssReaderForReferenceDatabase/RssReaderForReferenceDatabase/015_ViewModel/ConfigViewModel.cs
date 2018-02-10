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
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ConfigViewModel()
        {
            this.WindowTitle = NameTitle.Config.ToString();
            TitleList.Add(item: new EntityViewTitleHierarchy()
            {
                Title = this.WindowTitle
                ,
                NameTitle = NameTitle.Config
            });
        }
        #endregion
    }
}
