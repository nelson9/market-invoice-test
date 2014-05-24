using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace MvcApplication2.Helpers
{
    public static class HtmlHelpersExtension
    {
        public static IHtmlString camelCase(this HtmlHelper helper, string camel)
        {
            if (string.IsNullOrEmpty(camel))
            {
                return MvcHtmlString.Empty;
            }

            string returnCamel;
            returnCamel = Regex.Replace(camel, "(\\B[A-Z])", " $1");

            return new HtmlString(returnCamel);
        }
    }
}