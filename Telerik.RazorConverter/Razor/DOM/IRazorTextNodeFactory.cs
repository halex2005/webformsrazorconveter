using Telerik.RazorConverter.WebForms.DOM;

namespace Telerik.RazorConverter.Razor.DOM
{
    public interface IRazorTextNodeFactory
    {
        IRazorTextNode CreateTextNode(string text, CodeBlockNodeType blockType);
    }
}
