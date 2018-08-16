namespace Telerik.RazorConverter.Razor.Rendering
{
    using Telerik.RazorConverter.Razor.DOM;

    public class CodeNodeRenderer : IRazorNodeRenderer
    {
        public string RenderNode(IRazorNode node, bool isInCodeBlockContext)
        {
            var srcNode = node as IRazorCodeNode;
            var prefix = "";
            var code = srcNode.Code;

            var requiresBlock = srcNode.RequiresBlock;
            var requiresPrefix = srcNode.RequiresPrefix;
            if (isInCodeBlockContext)
            {
                requiresBlock = false;
                requiresPrefix = false;
            }

            if (requiresBlock)
            {
                code = "{\r\n" + code + "\r\n}";
            }

            if (requiresPrefix || requiresBlock)
            {
                prefix = "@";
                code = code.TrimStart();
            }

            return prefix + code;
        }

        public bool CanRenderNode(IRazorNode node)
        {
            return node is IRazorCodeNode;
        }
    }
}
