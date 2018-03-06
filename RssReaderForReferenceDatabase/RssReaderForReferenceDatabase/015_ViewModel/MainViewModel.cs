﻿using RssReaderForReferenceDatabase._020_Common;
using RssReaderForReferenceDatabase._025_Class;
using RssReaderForReferenceDatabase._035_Enum;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Xml.Linq;
using System.Windows.Threading;

/// <summary>
/// RssReaderForReferenceDatabase._015_ViewModel
/// </summary>
namespace RssReaderForReferenceDatabase._015_ViewModel
{
    /// <summary>
    /// MainViewModel
    /// </summary>
    public class MainViewModel
        : BaseViewModel
    {
        #region Field
        #region DataSource
        /// <summary>
        /// dataSource
        /// </summary>
        private ObservableCollection<RssDetail> dataSource;
        /// <summary>
        /// DataSource
        /// </summary>
        public ObservableCollection<RssDetail> DataSource
        {
            get
            {
                return this.dataSource;
            }

            set
            {
                this.dataSource = value;
                this.RaisePropertyChanged("DataSource");
            }
        }
        #endregion

        #region ProcessedDataSource
        /// <summary>
        /// processedDataSource
        /// </summary>
        private DockPanel processedDataSource;
        /// <summary>
        /// ProcessedDataSource
        /// </summary>
        public DockPanel ProcessedDataSource
        {
            get
            {
                return this.processedDataSource;
            }
            set
            {
                this.processedDataSource = value;
                this.RaisePropertyChanged("ProcessedDataSource");
            }
        }
        #endregion

        #region MaxRowCount
        /// <summary>
        /// maxRowCount
        /// </summary>
        private int maxRowCount = 30;
        /// <summary>
        /// MaxRowCount
        /// </summary>
        public int MaxRowCount
        {
            get
            {
                return this.maxRowCount;
            }

            set
            {
                this.maxRowCount = value;
                this.RaisePropertyChanged("MaxRowCount");
            }
        }
        #endregion

        #region NewLine
        /// <summary>
        /// newLine
        /// </summary>
        private bool newLine = true;
        /// <summary>
        /// NewLine
        /// </summary>
        public bool NewLine
        {
            get
            {
                return this.newLine;
            }

            set
            {
                this.newLine = value;
                this.RaisePropertyChanged("NewLine");
            }
        }
        #endregion
        #endregion Field

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MainViewModel()
        {
            this.WindowTitle = NameTitle.Main.ToString();
            TitleList.Add(item: new EntityViewTitleHierarchy()
            {
                Title = this.WindowTitle
                ,
                NameTitle = NameTitle.Main
            });
        }
        #endregion Constructor

        #region Command

        #region CommandCalculate
        /// <summary>
        /// calculateCommand
        /// </summary>
        private DelegateCommand commandCalculate;
        /// <summary>
        /// calculateCommand
        /// </summary>
        public DelegateCommand CommandCalculate
        {
            get
            {
                if (this.commandCalculate == null)
                {
                    this.commandCalculate
                        = new DelegateCommand(AcquisitionExecute, CanAcquisitionExecute);
                }

                return this.commandCalculate;
            }
        }
        #endregion CommandCalculate

        #region CommandShowDataYouGot
        /// <summary>
        /// commandShowDataYouGot
        /// </summary>
        private DelegateCommand commandShowDataYouGot { get; set; }
        /// <summary>
        /// CommandShowDataYouGot
        /// </summary>
        public DelegateCommand CommandShowDataYouGot
        {
            get
            {
                if (this.commandCalculate == null)
                {
                    this.commandCalculate
                        = new DelegateCommand(AcquisitionExecute, CanAcquisitionExecute);
                }

                return this.commandCalculate;
            }
        }
        #endregion

        #endregion Command

        #region Local Method

        /// <summary>
        /// 計算処理のコマンドの実行を行います。
        /// </summary>
        private void AcquisitionExecute()
        {
            #region データ取得
            //負荷対策
            if (true)
            {
                if (UpdateRssData() == false)
                {

                }
            }
            #endregion

            #region データ加工
            if (CheckAndProcessRss() == false)
            {

            }
            #endregion

            #region コンテンツ作成
            Dispatcher.CurrentDispatcher.BeginInvoke(
                new Action(() =>
                    {
                        CreateContentsControl();
                    }
                )
            );
            #endregion
        }
        /// <summary>
        /// 計算処理が実行可能かどうかの判定を行います。
        /// </summary>
        /// <returns></returns>
        private bool CanAcquisitionExecute()
        {
            return true;
        }

        /// <summary>
        /// 表示処理のコマンドの実行を行います。
        /// </summary>
        private void ShowingExecute()
        {
            #region データ加工
            if (CheckAndProcessRss() == false)
            {

            }
            #endregion

            #region コンテンツ作成
            Dispatcher.CurrentDispatcher.BeginInvoke(
                new Action(() =>
                {
                    CreateContentsControl();
                }
                )
            );
            #endregion
        }
        /// <summary>
        /// 表示処理が実行可能かどうかの判定を行います。
        /// </summary>
        /// <returns></returns>
        private bool CanShowingExecute()
        {
            return true;
        }

        #region UpdateRssData
        /// <summary>
        /// UpdateRssData
        /// <para>This method Update XMLData.</para>
        /// <para>UserAgentを指定し、確実に情報を取得する</para>
        /// </summary>
        /// <returns></returns>
        private bool UpdateRssData()
        {
            #region Get Rss
            if (GetRss() == false)
            {
                return false;
            }
            #endregion Get Rss

            #region 本番データが無い場合、最も高い可能性は初回の実行と推測される
            if (File.Exists(Constants.RssFileName) == false)
            {
                try
                {
                    File.Move(Constants.WorkRssFileName, Constants.RssFileName);
                }
                catch (Exception ex)
                {
                    var ew = new ErrorWriter();
                    ew.Write(ex);
                    ew.Message();

                    return false;
                }
                return true;
            }
            #endregion 本番データが無い場合で最も高い可能性は初回の実行と推測される

            #region Check&Save
            try
            {
                #region Load及びItem取得
                var workData
                    = XElement.Load(Constants.WorkRssFileName);
                var workElementChannel
                    = workData.Element(Constants.RssElementChannel);
                var originData
                    = XElement.Load(Constants.RssFileName);
                var originElementChannel
                    = originData.Element(Constants.RssElementChannel);
                #endregion Load及びItem取得

                #region 最新日比較
                //仮じゃないファイル最新Itemの日付と、仮ファイルの最新日を見ていく。
                var workDataItems = workElementChannel
                                    .Elements(Constants.RssElementItem)
                                    .OrderBy(x =>
                                        DateTime.Parse(x.Element(Constants.RssElementPubDate).Value.Replace(" JST", string.Empty)));

                var originDataFirst = originElementChannel
                                        .Elements(Constants.RssElementItem)
                                        .OrderByDescending(x =>
                                            DateTime.Parse(x.Element(Constants.RssElementPubDate).Value.Replace(" JST", string.Empty)))
                                        .FirstOrDefault();

                {
                    DateTime? work = null;
                    DateTime? origin = DateTime.Parse(originDataFirst.Element(Constants.RssElementPubDate).Value.Replace(" JST", string.Empty));
                    try
                    {
                        foreach (var nowItem in workDataItems)
                        {
                            work = DateTime.Parse(nowItem.Element(Constants.RssElementPubDate).Value.Replace(" JST", string.Empty));
                            switch (work.Value.CompareTo(origin))
                            {
                                case -1:
                                case 0:
                                default:
                                    continue;

                                case 1:
                                    originElementChannel.Add(nowItem);
                                    break;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        var ew = new ErrorWriter();
                        ew.Write(ex);
                        ew.Message();
                    }
                }
                #endregion 最新日比較

                #region 保存と削除
                originData.Save(Constants.RssFileName, SaveOptions.OmitDuplicateNamespaces);
                if (File.Exists(Constants.WorkRssFileName) == true)
                {
                    try
                    {
                        File.Delete(Constants.WorkRssFileName);
                    }
                    catch (Exception ex)
                    {
                        var ew = new ErrorWriter();
                        ew.Write(ex);
                        ew.Message();

                        return false;
                    }
                    return true;
                }
                #endregion 保存と削除

                return true;
            }
            catch (Exception ex)
            {
                var ew = new ErrorWriter();
                ew.Write(ex);
                ew.Message();

                return false;
            }
            #endregion Check&Save
        }
        #endregion UpdateRssData

        #region GetRss
        /// <summary>
        /// GetRss
        /// </summary>
        /// <returns></returns>
        private static bool GetRss()
        {
            try
            {
                #region インスタンス等設定
                var req = WebRequest.Create(Constants.RssURL)
                            as HttpWebRequest;
                req.UserAgent = Constants.UserAgent;
                req.Accept = Constants.Accept;
                req.CookieContainer = new CookieContainer();

                req.CookieContainer
                    .Add((new CookieContainer())
                            .GetCookies(req.RequestUri));
                #endregion

                #region 取得し、ファイルに仮保存する
                using (var res = (HttpWebResponse)req.GetResponse())
                using (var resSt = res.GetResponseStream())
                using (var sr = new StreamReader(resSt, Encoding.UTF8))
                {
                    if (File.Exists(Constants.WorkRssFileName) == false)
                    {
                        try
                        {
                            File.AppendAllText(
                                path: Constants.WorkRssFileName,
                                contents: sr.ReadToEnd(),
                                encoding: Encoding.UTF8);
                        }
                        catch (Exception ex)
                        {
                            var ew = new ErrorWriter();
                            ew.Write(ex);
                            ew.Message();
                        }
                    }

                }
                #endregion

                req = null;

                return true;
            }
            catch (Exception ex)
            {
                var ew = new ErrorWriter();
                ew.Write(ex);
                ew.Message();

                return false;
            }
        }
        #endregion GetRss

        #region ProcessRss
        /// <summary>
        /// ProcessRss
        /// </summary>
        /// <returns></returns>
        private bool CheckAndProcessRss()
        {
            #region ファイル存在チェック
            if (File.Exists(Constants.RssFileName) == false)
            {
                //log
                return false;
            }
            #endregion

            #region 変数宣言&チェック
            var originData
                = XElement.Load(Constants.RssFileName);
            var elementChannel
                = originData.Element(Constants.RssElementChannel)
                            .Elements(Constants.RssElementItem);

            #region 更新の是非チェック
            //#region MyRegion
            ////var ptData = ((sv.Content) as DockPanel);
            //if (DataSource != null)
            //{
            //    if (DataSource.Count() != 0
            //        && DateTime.Parse(DataSource.FirstOrDefault().PubDate.Replace(" JST", ""))
            //        .CompareTo(DateTime.Parse(elementChannel
            //                                    .LastOrDefault()
            //                                    .Element(Constants.RssElementPubDate)
            //                                    .Value.Replace(" JST", ""))) != -1)
            //    {
            //        return false;
            //    }
            //}
            //#endregion
            #endregion 更新の是非チェック

            RssDetail work = null;
            //int getAmount = DataSource == null ? Constants.DefaultRowCount
            int getAmount = DataSource == null ? maxRowCount
                : DataSource.Count;
            DataSource = new ObservableCollection<RssDetail>();
            #endregion 変数宣言&チェック

            #region クラス化
            foreach (var item in elementChannel
                .Reverse()
                .Take(getAmount)
                )
            {
                try
                {
                    work = new RssDetail();
                    #region check&save
                    #region ID
                    {
                        {
                            var result = item.Element(Constants.RssElementPubDate);
                            if (result != null && result.IsEmpty == false)
                            {
                                DateTime id = DateTime.Parse(item.Element(Constants.RssElementPubDate).Value.Replace(" JST", string.Empty));
                                work.ID = string.Concat(id.Year.ToString("0000")
                                                        , id.Month.ToString("00")
                                                        , id.Day.ToString("00")
                                                        , id.Hour.ToString("00")
                                                        , id.Minute.ToString("00")
                                                        , id.Second.ToString("00"));
                            }
                        }
                    }
                    #endregion
                    #region Title
                    {
                        var result = item.Element(Constants.RssElementTitle);
                        if (result != null && result.IsEmpty == false)
                        {
                            work.Title = item.Element(Constants.RssElementTitle).Value;
                        }
                    }
                    #endregion
                    #region PubDate
                    {
                        var result = item.Element(Constants.RssElementPubDate);
                        if (result != null && result.IsEmpty == false)
                        {
                            work.PubDate = item.Element(Constants.RssElementPubDate).Value;
                        }
                    }
                    #endregion
                    #region categories
                    {
                        var result = item.Elements(Constants.RssElementCategories);
                        if (result != null && result.Count() > 0)
                        {
                            foreach (var nowCategories in result)
                            {
                                if (nowCategories.IsEmpty == false)
                                {
                                    work.categories.Add(nowCategories.Value);
                                }
                            }
                        }
                    }
                    #endregion
                    #region Description
                    {
                        var result = item.Element(Constants.RssElementDescription);
                        if (result != null && result.IsEmpty == false)
                        {
                            work.Description = item.Element(Constants.RssElementDescription).Value;
                            if (this.newLine == true)
                            {
                                work.Description = work.Description
                                                    .Replace(Environment.NewLine, string.Empty)
                                                    .Replace("\r", string.Empty)
                                                    .Replace("\n", string.Empty);
                            }
                        }
                    }
                    #endregion
                    #region Link
                    {
                        var result = item.Element(Constants.RssElementLink);
                        if (result != null && result.IsEmpty == false)
                        {
                            work.Link = item.Element(Constants.RssElementLink).Value;
                        }
                    }
                    #endregion
                    #endregion check&save
                    DataSource.Add(work);
                }
                catch (Exception ex)
                {
                    var ew = new ErrorWriter();
                    ew.Write(ex);
                    ew.Message();
                }
            }
            #endregion クラス化

            #region 成否判定
            //失敗用クラスを作ってもいいかもしれない
            if (DataSource == null
                || DataSource.Count == 0)
            {
                return false;
            }
            return true;
            #endregion
        }
        #endregion

        #region CreateContentsControl
        /// <summary>
        /// CreateContentsControl
        /// </summary>
        /// <returns></returns>
        private bool CreateContentsControl()
        {
            var dockAll = new DockPanel
            {
                Background = new SolidColorBrush(Colors.Black)
            };
            foreach (var item in DataSource.Select((data, count) => new { data, count }))
            {
                #region DockPanel定義
                var dockInLoop = new DockPanel();

                #endregion DockPanel定義

                #region new Button_Detail
                dockInLoop.Children
                    .Add(new Button()
                    {
                        Content = "Detail"
                        ,
                        Width = 100
                        ,
                        Height = Constants.DefaultRowHeight
                        ,
                        Background = new SolidColorBrush(Colors.White)
                        ,
                        Visibility = Visibility.Visible
                        ,
                        Tag = item.count
                    });
                ((Button)dockInLoop.Children[dockInLoop.Children.Count - 1]).Click += new RoutedEventHandler(btnDetail_Click);
                #endregion Button_Detail

                #region new RichTextBox
                dockInLoop.Children
                    .Add(new RichTextBox()
                    {
                        Document = new FlowDocument(
                                    new Paragraph(
                                        new Run(
                                            item.data.Title
                                                .Replace(Environment.NewLine, string.Empty)
                                                .Replace(" ", string.Empty)
                                                .Replace("　", string.Empty))))
                        ,
                        //Width = 300
                        //,
                        Height = Constants.DefaultRowHeight
                        ,
                        Background = new SolidColorBrush(Colors.White)
                        ,
                        Visibility = Visibility.Visible
                        //,
                        //Margin = new Thickness(0, 0, 397.603, 0)
                    });
                #endregion

                #region SetDock
                DockPanel.SetDock(dockInLoop.Children[0], Dock.Left);
                //DockPanel.SetDock(dockInLoop.Children[1], Dock.Left);
                DockPanel.SetDock(dockInLoop, Dock.Top);
                #endregion SetDock

                dockAll.Children.Add(dockInLoop);
            }

            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                ProcessedDataSource = dockAll;
            }));

            return true;
        }
        #endregion CreateContentsControl

        #region btnDetail_Click
        /// <summary>
        /// btnDetail_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = int.Parse(Convert.ToString(((Button)sender).Tag));
                var row = dataSource[count];
                System.Diagnostics.Process.Start(@"chrome.exe", row.Link);
            }
            catch (Exception ex)
            {
                var ew = new ErrorWriter();
                ew.Write(ex);
                ew.Message();
            }
        }
        #endregion

        #endregion Local Method


    }
}
