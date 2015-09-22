using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        MissingFROMClause
    }
}