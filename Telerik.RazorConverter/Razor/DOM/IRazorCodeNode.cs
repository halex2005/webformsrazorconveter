using Telerik.RazorConverter.WebForms.DOM;

namespace Telerik.RazorConverter.Razor.DOM
{
    public interface IRazorCodeNode : IRazorNode
    {
        string Code { get; }
        bool RequiresPrefix { get; }
        bool RequiresBlock { get; }
        CodeBlockNodeType CodeBlockType { get; }
    }
}
