namespace ExceptionTranslator
{
    public enum ExceptionsPack
    {
        JustError,

        FileNotFound,
        StringIsEmpty,
        FileNotExist,
        NoReadFilePermission,
        NoEditFilePermission,
        NoCreateFileInFolderPremision,
        DataReadOnly,

        InvalidSQLStatement,
        CloseingQuoteMissing,
        ExponentOutOfRange,
        MissingFromClause
    }
}