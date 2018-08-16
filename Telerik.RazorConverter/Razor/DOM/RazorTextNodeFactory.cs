using Telerik.RazorConverter.WebForms.DOM;

namespace Telerik.RazorConverter.Razor.DOM
{
    using System.ComponentModel.Composition;

    [Export(typeof(IRazorTextNodeFactory))]
    public class RazorTextNodeFactory : IRazorTextNodeFactory
    {
        public IRazorTextNode CreateTextNode(string text, CodeBlockNodeType blockType)
        {
            return new RazorTextNode { Text = text, BlockType = blockType };
        }
    }
}
