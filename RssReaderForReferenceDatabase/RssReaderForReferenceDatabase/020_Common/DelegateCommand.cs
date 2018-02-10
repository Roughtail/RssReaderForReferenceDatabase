using System;
using System.Windows.Input;

/// <summary>
/// RssReaderForReferenceDatabase._020_Common
/// </summary>
namespace RssReaderForReferenceDatabase._020_Common
{
    /// <summary>
    /// DelegateCommand
    /// </summary>
    public class DelegateCommand
        : ICommand
    {
        #region Field
        /// <summary>
        /// Constructorでコマンドが用意される
        /// </summary>
        private readonly Action execute;
        /// <summary>
        /// Constructorで準備されたコマンドが実行可能かどうか
        /// </summary>
        private readonly Func<bool> canExecute;
        #endregion

        #region Constructor
        /// <summary>
        /// コマンドのExecuteメソッドで実行する処理を指定し、
        /// <para>DelegateCommandのインスタンスを</para>
        /// <para>作成します。</para>
        /// </summary>
        /// <param name="execute">Executeメソッドで実行する処理</param>
        public DelegateCommand(Action execute)
            : this(execute, () => true) { }

        /// <summary>
        /// コマンドのExecuteメソッドで実行する処理と
        /// <para>CanExecuteメソッドで実行する処理を指定して</para>
        /// <para>DelegateCommandのインスタンスを作成します。</para>
        /// </summary>
        /// <param name="execute">Executeメソッドで実行する処理</param>
        /// <param name="canExecute">CanExecuteメソッドで実行する処理</param>
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");
            this.canExecute = canExecute ?? throw new ArgumentNullException("canExecute");
        }
        #endregion

        #region Method
        /// <summary>
        /// Constructorで準備されたコマンドを実行します。
        /// </summary>
        public void Execute()
        {
            this.execute();
        }

        /// <summary>
        /// Constructorで準備されたコマンドが
        /// <para>実行可能な状態かどうか問い合わせます。</para>
        /// </summary>
        /// <returns>実行可能な場合はtrue</returns>
        public bool CanExecute()
        {
            return this.canExecute();
        }
        #endregion

        #region EventHandler
        /// <summary>
        /// EventHandler｢CanExecuteChanged｣実装
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        #endregion

        #region FromInterface
        /// <summary>
        /// Interface｢ICommand｣実装
        /// </summary>
        /// <param name="parameter"></param>
        void ICommand.Execute(object parameter)
        {
            this.Execute();
        }

        /// <summary>
        /// Interface｢ICommand｣実装
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecute();
        }
        #endregion
    }
}
