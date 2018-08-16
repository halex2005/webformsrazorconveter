namespace Telerik.RazorConverter.Tests.Razor.Rendering
{
    using Moq;
    using Telerik.RazorConverter.Razor.DOM;
    using Telerik.RazorConverter.Razor.Rendering;
    using Xunit;

    public class ExpressionNodeRendererTests
    {
        private readonly ExpressionNodeRenderer renderer;
        private readonly Mock<IRazorExpressionNode> expressionNodeMock;

        public ExpressionNodeRendererTests()
        {
            renderer = new ExpressionNodeRenderer();
            expressionNodeMock = new Mock<IRazorExpressionNode>();
        }

        [Fact]
        public void Should_support_expression_node()
        {
            renderer.CanRenderNode(expressionNodeMock.Object).ShouldBeTrue();
        }

        [Fact]
        public void Should_not_support_other_nodes()
        {
            renderer.CanRenderNode(new Mock<IRazorNode>().Object).ShouldBeFalse();
        }

        [Fact]
        public void Should_prefix_expression_outside_codeBlock()
        {
            expressionNodeMock.SetupGet(n => n.Expression).Returns("DateTime.Now");

            renderer.RenderNode(expressionNodeMock.Object, false).ShouldEqual("@DateTime.Now");
        }

        [Fact]
        public void Should_prefix_expression_inside_codeBlock()
        {
            expressionNodeMock.SetupGet(n => n.Expression).Returns("DateTime.Now");

            renderer.RenderNode(expressionNodeMock.Object, true).ShouldEqual("<text>@DateTime.Now</text>");
        }

        [Fact]
        public void Should_add_parentheses_for_multiline_expressions_outside_codeBlock()
        {
            expressionNodeMock.SetupGet(n => n.Expression).Returns("Html.Telerik().Grid(orders)\r\n.Name(\"Grid 1\")");
            expressionNodeMock.SetupGet(n => n.IsMultiline).Returns(true);

            renderer.RenderNode(expressionNodeMock.Object, false).ShouldEqual("@(Html.Telerik().Grid(orders)\r\n.Name(\"Grid 1\"))");
        }

        [Fact]
        public void Should_render_as_code_for_multiline_expressions_inside_codeBlock()
        {
            expressionNodeMock.SetupGet(n => n.Expression).Returns("Html.Telerik().Grid(orders)\r\n.Name(\"Grid 1\")");
            expressionNodeMock.SetupGet(n => n.IsMultiline).Returns(true);

            renderer.RenderNode(expressionNodeMock.Object, true).ShouldEqual("<text>@(Html.Telerik().Grid(orders)\r\n.Name(\"Grid 1\"))</text>");
        }
    }
}
