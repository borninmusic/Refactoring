namespace Refactoring;

public class RemoveAssignmentsToParameters
{
    private readonly int _basePercentage;

    public RemoveAssignmentsToParameters(int basePercentage)
    {
        _basePercentage = basePercentage;
    }

    public double CalculateDiscountedPrice(int quantity, int value)
    {
        if (quantity > 10)
        {
            return value * (_basePercentage / 100);
        }

        return value;
    }

    public double CalculateDiscountedPriceRefactored(int quantity, int value)
    {
        var localQuantity = quantity;
        var localValue = value;

        if (localQuantity > 10)
        {
            return localValue * (_basePercentage / 100);
        }

        return localValue;
    }
}

// Why Refactor
//
// We avoid accidental parameter modification by inner code of a method.
// First, if a parameter is passed via reference, then after the parameter value is changed inside the method, this value is passed to the argument that requested calling this method.
// Very often, this occurs accidentally and leads to unfortunate effects. Even if parameters are usually passed by value (and not by reference) in your programming language, this coding quirk may alienate those who are unaccustomed to it.
//
// Second, multiple assignments of different values to a single parameter make it difficult for you to know what data should be contained in the parameter at any particular point in time.
// The problem worsens if your parameter and its contents are documented but the actual value is capable of differing from what’s expected inside the method.
//
//
// Benefits
//
// Each element of the program should be responsible for only one thing. This makes code maintenance much easier going forward, since you can safely replace code without any side effects.
// This refactoring helps to extract repetitive code to separate methods.
