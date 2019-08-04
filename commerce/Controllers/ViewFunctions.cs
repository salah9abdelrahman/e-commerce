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
    }
}