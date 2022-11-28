namespace ArbusTestsTask;

public static class ExceptionMessages
{
    public static string EmptyArgument(string parameterName) => $"The {parameterName} parameter can not be empty.";

    public static string LessThanMinValue(string parameterName, int minValue) =>
        $"The {parameterName} parameter can not be less than {minValue}.";
    
    public static string IncorrectIndex(string parameterName, int maxIndex) => 
        $"The {parameterName} parameter can not be less tha 0 and more than {maxIndex}.";
}