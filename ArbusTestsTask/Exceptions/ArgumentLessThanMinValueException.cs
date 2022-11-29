namespace ArbusTestsTask.Exceptions;

public class ArgumentLessThanMinValueException<T> : ArgumentException
{
    public ArgumentLessThanMinValueException(string parameterName, T minValue) 
        : base($"The {parameterName} parameter can not be less than {minValue}.", parameterName)
    {
        
    }
}