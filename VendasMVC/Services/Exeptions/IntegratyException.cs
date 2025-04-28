using System;

namespace VendasMVC.Services.Exeptions
{
    public class IntegratyException : ApplicationException
    {
        public IntegratyException(string message) : base(message)
        {

        }
    }
}
