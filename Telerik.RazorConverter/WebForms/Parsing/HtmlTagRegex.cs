using System.Text.RegularExpressions;

namespace Telerik.RazorConverter.WebForms.Parsing
{
    public class HtmlTagRegex : Regex
    {
        public HtmlTagRegex() : base(
            //@"\G<(?<tagname>(?![Aa][Ss][Pp]:)[\w:\.]+)(?<attributes>[^>]*?[^>]*?)(?<empty>/)?>",
            @"\G<"
            //+    @"(?<endTag>/)?"    //Captures the / if this is an end tag.
            +    @"(?<tagname>\w+)"    //Captures TagName
            +    @"("                //Groups tag contents
            +        @"(\s+"            //Groups attributes
            +            @"(?<attName>\w+)"  //Attribute name
            +            @"("                //groups =value portion.
            +                @"\s*=\s*"            // = 
            +                @"(?:"        //Groups attribute "value" portion.
            +                    @"""(?<attVal><%=.*?%>)"""    // attVal='double quoted with inline expressions <%=some%>'
            +                    @"|'(?<attVal><%=.*?%>)'"        // attVal='single quoted with inline expressions <%=some%>'
            +                    @"|""(?<attVal>[^""]*)"""    // attVal='double quoted'
            +                    @"|'(?<attVal>[^']*)'"        // attVal='single quoted'
            +                    @"|(?<attVal>[^'"">\s]+)"    // attVal=urlnospaces
            +                @")"
            +            @")?"        //end optional att value portion.
            +        @")+\s*"        //One or more attribute pairs
            +        @"|\s*"            //Some white space.
            +    @")"
            + @"(?<completeTag>/)?>", //Captures the "/" if this is a complete tag.
            RegexOptions.Multiline | RegexOptions.Compiled | RegexOptions.ECMAScript)
        {
        }
    }
}
