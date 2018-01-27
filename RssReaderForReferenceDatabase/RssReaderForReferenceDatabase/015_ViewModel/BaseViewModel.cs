using RssReaderForReferenceDatabase._020_Common;
using RssReaderForReferenceDatabase._025_Class;
using RssReaderForReferenceDatabase._035_Enum;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

/// <summary>
/// RssReaderForReferenceDatabase._015_ViewModel
/// </summary>
namespace RssReaderForReferenceDatabase._015_ViewModel
{
    /// <summary>
    /// BaseViewModel
    /// </summary>
    public class BaseViewModel
        : INotifyPropertyChanged
    {
        #region Field

        #region DataSource
        /// <summary>
        /// パン屑リストにて使用
        /// </summary>
        private ObservableCollection<EntityViewTitleHierarchy> titleList;
        /// <summary>
        /// パン屑リストにて使用
        /// </summary>
        public ObservableCollection<EntityViewTitleHierarchy> TitleList
        {
            get
            {
                if (titleList == null)
                {
                    titleList = new ObservableCollection<EntityViewTitleHierarchy>();
                }

                return this.titleList;
            }

            set
            {
                this.titleList = value;
                this.RaisePropertyChanged(nameof(TitleList));
                this.RaisePropertyChanged(nameof(IsSameTitle));
            }
        }
        #endregion DataSource

        #region Property

        /// <summary>
        /// windowTitle
        /// </summary>
        private string windowTitle = string.Empty;
        /// <summary>
        /// WindowTitle
        /// </summary>
        public string WindowTitle
        {
            get
            {
                return this.windowTitle;
            }

            set
            {
                this.windowTitle = value;
                this.RaisePropertyChanged(nameof(WindowTitle));
                this.RaisePropertyChanged(nameof(IsSameTitle));
            }
        }

        #region FlagBehaviorClose
        /// <summary>
        /// flagBehaviorClose
        /// </summary>
        private bool flagBehaviorClose = false;
        /// <summary>
        /// FlagBehaviorClose
        /// </summary>
        public bool FlagBehaviorClose
        {
            get
            {
                return this.flagBehaviorClose;
            }

            set
            {
                this.flagBehaviorClose = value;
                this.RaisePropertyChanged("FlagBehaviorClose");
            }
        }
        #endregion

        #region CommandClose
        /// <summary>
        /// commandClose
        /// </summary>
        private DelegateCommand commandClose;
        /// <summary>
        /// CommandClose
        /// </summary>
        public DelegateCommand CommandClose
        {
            get
            {
                if (this.commandClose == null)
                {
                    this.commandClose = new DelegateCommand(CloseForm, CanCloseForm);
                }
                return commandClose;
            }
            set { commandClose = value; }
        }
        #endregion

        #region CommandJumpForOtherForm
        /// <summary>
        /// commandJumpForOtherForm
        /// </summary>
        private DelegateCommandJenerics<NameTitle> commandJumpForOtherForm;
        /// <summary>
        /// CommandJumpForOtherForm
        /// </summary>
        public DelegateCommandJenerics<NameTitle> CommandJumpForOtherForm
        {
            get
            {
                if (commandJumpForOtherForm == null)
                {
                    commandJumpForOtherForm =
                        new DelegateCommandJenerics<NameTitle>(WalkForNearForm, CanWalkForNearForm);
                }

                return commandJumpForOtherForm;
            }
            set { commandJumpForOtherForm = value; }
        }
        #endregion

        #region Event
        /// <summary>
        /// プロパティの変更時に発行
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion Event

        #endregion Property

        #endregion Field

        #region Method

        #region IsTitle
        /// <summary>
        /// IsTitle
        /// </summary>
        public bool IsSameTitle { get { return titleList[titleList.Count - 1].Title == windowTitle; } }
        #endregion IsTitle

        #region RaisePropertyChanged
        /// <summary>
        /// PropertyChangedイベント発行
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        protected virtual void RaisePropertyChanged(string propertyName)
            => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        #region CloseForm
        /// <summary>
        /// CloseForm
        /// </summary>
        private void CloseForm()
        {
            this.FlagBehaviorClose = true;
        }

        /// <summary>
        /// CanCloseForm
        /// </summary>
        /// <returns></returns>
        protected bool CanCloseForm()
        {
            return true;
        }
        #endregion

        #region Teleport
        /// <summary>
        /// TeleportForOtherForm
        /// </summary>
        /// <param name="target"></param>
        private void TeleportForOtherForm(NameTitle target)
        {
            //
            WalkForNearForm(target);
        }
        /// <summary>
        /// CanTeleportForOtherForm
        /// </summary>
        /// <returns></returns>
        private bool CanTeleportForOtherForm()
        {
            return true;
        }
        #endregion

        #region WalkForNearForm
        /// <summary>
        /// WalkForNearForm
        /// </summary>
        /// <param name="target"></param>
        private void WalkForNearForm(NameTitle target)
        {
            Window ins = null;
            var a = new BaseViewModel() { TitleList = this.TitleList };

            switch (target)
            {
                case NameTitle.Title:
                    ins = new _010_View.Title
                    {
                        DataContext = new TitleViewModel()
                    };
                    break;
                case NameTitle.Config:
                    ins = new _010_View.ConfigApp
                    {
                        DataContext = new ConfigViewModel()
                    };
                    break;
                case NameTitle.Main:
                    ins = new _010_View.Main
                    {
                        DataContext = new MainViewModel()
                    };
                    break;
                default:
                    return;
            }

            if (true)
            {

            }
            else
            {

            }

            var insDataContext = (BaseViewModel)ins.DataContext;
            this.TitleList.Add(insDataContext.TitleList[0]);
            insDataContext.TitleList = this.TitleList;
            ins.Show();

            this.FlagBehaviorClose = true;
        }
        /// <summary>
        /// CanJumpForNearForm
        /// </summary>
        /// <returns></returns>
        private bool CanWalkForNearForm()
        {
            return true;
        }
        #endregion

        #endregion Method

    }
}
