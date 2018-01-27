using RssReaderForReferenceDatabase._025_Class;
using RssReaderForReferenceDatabase._035_Enum;

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
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public TitleViewModel()
        {
            this.WindowTitle = "Title";
            TitleList.Add(item: new EntityViewTitleHierarchy()
            {
                Title = this.WindowTitle
                ,
                NameTitle = NameTitle.Title
            });
        }
        #endregion
    }
}
