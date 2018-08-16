using Telerik.RazorConverter.WebForms.DOM;

namespace Telerik.RazorConverter.Razor.DOM
{
    public interface IRazorCodeNodeFactory
    {
        IRazorCodeNode CreateCodeNode(string code, bool requiresPrefix, bool requiresBlock, CodeBlockNodeType codeBlockType);
    }
}
