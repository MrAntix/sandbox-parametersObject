using System;

using Xunit;

namespace Sandbox.ParametersObject
{
    public class tests
    {
        [Fact]
        public void assigns_arguments()
        {
            const string expectedOptionalArgument = "Big Bob";
            const int expectedRequiredArgument = 42;

            var result = new ParametersObject.Initializer
                (requiredParameter: expectedRequiredArgument)
                {
                    OptionalParameter = expectedOptionalArgument
                }
                .Create();

            Assert.Equal(expectedOptionalArgument, result.OptionalParameter);
            Assert.Equal(expectedRequiredArgument, result.RequiredParameter);
        }

        [Fact]
        public void defaults_arguments()
        {
            const string expectedOptionalArgument 
                = ParametersObject.Initializer.OPTIONAL_PARAMETER_DEFAULT;

            const int expectedRequiredArgument = 42;

            var result = new ParametersObject.Initializer
                (requiredParameter: expectedRequiredArgument)
                .Create();

            Assert.Equal(expectedOptionalArgument, result.OptionalParameter);
            Assert.Equal(expectedRequiredArgument, result.RequiredParameter);
        }

        [Fact]
        public void validates_arguments()
        {
            const string expectedOptionalArgument = "Big Bob";
            const int expectedRequiredArgument = 10;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => new ParametersObject.Initializer
                    (requiredParameter: expectedRequiredArgument)
                    {
                        OptionalParameter = expectedOptionalArgument
                    }.Create());

            Assert.Equal("RequiredParameter", ex.ParamName);
        }
    }
}