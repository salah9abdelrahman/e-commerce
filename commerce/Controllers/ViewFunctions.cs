namespace commerce.Controllers
{
    public class ViewFunctions
    {
        public static string NoInfo(string n)
        {
            return string.IsNullOrEmpty(n) ? "No information given." : n;
        }
    }
}