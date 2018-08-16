using System.Collections;
using System.Collections.Generic;
using Telerik.RazorConverter.WebForms.DOM;

namespace Telerik.RazorConverter.Razor.Rendering
{
    using System.ComponentModel.Composition;
    using System.Text;
    using Telerik.RazorConverter;
    using Telerik.RazorConverter.Razor.DOM;

    [Export(typeof(IRenderer<IRazorNode>))]
    public class RazorViewRenderer : IRenderer<IRazorNode>
    {
        private IRazorNodeRendererProvider RendererProvider { get; set; }

        [ImportingConstructor]
        public RazorViewRenderer(IRazorNodeRendererProvider NodeRendererProvider)
        {
            RendererProvider = NodeRendererProvider;
        }

        public string Render(IDocument<IRazorNode> document)
        {
            var sb = new StringBuilder();
            var codeBlockContext = new Stack<bool>();
            codeBlockContext.Push(false);
            foreach (var node in document.RootNode.Children)
            {
                var codeNode = node as IRazorCodeNode;
                if (codeNode != null && codeNode.CodeBlockType == CodeBlockNodeType.Closing)
                {
                    codeBlockContext.Pop();
                }

                var textNode = node as RazorTextNode;
                if (textNode != null && textNode.BlockType == CodeBlockNodeType.Opening)
                {
                    codeBlockContext.Push(false);
                }

                var currentContextIsInCodeBlock = codeBlockContext.Peek();
                foreach (var renderer in RendererProvider.NodeRenderers)
                {
                    if (renderer.CanRenderNode(node))
                    {
                        sb.Append(renderer.RenderNode(node, currentContextIsInCodeBlock));
                        break;
                    }
                }

                if (textNode != null && textNode.BlockType == CodeBlockNodeType.Closing)
                {
                    codeBlockContext.Pop();
                }

                if (codeNode != null && codeNode.CodeBlockType == CodeBlockNodeType.Opening)
                {
                    codeBlockContext.Push(true);
                }
            }

            sb.AppendLine();
            return sb.ToString();
        }
    }
}
