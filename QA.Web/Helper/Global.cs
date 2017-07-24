using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace QA.Web.Helper
{
    public class Global
    {
        public static string ApiUrl { get { return ConfigurationManager.AppSettings["ApiUrlValue"]; } }
    }
}