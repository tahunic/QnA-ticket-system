﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QA.Web.Security
{
    public class SessionPersister
    {
        private static string usernameSessionvar = "username";

        public static string username
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionVar = HttpContext.Current.Session[usernameSessionvar];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }
            set { HttpContext.Current.Session[usernameSessionvar] = value; }
        }
    }
}