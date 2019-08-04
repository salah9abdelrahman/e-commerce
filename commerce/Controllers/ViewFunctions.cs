using System.Web.Mvc;

namespace commerce.Controllers
{
    public class ViewFunctions
    {
        public static string NoInfo(string n)
        {
            return string.IsNullOrEmpty(n) ? "No information given." : n;
        }
        public static string PipeMaxLength(string n, int len)
        {
            return n.Substring(0, len) + ".....";
        }

        public static string UserEmail(MvcHtmlString e)
        {
            var es = e?.ToString();

            if (!string.IsNullOrEmpty(es))
            {
                var at = es.IndexOf('@');
                return es.Substring(0, at);
            }

            return "";
        }
    }
}