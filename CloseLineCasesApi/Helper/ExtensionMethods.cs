using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloseLineCasesApi
{
    public static class ExtensionMethods
    {
        public static string ToDefaultString(this object obj)
        {
            if (obj != null)
                return obj.ToString();

            return string.Empty;
        }
    }
}