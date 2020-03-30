using System;

namespace VendasWebMVC.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException (string massage) : base(massage)
        {
        }
    }
}
