using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Exceptions
{
    public class IncorrectGameStatusException: Exception
    {
        private string _message;
        public IncorrectGameStatusException(string message)
        {
            _message = message;
        }
        public override string Message
        {
            get { return _message; }
        }
    }
}
