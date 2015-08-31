using System;

namespace Startup.TrainingOneHomeworks.GroupMati.Pesel
{
    public class InvalidPeselExeptions : Exception
    {
        public InvalidPeselExeptions(string message)
            : base(message)
        { }
    }
}