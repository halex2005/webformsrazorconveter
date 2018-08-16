using Telerik.RazorConverter.WebForms.DOM;

namespace Telerik.RazorConverter.Tests.Razor.DOM
{
    using Telerik.RazorConverter.Razor.DOM;
    using Xunit;

    public class RazorTextNodeFactoryTests
    {
        private readonly RazorTextNodeFactory razorTextNodeFactory;

        public RazorTextNodeFactoryTests()
        {
            razorTextNodeFactory = new RazorTextNodeFactory();
        }

        [Fact]
        public void Should_set_text()
        {
            var codeNode = razorTextNodeFactory.CreateTextNode("text", CodeBlockNodeType.Complete);
            codeNode.Text.ShouldEqual("text");
        }
    }
}
