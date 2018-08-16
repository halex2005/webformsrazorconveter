namespace Telerik.RazorConverter.WebForms.DOM
{
    public class WebFormsHtmlTagNode : WebFormsNode, IWebFormsHtmlTagNode
    {
        public string Content { get; set; }
        public string TagName { get; set; }
        public CodeBlockNodeType BlockType { get; set; }
    }
}
