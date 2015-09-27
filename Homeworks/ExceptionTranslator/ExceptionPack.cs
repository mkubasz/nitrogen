namespace ExceptionTranslator
{
    public enum ExceptionsPack
    {
        JustError,
        ObjectIsNULL,

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