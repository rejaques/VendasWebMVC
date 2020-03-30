using System;

namespace VendasWebMVC.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string massage) : base(massage)
        {
        }
    }
}
