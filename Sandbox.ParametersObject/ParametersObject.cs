using System;

namespace Sandbox.ParametersObject
{
    public class ParametersObject
    {
        public const string OPTIONAL_PARAMETER_DEFAULT = "(not set)";
        public const int REQUIRED_PARAMETER_MINIMUM = 25;

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

        ParametersObject(Initializer data)
        {
            _optionalParameter = data.OptionalParameter;
            _requiredParameter = data.RequiredParameter;
        }

        public static ParametersObject Create( 
            int requiredParameter)
        {
            return Create(requiredParameter, i => { });
        }

        public static ParametersObject Create( 
            int requiredParameter,Action<Initializer> assign)
        {
            if (assign == null) throw new ArgumentNullException("assign");

            var i = new Initializer(requiredParameter);
            assign(i);

            if (i.RequiredParameter < REQUIRED_PARAMETER_MINIMUM)
                throw new ArgumentOutOfRangeException("RequiredParameter");

            return new ParametersObject(i);
        }

        public class Initializer
        {
            public Initializer(int requiredParameter)
            {
                OptionalParameter = OPTIONAL_PARAMETER_DEFAULT;
                RequiredParameter = requiredParameter;
            }

            public string OptionalParameter { get; set; }
            public int RequiredParameter { get; private set; }
        }
    }
}