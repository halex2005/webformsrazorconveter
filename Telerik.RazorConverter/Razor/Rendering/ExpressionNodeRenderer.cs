namespace Telerik.RazorConverter.Razor.Rendering
{
    using Telerik.RazorConverter.Razor.DOM;

    public class ExpressionNodeRenderer : IRazorNodeRenderer
    {
        public string RenderNode(IRazorNode node, bool isInCodeBlockContext)
        {
            var srcNode = node as IRazorExpressionNode;
            var formatString = isInCodeBlockContext
                ? "<text>@{0}</text>"
                : "@{0}";

            if (srcNode.IsMultiline)
            {
                formatString = formatString.Replace("@{0}", "@({0})");
            }

            var expression = srcNode.Expression;
            return string.Format(formatString, expression);
        }

        public bool CanRenderNode(IRazorNode node)
        {
            return node is IRazorExpressionNode;
        }
    }
}
