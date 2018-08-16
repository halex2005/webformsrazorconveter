namespace Telerik.RazorConverter.WebForms.DOM
{
    public interface IWebFormsHtmlTagNode : IWebFormsContentNode
	{
        string TagName { get; set; }
        CodeBlockNodeType BlockType { get; set; }
    }
}
