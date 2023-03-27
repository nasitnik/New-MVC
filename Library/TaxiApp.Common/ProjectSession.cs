using System.Web;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;

namespace TaxiApp.Common
{
    public class ProjectSession
    {
        public static int AdminId
        {
            get
            {
                if (HttpContext.Current.Session["AdminId"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["AdminId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AdminId"] = value;
            }
        }

        public static string AdminName
        {
            get
            {
                if (HttpContext.Current.Session["AdminName"] == "")
                {
                    return "-";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["AdminName"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AdminName"] = value;
            }
        }

    }
}