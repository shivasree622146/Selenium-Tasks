using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPassword
{
    public class Password1
    {
        static void Main(string[] args)
        {
            Password1 obj = new Password1();
            string str = "hello1234567";
            Console.WriteLine(obj.IsValidPassword(str));
            //string s = "";
            //Console.WriteLine(IsValidPassword(s));

        }
        public bool IsValidPassword(string str)
        {
            return str.Length < 13 && str.Length > 8;
        }
      
    }
}
