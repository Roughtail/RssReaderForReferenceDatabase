using RssReaderForReferenceDatabase.Properties;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows;
using RssReaderForReferenceDatabase._035_Enum;

/// <summary>
/// RssReaderForReferenceDatabase
/// </summary>
namespace RssReaderForReferenceDatabase
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App
        : Application
    {
        #region GlobalVariable
        /// <summary>
        /// Mutex
        /// </summary>
        private static Mutex globalVaMutex = null;
        #endregion GlobalVariable

        #region Delegate

        #region ExecuteSystem
        /// <summary>
        /// ExecuteSystem
        /// </summary>
        private delegate void ExecuteSystem();
        #endregion

        #endregion Delegate

        #region Event

        #region Application_Startup
        /// <summary>
        /// 実行時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                if (IsArgument(e: e) == true)
                {
                    ProcessArgument(e);
                    return;
                }

                ExecuteSystem instance = WakeUpDefaultWindow;

                {
                    int.TryParse(Settings.Default.StartUpTitle, out int work);
                    switch ((StartUpTitle)work)
                    {
                        case StartUpTitle.AAA_Unknown:
                            SetStartupTitle(StartUpTitle.AAF_Title);
                            instance = WakeUpDefaultWindow;
                            break;
                        case StartUpTitle.AAF_Title:
                            instance = WakeUpMainWindow;
                            break;
                        case StartUpTitle.AAK_Config:

                            break;
                        case StartUpTitle.AAP_Uninstall:

                            break;
                        case StartUpTitle.AAU_Main:

                            break;
                        default:
                            throw new Exception();
                    }
                }

                if (instance == null)
                {
                    return;
                }

                instance();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Application_Exit
        /// <summary>
        /// Application_Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            if (globalVaMutex == null)
            {
                return;
            }
            globalVaMutex.ReleaseMutex();
            globalVaMutex.Dispose();
        }
        #endregion

        #endregion Event

        #region Method

        #region SetStartupTitle
        /// <summary>
        /// SetStartupTitle
        /// </summary>
        /// <param name="target"></param>
        private void SetStartupTitle(StartUpTitle target)
        {
            Settings.Default.StartUpTitle
                = Convert.ToString(target);
            Settings.Default.Save();
        }
        #endregion

        #region WakeUpDefaultWindow
        /// <summary>
        /// WakeUpDefaultWindow
        /// </summary>
        private void WakeUpDefaultWindow()
        {
            WakeUpTitleWindow();
        }
        #endregion

        #region WakeUpMainWindow
        /// <summary>
        /// WakeUpMainWindow
        /// </summary>
        private void WakeUpMainWindow()
        {
            var ins = new _010_View.Main
            {
                DataContext = new _015_ViewModel.MainViewModel()
            };
            ins.Show();
        }
        #endregion

        #region WakeUpTitleWindow
        /// <summary>
        /// WakeUpTitleWindow
        /// </summary>
        private void WakeUpTitleWindow()
        {
            var ins = new _010_View.Title
            {
                DataContext = new _015_ViewModel.TitleViewModel()
            };
            ins.Show();
        }
        #endregion

        #region IsArgument
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool IsArgument(StartupEventArgs e)
        {
            if (e.Args == null)
            {
                return false;
            }

            if (e.Args.Count() == 0)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region ProcessArgument
        /// <summary>
        /// ProcessArgument
        /// </summary>
        /// <param name="e"></param>
        private void ProcessArgument(StartupEventArgs e)
        {
            #region ProcessArgument

            var targetForeach =
                e.Args.Select((value, count) => new { value = value, count = count });
            foreach (var item in targetForeach)
            {
                switch (item.value)
                {
                    default:
                        break;
                }
            }
            #endregion
        }
        #endregion

        #endregion Method

    }
}
