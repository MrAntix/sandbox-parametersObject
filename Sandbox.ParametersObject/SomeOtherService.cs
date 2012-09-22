using System;

namespace Sandbox.ParametersObject
{
    public class SomeOtherService
    {
        public void DoSomething(DoSomethingParameters doSomethingParameters)
        {
        }

        public class DoSomethingParameters
        {
            // defaults exposed, so they can be used and seen for what they are
            public const int P1_DEFAULT = 1;
            public const int P2_DEFAULT = 10;

            // validation exposed
            public const int P2_MINIMUM = 5;

            // immutable fields and properties for the parameters
            readonly int _p1;
            readonly int _p2;

            public int P1
            {
                get { return _p1; }
            }

            public int P2
            {
                get { return _p2; }
            }

            // a private constructor
            DoSomethingParameters(Initializer i)
            {
                _p1 = i.P1;
                _p2 = i.P2;
            }

            // static create methods, where you instinctively go when you can't find a constructor no?
            public static DoSomethingParameters Create(
                int requiredParameter)
            {
                return Create(i => { });
            }

            public static DoSomethingParameters Create(
                Action<Initializer> assign)
            {
                if (assign == null) throw new ArgumentNullException("assign");

                var i = new Initializer();
                assign(i);

                // validation
                if (i.P2 < P2_MINIMUM)
                    throw new ArgumentOutOfRangeException("P2");

                return new DoSomethingParameters(i);
            }

            // the initializer, a mutable transport class :/
            public class Initializer
            {
                // required params here
                public Initializer()
                {
                    // defaults applied here
                    P1 = P1_DEFAULT;
                }

                public int P1 { get; set; }
                public int P2 { get; set; }
            }
        }
    }
}