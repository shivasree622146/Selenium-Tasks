using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMSauceDemo.CustomExceptions
{
    public class CheckFilePathException : Exception
    {
        public CheckFilePathException() : base() { }
        public CheckFilePathException(string message) : base(message) { }
    }
}
