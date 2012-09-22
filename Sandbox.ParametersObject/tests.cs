using System;

using Xunit;

namespace Sandbox.ParametersObject
{
    public class tests
    {
        const string EXPECTED_OPTIONAL_ARGUMENT = "Big Bob";

        [Fact]
        public void assigns_arguments()
        {
            const string expectedOptionalArgument = EXPECTED_OPTIONAL_ARGUMENT;
            const int expectedRequiredArgument =
                ParametersObject.REQUIRED_PARAMETER_MINIMUM;

            var result = ParametersObject.Create(
                expectedRequiredArgument,
                i => { i.OptionalParameter = expectedOptionalArgument; });

            Assert.Equal(expectedOptionalArgument, result.OptionalParameter);
            Assert.Equal(expectedRequiredArgument, result.RequiredParameter);
        }

        [Fact]
        public void defaults_arguments()
        {
            const string expectedOptionalArgument
                = ParametersObject.OPTIONAL_PARAMETER_DEFAULT;

            const int expectedRequiredArgument =
                ParametersObject.REQUIRED_PARAMETER_MINIMUM;

            var result = ParametersObject.Create(expectedRequiredArgument);

            Assert.Equal(expectedOptionalArgument, result.OptionalParameter);
            Assert.Equal(expectedRequiredArgument, result.RequiredParameter);
        }

        [Fact]
        public void validates_arguments()
        {
            const string expectedOptionalArgument = EXPECTED_OPTIONAL_ARGUMENT;
            const int expectedRequiredArgument =
                ParametersObject.REQUIRED_PARAMETER_MINIMUM - 1;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => ParametersObject.Create(
                    expectedRequiredArgument,
                    i => { i.OptionalParameter = expectedOptionalArgument; })
                );

            Assert.Equal("RequiredParameter", ex.ParamName);
        }
    }
}