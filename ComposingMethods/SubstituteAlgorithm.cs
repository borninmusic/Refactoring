namespace Refactoring;

public class SubstituteAlgorithm
{
    private readonly List<string> _teamMates = new() {"Marina", "Viktor", "Dmytro", "Tomas", "Serhii", "Viktoriya", "Olena", "Khristina"};

    public string FoundTeamMate(params string[] names)
    {
        foreach (var name in names)
        {
            if (name.Equals("Marina"))
            {
                return "Marina";
            }

            if (name.Equals("Viktor"))
            {
                return "Viktor";
            }

            if (name.Equals("Dmytro"))
            {
                return "Dmytro";
            }

            if (name.Equals("Tomas"))
            {
                return "Tomas";
            }

            if (name.Equals("Serhii"))
            {
                return "Serhii";
            }

            if (name.Equals("Viktoriya"))
            {
                return "Viktoriya";
            }

            if (name.Equals("Olena"))
            {
                return "Olena";
            }

            if (name.Equals("Khristina"))
            {
                return "Khristina";
            }
        }

        return String.Empty;
    }

    public string FoundTeamMateRefactored(params string[] names)
    {
        foreach (var name in names)
        {
            if (_teamMates.Contains(name)) 
            {
                return name;
            }
        }

        return String.Empty;
    }
}

// Why Refactor
//
// Gradual refactoring isn’t the only method for improving a program. Sometimes a method is so cluttered with issues that it’s easier to tear down the method and start fresh.
// And perhaps you have found an algorithm that’s much simpler and more efficient. If this is the case, you should simply replace the old algorithm with the new one.
// As time goes on, your algorithm may be incorporated into a well-known library or framework and you want to get rid of your implementation, in order to simplify maintenance.
// The requirements for your program may change so heavily that your existing algorithm can’t be salvaged for the task.
//
//
// How to Refactor
//
// 1) Make sure that you have simplified the existing algorithm as much as possible. Move unimportant code to other methods using Extract Method. The fewer moving parts in your algorithm, the easier it’s to replace.
// 2) Create your new algorithm in a new method. Replace the old algorithm with the new one and start testing the program.
// 3) If the results don’t match, return to the old implementation and compare the results. Identify the causes of the discrepancy.
// 4) When all tests are successfully completed, delete the old algorithm for good!
