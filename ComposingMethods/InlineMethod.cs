namespace Refactoring;

public class InlineMethod
{
    private readonly int _numberOfCompletedTasks;

    public const int StandardRaiseUsdValue = 100;

    public InlineMethod(int numberOfCompletedTasks)
    {
        _numberOfCompletedTasks = numberOfCompletedTasks;
    }

    public int GetRaiseValue()
    {
        return MoreThanTenCompletedTasksInTime() ? StandardRaiseUsdValue : 0;
    }

    bool MoreThanTenCompletedTasksInTime()
    {
        return _numberOfCompletedTasks > 10;
    }

    public int GetRaiseValueRefactored()
    {
        return _numberOfCompletedTasks > 10 ? StandardRaiseUsdValue : 0;
    }
}

// Why Refactor
//
// A method simply delegates to another method. In itself, this delegation is no problem. But when there are many such methods, they become a confusing tangle that’s hard to sort through.
// Often methods aren’t too short originally, but become that way as changes are made to the program. So don’t be shy about getting rid of methods that have outlived their use.
//
//
// Benefits
//
// By minimizing the number of unneeded methods, you make the code more straightforward.
