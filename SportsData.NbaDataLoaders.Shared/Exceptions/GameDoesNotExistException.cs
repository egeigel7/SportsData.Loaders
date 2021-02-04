using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Exceptions
{
    public class GameDoesNotExistException: Exception
    {
        private string _message;
        public GameDoesNotExistException(string message)
        {
            _message = message;
        }
        public override string Message
        {
            get { return _message; }
        }
    }
}
