using System;

namespace Ontwikkelopdracht_Game
{
    public class LevelSaveException : Exception
    {
        public LevelSaveException(Exception innerException) : base("The specified level could not be saved.\n" + innerException.GetType().Name + ":\n" + innerException.Message, innerException)
        {
        }
    }
}