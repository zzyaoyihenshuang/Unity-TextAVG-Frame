namespace Duo1J
{
    public class ParamUtil : Duo1JAVG
    {
        public static string StringNotNull(string s)
        {
            return s == null || s == "" ? null : s;
        }

        public static int ParseString2Int(string s, int defaultInt)
        {
            return s == null || s == "" ? defaultInt : int.Parse(s);
        }

        public static float ParseString2Float(string s, float defaultFloat)
        {
            return s == null || s == "" ? defaultFloat : float.Parse(s);
        }
    }
}