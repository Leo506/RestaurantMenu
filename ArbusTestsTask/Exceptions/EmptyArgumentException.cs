namespace ArbusTestsTask.Exceptions;

public class EmptyArgumentException : ArgumentException
{
    public EmptyArgumentException(string parameterName) 
        : base($"The {parameterName} parameter can not be empty.", parameterName)
    {
    }
}