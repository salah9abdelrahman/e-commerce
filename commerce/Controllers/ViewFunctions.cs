using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace commerce.Views
{
    public class ViewFunctions
    {
        public static string NoInfo(string n)
        {
            return string.IsNullOrEmpty(n) ? "No information given." : n;
        }
    }
}