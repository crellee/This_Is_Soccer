﻿using System.Web;
using System.Web.Mvc;

namespace This_Is_Soccer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
