using Telerik.RazorConverter.WebForms.DOM;

namespace Telerik.RazorConverter.Razor.DOM
{
    public class RazorTextNode : RazorNode, IRazorTextNode
    {
        public string Text { get; set; }

        public CodeBlockNodeType BlockType { get; set; }

        public RazorTextNode()
        {
            BlockType = CodeBlockNodeType.Complete;
        }

        public RazorTextNode(string text)
        {
            Text = text;
            BlockType = CodeBlockNodeType.Complete;
        }
    }
}
