using System;

namespace Sandbox.ParametersObject
{
    public class ParametersObject
    {
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
            public const string OPTIONAL_PARAMETER_DEFAULT = "(not set)";

            public Initializer(int requiredParameter)
            {
                OptionalParameter = OPTIONAL_PARAMETER_DEFAULT;
                RequiredParameter = requiredParameter;
            }

            public string OptionalParameter { get; set; }
            public int RequiredParameter { get; private set; }

            public ParametersObject Create()
            {
                if (RequiredParameter < 25) throw new ArgumentOutOfRangeException("RequiredParameter");

                return new ParametersObject(this);
            }
        }
    }
}