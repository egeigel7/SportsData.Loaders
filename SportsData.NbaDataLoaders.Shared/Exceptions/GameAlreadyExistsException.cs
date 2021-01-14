using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Exceptions
{
    public class GameAlreadyExistsException: Exception
    {
        private string _message;
        public GameAlreadyExistsException(string message)
        {
            _message = message;
        }
        public override string Message
        {
            get { return _message; }
        }
    }
}
