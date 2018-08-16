namespace Telerik.RazorConverter.Razor.Rendering
{
    using Telerik.RazorConverter.Razor.DOM;

    public class TextNodeRenderer : IRazorNodeRenderer
    {
        public string RenderNode(IRazorNode node, bool isInCodeBlockContext)
        {
            var textNode = node as IRazorTextNode;
            return isInCodeBlockContext && !string.IsNullOrWhiteSpace(textNode.Text)
                ? $"<text>{textNode.Text}</text>"
                : textNode.Text;
        }

        public bool CanRenderNode(IRazorNode node)
        {
            return node is IRazorTextNode;
        }
    }
}
