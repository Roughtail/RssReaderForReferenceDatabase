using System.Data;
using System.Linq;
using System.Threading;
using System.Windows;
using System;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RssReaderForReferenceDatabase.Properties;

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

        #region Enum

        #region StartUpTitle
        /// <summary>
        /// StartUpTitle
        /// <para>拡張性を考慮し、シード5で連番付与</para>
        /// </summary>
        private enum StartUpTitle
        {
            /// <summary>
            /// 予定外
            /// </summary>
            AAA_Unknown = 0,
            /// <summary>
            /// 初期起動時の画面
            /// </summary>
            AAF_Title = 5,
            /// <summary>
            /// 設定画面
            /// </summary>
            AAK_Config = 10,
            /// <summary>
            /// バイナリ削除時画面
            /// </summary>
            AAP_Uninstall = 15,
            /// <summary>
            /// コンテンツ画面
            /// </summary>
            AAU_Main = 20
        }
        #endregion

        #endregion Enum

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

#if DEBUG == false
            //memo
            //Mutex のコンストラクタに指定する文字列は、他のアプリケーションと重複するとそれらの起動チェックに影響するので GUID を指定する。重複回避としては GUID で十分だけど、私は念のためにアプリ名も入れておく。
//Visual Studio のインストール フォルダを $ とすると “$\Common7\Tools” というフォルダに guidgen.exe という名前のツールがあり、これで GUID を生成できる。
//Mutex を検出したときは先に起動しているアプリがあるので、すぐにプロセスを終了する。このチェックを通過したなら、メインウィンドウを表示する。

            globalVoMutex = new Mutex(false, "");
            if (globalVoMutex.WaitOne(0,false) == false)
            {
                globalVoMutex.Dispose();
                this.Shutdown();
                return;
            }
#endif

                if (IsArgument(e: e) == true)
                {
                    ProcessArgument(e);
                    return;
                }

                ExecuteSystem ins = WakeUpDefaultWindow;
                {
                    int.TryParse(Settings.Default.StartUpTitle, out int work);
                    switch ((StartUpTitle)work)
                    {
                        case StartUpTitle.AAA_Unknown:
                            SetStartupTitle(StartUpTitle.AAF_Title);
                            ins = WakeUpDefaultWindow;
                            break;
                        case StartUpTitle.AAF_Title:
                            ins = WakeUpMainWindow;
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
                if (ins == null)
                {
                    return;
                }

                ins();
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
