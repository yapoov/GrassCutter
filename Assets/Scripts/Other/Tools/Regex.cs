using System.Text.RegularExpressions;

public class Rgx {
    ///<summary>бүхэл тооны regex</summary>
    public static readonly string Int = "[-+]?[0-9]+";

    ///<summary>бутархай тооны regex</summary>
    public static readonly string Float = "[-+]?[0-9]*\\.?[0-9]+";

    ///<summary>e-тэй бутархай тооны regex</summary>
    public static readonly string EInFloat = "[-+]?[0-9]*\\.?[0-9]+([eE][-+]?[0-9]+)?";

    ///<summary>16-н өнгөний regex</summary>
    public static readonly string HexColor = "#?(([0-9A-Fa-f]{6})|([0-9A-Fa-f]{8}))";

    ///<summary>input-н pattern-тай таарч байна уу шалгана</summary>
    public static bool IsMatch(string input, string pattern) {
        return Regex.IsMatch(input, pattern);
    }

    ///<summary>input-н pattern-г replacement-р дарна</summary>
    public static string Replace(string input, string pattern, string replacement) {
        return Regex.Replace(input, pattern, replacement);
    }

    ///<summary>input-г pattern-р хуваана</summary>
    public static string[] Split(string input, string pattern) {
        return Regex.Split(input, pattern);
    }
}