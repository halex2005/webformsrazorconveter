using System.Collections.Generic;
using System.Linq;
using Telerik.RazorConverter.Razor.DOM;
using Telerik.RazorConverter.Razor.Rendering;
using Telerik.RazorConverter.WebForms.DOM;

namespace Telerik.RazorConverter.Razor.Converters
{
    public class HtmlTagNodeConverter : INodeConverter<IRazorNode>
    {
        private readonly IRazorTextNodeFactory textNodeFactory;
        private readonly IRazorNodeConverterProvider nodeConverterProvider;
        private readonly IWebFormsParser webFormsParser;
        private readonly WebFormsToRazorConverter converter;
        private readonly RazorViewRenderer renderer;

        public HtmlTagNodeConverter(
            IRazorTextNodeFactory textNodeFactory,
            IRazorNodeConverterProvider nodeConverterProvider,
            IWebFormsParser webFormsParser)
        {
            this.textNodeFactory = textNodeFactory;
            this.nodeConverterProvider = nodeConverterProvider;
            this.webFormsParser = webFormsParser;
            converter = new WebFormsToRazorConverter(this.nodeConverterProvider);
            renderer = new RazorViewRenderer(new RazorNodeRendererProvider());
        }

        public IList<IRazorNode> ConvertNode(IWebFormsNode node)
        {
            var srcNode = (IWebFormsHtmlTagNode) node;

            if (srcNode.BlockType == CodeBlockNodeType.Complete)
            {
                return new[]
                {
                    textNodeFactory.CreateTextNode("<" + ConvertToRazor(srcNode.Content.TrimStart('<')), CodeBlockNodeType.Complete)
                };
            }

            var convertedChildren = node.Children
                .SelectMany(childNode => nodeConverterProvider
                    .NodeConverters
                    .Where(converter => converter.CanConvertNode(childNode))
                    .SelectMany(converter => converter.ConvertNode(childNode)));

            var startingTagContent = "<" + ConvertToRazor(srcNode.Content.TrimStart('<'));
            var startingTag = textNodeFactory.CreateTextNode(startingTagContent, CodeBlockNodeType.Opening);
            var endingTag = textNodeFactory.CreateTextNode($"</{srcNode.TagName}>", CodeBlockNodeType.Closing);
            return new[] { startingTag }
                .Concat(convertedChildren)
                .Concat(new[] { endingTag })
                .ToArray();
        }

        private string ConvertToRazor(string value)
        {
            var parsed = webFormsParser.Parse(value);
            var razorDocument = converter.Convert(parsed);
            return renderer.Render(razorDocument).Trim();
        }

        public bool CanConvertNode(IWebFormsNode node)
        {
            return node is IWebFormsHtmlTagNode;
        }
    }
}
