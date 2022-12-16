using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMSauceDemo
{
    public class PageUtilityClass
    {
       public string browserName = ConfigurationManager.AppSettings["browser"];
       public string userName = ConfigurationManager.AppSettings["username"];
       public string passWord = ConfigurationManager.AppSettings["password"];
       public string sauceUrl = ConfigurationManager.AppSettings["url"];
       public string firstName = ConfigurationManager.AppSettings["firstname"];
       public string lastName = ConfigurationManager.AppSettings["lastname"];
       public string pinCode = ConfigurationManager.AppSettings["pincode"];
    }
}
