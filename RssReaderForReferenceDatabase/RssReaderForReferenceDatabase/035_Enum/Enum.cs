

/// <summary>
/// RssReaderForReferenceDatabase._035_Enum
/// </summary>
namespace RssReaderForReferenceDatabase._035_Enum
{
    #region Others
    /// <summary>
    /// Others
    /// </summary>
    public enum Others
    {
        /// <summary>
        /// 
        /// </summary>
        Nothing = -1
    }
    #endregion
    #region NameProcess
    /// <summary>
    /// NameCommonProcess
    /// </summary>
    public enum NameCommonProcess
    {
        /// <summary>
        /// 
        /// </summary>
        TeleportForOtherForm,
        /// <summary>
        /// 
        /// </summary>
        CloseForm,
        /// <summary>
        /// DoNothing
        /// </summary>
        DoNothing
    }
    #endregion

    #region NameTitle
    /// <summary>
    /// NameTitle
    /// </summary>
    public enum NameTitle
    {
        /// <summary>
        /// 
        /// </summary>
        Title,
        /// <summary>
        /// 
        /// </summary>
        Config,
        /// <summary>
        /// 
        /// </summary>
        Main,
        /// <summary>
        /// 
        /// </summary>
        Uninstall
    }
    #endregion

    #region StartUpTitle
    /// <summary>
    /// StartUpTitle
    /// <para>拡張性を考慮し、シード5で連番付与</para>
    /// </summary>
    public enum StartUpTitle
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
}
