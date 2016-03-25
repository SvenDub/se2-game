using System;

namespace Ontwikkelopdracht_Game
{
    public class LevelLoadException : Exception
    {
        public LevelLoadException(Exception innerException) : base("The specified level could not be loaded.\n" + innerException.GetType().Name + ":\n" + innerException.Message, innerException)
        {
        }
    }
}