namespace Telerik.RazorConverter.WebForms.Parsing
{
    using System.Text.RegularExpressions;

    class RunatServerTagRegex : Regex
    {
        public RunatServerTagRegex() : base(
            @"\G<(?<tagname>[Aa][Ss][Pp]:[\w:\.]+)(?<attributes>[^>]*?(?:runat\W*server){1}[^>]*?)(?<empty>/)?>",
            RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.Compiled)
        {
        }
    }
}
