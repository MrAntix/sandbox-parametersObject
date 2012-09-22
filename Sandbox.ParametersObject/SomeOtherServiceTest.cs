using Xunit;

namespace Sandbox.ParametersObject
{
    public class SomeOtherServiceTest
    {
        [Fact]
        public void call()
        {
            var service = new SomeOtherService();

            service.DoSomething(
                SomeOtherService.DoSomethingParameters.Create(p =>
                    {
                        p.P1 = 1;
                        p.P2 = 10;
                    })
                );
        }
    }
}