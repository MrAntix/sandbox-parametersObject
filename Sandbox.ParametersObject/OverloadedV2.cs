namespace Sandbox.ParametersObject
{
    public class OverloadedV2
    {
        public void DoSomething(int p1, string p2, byte p3)
        {
        }

        public void DoSomething()
        {
        }

        public void DoSomething(int p1)
        {
        }

        public void DoSomething(string p2)
        {
        }

        public void DoSomething(byte p3)
        {
        }

        public void DoSomething(int p1, string p2)
        {
        }

        public void DoSomething(int p1, byte p3)
        {
        }

        public void DoSomething(string p2, byte p3)
        {
        }
    }
}