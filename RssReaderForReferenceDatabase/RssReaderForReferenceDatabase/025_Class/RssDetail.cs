using System.Collections.Generic;
using System.Linq;

/// <summary>
/// RssReaderForReferenceDatabase._025_Class
/// </summary>
namespace RssReaderForReferenceDatabase._025_Class
{
    #region RssDetail
    /// <summary>
    /// RssDetail
    /// </summary>
    public class RssDetail
    {
        #region MyProperty
        /// <summary>
        /// 日付を唯一性IDとする
        /// </summary>
        public string ID { get; set; }
        public string Title { get; set; }
        public string PubDate { get; set; }
        public List<string> categories { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RssDetail()
        {
            foreach (var item in GetType()
                                 .GetProperties()
                                 .Where(x => x.GetType() == typeof(string)))
            {
                item.SetValue(null, string.Empty);
            }
            foreach (var item in GetType()
                                .GetProperties()
                                .Where(x => x.GetType() == typeof(List<string>)))
            {
                item.SetValue(null, null);
            }
        }
        #endregion
    }
    #endregion RssDetail
}
