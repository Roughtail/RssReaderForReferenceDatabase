using System;
using System.Windows.Input;

/// <summary>
/// RssReaderForReferenceDatabase._020_Common
/// </summary>
namespace RssReaderForReferenceDatabase._020_Common
{
    /// <summary>
    /// DelegateCommandJenerics
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DelegateCommandJenerics<T>
        : ICommand
    {
        #region Field
        /// <summary>
        /// Constructorでコマンドが用意される
        /// </summary>
        private readonly Action<T> _execute;
        /// <summary>
        /// Constructorで準備されたコマンドが実行可能かどうか
        /// </summary>
        private readonly Func<bool> _canExecute;
        #endregion

        #region Constructor
        /// <summary>
        /// コマンドのExecuteメソッドで実行する処理を指定し、
        /// <para>DelegateCommandのインスタンスを</para>
        /// <para>作成します。</para>
        /// </summary>
        /// <param name="execute">Executeメソッドで実行する処理</param>
        public DelegateCommandJenerics(Action<T> execute)
            : this(execute, () => true) { }

        /// <summary>
        /// コマンドのExecuteメソッドで実行する処理と
        /// <para>CanExecuteメソッドで実行する処理を指定して</para>
        /// <para>DelegateCommandのインスタンスを作成します。</para>
        /// </summary>
        /// <param name="execute">Executeメソッドで実行する処理</param>
        /// <param name="canExecute">CanExecuteメソッドで実行する処理</param>
        public DelegateCommandJenerics(Action<T> execute, Func<bool> canExecute)
        {
            this._execute = execute ?? throw new ArgumentNullException("execute");
            this._canExecute = canExecute ?? throw new ArgumentNullException("canExecute");
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

        #region Method
        /// <summary>
        /// Interface｢ICommand｣実装
        /// <para>Constructorで準備されたコマンドを実行します。</para>
        /// </summary>
        /// <param name="parameter"></param>
        void ICommand.Execute(object parameter)
        {
            this._execute((T)parameter);
        }

        /// <summary>
        /// Interface｢ICommand｣実装
        /// <para>Constructorで準備されたコマンドが</para>
        /// <para>実行可能な状態かどうか問い合わせます。</para>
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool ICommand.CanExecute(object parameter)
        {
            return this._canExecute();
        }
        #endregion
    }
}
