using System;

namespace Refactoring;

public class ExtractMethod
{
    public string FirstName { get; }
    public string LastName { get; }

    public ExtractMethod(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public void PrintOwnership()
    {
        PrintStandardBanner();

        Console.WriteLine($@"First name: {FirstName}");
        Console.WriteLine($@"Last name: {LastName}");
    }
    
    public void PrintOwnershipOptimized()
    {
        PrintStandardBanner();
        PrintOwnerDetails();
    }

    private void PrintOwnerDetails()
    {
        Console.WriteLine($@"First name: {FirstName}");
        Console.WriteLine($@"Last name: {LastName}");
    }

    private void PrintStandardBanner()
    {
        Console.WriteLine("Hey! This is a standard banner!");
    }
}

// Why Refactor
//
// The more lines found in a method, the harder it’s to figure out what the method does. This is the main reason for this refactoring.
// Besides eliminating rough edges in your code, extracting methods is also a step in many other refactoring approaches.
//
//
// Benefits
//
// More readable code
// Less code duplication. Often the code that’s found in a method can be reused in other places in your program. So you can replace duplicates with calls to your new method.
// Isolates independent parts of code, meaning that errors are less likely.