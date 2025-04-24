using System;

namespace VendasMVC.Services.Exeptions
{
    public class NotFoudException : ApplicationException
    {
        public NotFoudException(string message) : base(message)
        {

        }
    }
}
