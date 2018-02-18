
/// <summary>
/// RssReaderForReferenceDatabase._020_Common
/// </summary>
namespace RssReaderForReferenceDatabase._020_Common
{
    #region Constants
    /// <summary>
    /// Constants
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// ここで言うエラーとは、
        /// <para>処理続行不可の障害を指す。</para>
        /// </summary>
        public const string ErrorLogName = @"ErrorLog.txt";

        public const string RssFileName = @"GetRss.xml";

        public const string WorkRssFileName = @"WorkGetRss.xml";

        public const string RssURL = @"http://crd.ndl.go.jp/jp/public/rss2/rss.xml";

        public const string RssElementChannel = @"channel";
        public const string RssElementItem = @"item";
        public const string RssElementTitle = @"title";
        public const string RssElementPubDate = @"pubDate";
        public const string RssElementCategories = @"categories";
        public const string RssElementDescription = @"description";
        public const string RssElementLink = @"link";


        public const string ConfigFileName = @"ConfigRssReaderForReferenceDatabase.txt";
        public const string ConfElementGetRss = @"GetRss";
        public const string ConfElementDisplayMessage = @"DisplayMessage";
        public const string ConfExtension = @".txt";


        public const string UserAgent = @"Mozilla/5.0 (Windows NT 6.1) 
                                            AppleWebKit/537.36 (KHTML, like Gecko)
                                            Chrome/28.0.1500.63 Safari/537.36";
        public const string Accept = @"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";


        public const string SystemMessageGetRssError = @"何らかのエラーが発生している可能性があります。
                                                        しばらくこのメッセージが出続けている場合、アプリ提供者への連絡をお勧めします。
                                                        このメッセージは{0}回表示されました。";

        public const string SystemMessageNotifyError = @"エラーが発生しました。ログファイルに情報を記載しました。";

        public const ulong RequiredStrage = 10000000;
        public const byte RetryCount = 5;

        public const int DefaultRowCount = 30;
        public const int DefaultRowHeight = 20;
    }
    #endregion
}
