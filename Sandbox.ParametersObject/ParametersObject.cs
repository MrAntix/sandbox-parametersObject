using System;

namespace Sandbox.ParametersObject
{
    public class ParametersObject
    {
        // defaults exposed, so they can be used and seen for what they are
        public const string OPTIONAL_PARAMETER_DEFAULT = "(not set)";
        public const int REQUIRED_PARAMETER_MINIMUM = 25;

        // immutable fields and properties for the parameters
        readonly string _optionalParameter;
        readonly int _requiredParameter;

        public string OptionalParameter
        {
            get { return _optionalParameter; }
        }

        public int RequiredParameter
        {
            get { return _requiredParameter; }
        }

        // a private constructor
        ParametersObject(Initializer data)
        {
            _optionalParameter = data.OptionalParameter;
            _requiredParameter = data.RequiredParameter;
        }

        // static create methods, where you instinctively go when you can't find a constructor no?
        public static ParametersObject Create(
            int requiredParameter)
        {
            return Create(requiredParameter, i => { });
        }

        public static ParametersObject Create(
            int requiredParameter, Action<Initializer> assign)
        {
            if (assign == null) throw new ArgumentNullException("assign");

            var i = new Initializer(requiredParameter);
            assign(i);

            if (i.RequiredParameter < REQUIRED_PARAMETER_MINIMUM)
                throw new ArgumentOutOfRangeException("RequiredParameter");

            return new ParametersObject(i);
        }

        // the initializer, a mutable transport class :/
        public class Initializer
        {
            // required params here
            public Initializer(int requiredParameter)
            {
                // defaults applied here
                OptionalParameter = OPTIONAL_PARAMETER_DEFAULT;
                RequiredParameter = requiredParameter;
            }

            public string OptionalParameter { get; set; }
            public int RequiredParameter { get; private set; }
        }
    }
}