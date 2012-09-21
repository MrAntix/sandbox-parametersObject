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

        public class Initializer
        {
            public Initializer(int requiredParameter)
            {
                OptionalParameter = OPTIONAL_PARAMETER_DEFAULT;
                RequiredParameter = requiredParameter;
            }

            public string OptionalParameter { get; set; }
            public int RequiredParameter { get; private set; }

            public ParametersObject Create()
            {
                if (RequiredParameter < REQUIRED_PARAMETER_MINIMUM)
                    throw new ArgumentOutOfRangeException("RequiredParameter");

                return new ParametersObject(this);
            }
        }
    }
}