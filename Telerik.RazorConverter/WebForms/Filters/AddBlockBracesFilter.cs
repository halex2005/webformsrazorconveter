namespace Telerik.RazorConverter.WebForms.Filters
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using DOM;

    public class AddBlockBracesFilter : IWebFormsNodeFilter
    {
        public IList<IWebFormsNode> Filter(IWebFormsNode node, IWebFormsNode previousFilteredNode)
        {
            var isCodeGroupNode = node is IWebFormsCodeGroupNode;
            var isCompleteCodeNode = node is IWebFormsCodeBlockNode && ((IWebFormsCodeBlockNode) node).BlockType == CodeBlockNodeType.Complete;
            if (isCodeGroupNode || isCompleteCodeNode)
            {
                var codeContentNode = node as IWebFormsContentNode;
                if (codeContentNode != null && RequiresBlock(codeContentNode))
                {
                    codeContentNode.Content = string.Format("{{{0}}}", codeContentNode.Content).Replace("{{", "{").Replace("}}", "}");
                }
            }

            return new[] {node};
        }

        private bool RequiresBlock(IWebFormsContentNode node)
        {
            if ((node.Parent != null &&
                 (node.Parent.Type == NodeType.CodeBlock ||
                  node.Parent.Type == NodeType.EncodedExpressionBlock ||
                  node.Parent.Type == NodeType.ExpressionBlock)) ||
                node.Parent is WebFormsCodeGroupNode)
            {
                return false;
            }

            var code = node.Content;
            var statementRegex = new Regex(
                @"^\s*(?<op>foreach|if|using|Html\.RenderPartial)\s*
            (?<param>\((?>[^()]+|\((?<Depth>)|\)(?<-Depth>))*(?(Depth)(?!))\)){1}\s*
            (;)?\s*
            (?<block>\{(?>[^{}]+|\{(?<Depth>)|\}(?<-Depth>))*(?(Depth)(?!))\})?\s*
            (else\s*
                (?<elseblock>\{(?>[^{}]+|\{(?<Depth>)|\}(?<-Depth>))*(?(Depth)(?!))\})?\s*
            )?\s*
            (?<extra>\S*) $",
                RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            var match = statementRegex.Match(code);
            bool matchesOperator = match.Groups["op"].Success;
            bool hasExtraStatements = match.Groups["extra"].Length > 0;
            return !matchesOperator || (matchesOperator && hasExtraStatements);
        }
    }
}
