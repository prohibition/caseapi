using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace CloseLineCasesApi
{
    public static class RequestValidator
    {
        public static bool IsValid(this HttpRequestMessage request)
        {
            var headers = request.Headers;
            var tokens = Tokenlist();

            if (!headers.Contains("Token"))
                return false;

            var token = headers.GetValues("Token").First();

            return tokens.Contains(token, StringComparer.Ordinal);
        }

        private static List<String> Tokenlist()
        {
            List<string> tokens = new List<string>();
            tokens.Add("TCIS_47B4BC568");
            return tokens;
        }
    }
}