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

        #region CommandDispatching
        /// <summary>
        /// commandDispatching
        /// </summary>
        private DelegateCommandJenerics<object> commandDispatching;
        /// <summary>
        /// CommandDispatching
        /// </summary>
        public DelegateCommandJenerics<object> CommandDispatching
        {
            get
            {
                if (commandDispatching == null)
                {
                    commandDispatching =
                        new DelegateCommandJenerics<object>(DispatchCommonProcess, CanDispatchCommonProcess);
                }
                return commandDispatching;
            }
            set
            { commandDispatching = value; }
        }
        #endregion

        //#region CommandJumpForOtherForm
        ///// <summary>
        ///// commandJumpForOtherForm
        ///// </summary>
        //private DelegateCommandJenerics<NameTitle> commandJumpForOtherForm;
        ///// <summary>
        ///// CommandJumpForOtherForm
        ///// </summary>
        //public DelegateCommandJenerics<NameTitle> CommandJumpForOtherForm
        //{
        //    get
        //    {
        //        if (commandJumpForOtherForm == null)
        //        {
        //            commandJumpForOtherForm =
        //                new DelegateCommandJenerics<NameTitle>(WalkForNearForm, CanWalkForNearForm);
        //        }

        //        return commandJumpForOtherForm;
        //    }
        //    set { commandJumpForOtherForm = value; }
        //}
        //#endregion

        #region Event
        /// <summary>
        /// プロパティの変更時に発行
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion Event

        #endregion Property

        #endregion Field

        #region Method

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
        #endregion

        #region Teleport
        /// <summary>
        /// TeleportForOtherForm
        /// </summary>
        /// <param name="target"></param>
        private void TeleportForOtherForm(object Arguments)
        {
            var arguments = Arguments as ArgumentsForTeleportManager;
            if (arguments == null)
            {
                return;
            }

            Window ins = null;
            var a = new BaseViewModel() { TitleList = this.TitleList };

            switch (arguments.WindowTitle)
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

            var insDataContext = (BaseViewModel)ins.DataContext;
            if (arguments.Index != (int)Others.Nothing)
            {
                for (int i = arguments.Index + 1; i < this.titleList.Count; i++)
                {
                    this.titleList.RemoveAt(i);
                }
            }
            else
            {
                this.TitleList.Add(insDataContext.TitleList[0]);
            }
                insDataContext.TitleList = this.TitleList;

            ins.Show();

            this.FlagBehaviorClose = true;
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

        #region DispatchCommonProcess
        /// <summary>
        /// DispatchCommonProcess
        /// </summary>
        /// <param name="Arguments"></param>
        protected virtual void DispatchCommonProcess(object Arguments)
        {
            //ユーザの希望処理電文を解析
            var argumentsData = Arguments as ArgumentsCommonProcessTarget;

            if (argumentsData is null)
            {
                return;
            }

            switch (argumentsData.NameCommonProcess)
            {
                //画面遷移
                case NameCommonProcess.TeleportForOtherForm:
                    TeleportForOtherForm(argumentsData.Data);
                    CloseForm();
                    break;

                case NameCommonProcess.CloseForm:
                    CloseForm();
                    break;

                case NameCommonProcess.DoNothing:
                default:
                    break;
            }
            return;
        }

        /// <summary>
        /// CanDispatchCommonProcess
        /// </summary>
        /// <returns></returns>
        private bool CanDispatchCommonProcess()
        {
            return true;
        }
        #endregion

        #endregion Method

    }
}
