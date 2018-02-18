using RssReaderForReferenceDatabase._020_Common;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

/// <summary>
/// RssReaderForReferenceDatabase._025_Class
/// </summary>
namespace RssReaderForReferenceDatabase._025_Class
{
    /// <summary>
    /// ErrorWriter
    /// </summary>
    public class ErrorWriter
    {
        #region Write
        /// <summary>
        /// Write
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="file"></param>
        /// <param name="line"></param>
        /// <param name="member"></param>
        public void Write(
            Exception ex,
            [CallerFilePath] string file = "",
            [CallerLineNumber] int line = 0,
            [CallerMemberName] string member = "")
        {
            bool restartFlag = true;
            int restartCount = 0;

            do
            {
                try
                {
                    #region Check
                    if (restartCount >= Constants.RetryCount)
                    {
                        return;
                    }
                    #endregion Check

                    #region OutputErrorLog
                    string path = string.Concat(
                            Environment.CurrentDirectory
                            , "/"
                            , Constants.ErrorLogName);

                    string contents = string.Concat(
                            "【"
                            , DateTime.Now
                            , "】"
                            , ex.Message
                            , ","
                            , file
                            , ","
                            , line
                            , ","
                            , member
                            , ","
                            , string.IsNullOrEmpty(ex.StackTrace) == true ? "StackTrace is nothing" : ex.StackTrace
                            , Environment.NewLine);

                    File.AppendAllText(
                        path: path
                        , contents: contents
                        , encoding: Encoding.UTF8);

                    #endregion OutputErrorLog

                    restartFlag = false;
                }
                catch (Exception deepEx)
                {
                    #region something is happening
                    if (deepEx is IOException)
                    {
                        restartCount++;
                    }
                    else
                    {
                        //There is nothing We can do...
                        restartFlag = false;
                    }
                    #endregion something is happening
                }
            } while (restartFlag == true);
        }
        #endregion Write

        #region Message
        /// <summary>
        /// Message
        /// </summary>
        public void Message()
        {
            MessageBox.Show(Constants.SystemMessageNotifyError);
        }
        #endregion
    }
}
