namespace Refactoring;

public class MethodObject
{
    public int Delta = 10;

    public int Gamma(int inputValue, int quantity, int yearToDate)
    {
        var importantValue1 = inputValue * quantity + Delta;
        var importantValue2 = inputValue * yearToDate + 100;
        if (yearToDate - importantValue1 > 100)
            importantValue2 -= 20;
        var importantValue3 = importantValue2 * 7;

        return importantValue3 - 2 * importantValue1;
    }
}

#region Optimized

public class MethodObjectRefactored
{
    public int Delta = 10;

    public int Gamma(int inputValue, int quantity, int yearToDate)
    {
        return new GammaClass(this, inputValue, quantity, yearToDate).Compute();
    }

    private class GammaClass
    {
        private readonly MethodObjectRefactored _methodObj;
        private readonly int _inputValue;
        private readonly int _quantity;
        private readonly int _yearToDate;

        private int _importantValue1;
        private int _importantValue2;
        private int _importantValue3;

        public GammaClass(MethodObjectRefactored obj, int inputValue, int quantity, int yearToDate)
        {
            _methodObj = obj;
            _inputValue = inputValue;
            _quantity = quantity;
            _yearToDate = yearToDate;
        }

        public int Compute()
        {
            ComputeImportantValue1();
            ComputeImportantValue2();
            ComputeImportantValue3();

            return _importantValue3 - 2 * _importantValue1;
        }

        private void ComputeImportantValue1()
        {
            var someValue = _inputValue * _quantity;
            _importantValue1 = someValue + _methodObj.Delta;
        }

        private void ComputeImportantValue2()
        {
            _importantValue2 = _inputValue * _yearToDate + 100;
            if (_yearToDate - _importantValue1 > 100)
                _importantValue2 -= 20;
        }

        private void ComputeImportantValue3()
        {
            _importantValue3 = _importantValue2 * 7;
        }
    }
}

#endregion

// Why Refactor
//
// This refactoring does exactly what its name implies. It replaces a long and difficult to understand method and places it in it’s own class.
// The multitude of local variables that you probably have lying around in that method then become instance variables on the new class.
// Afterwards, we might going further and decompose that long method into smaller methods (we should always have small methods) in the new class.
// This should be easy, since all our local variables are now instance variables, you don’t have to worry about passing a ton of parameters around.
//
//
// Benefits
//
// Isolating a long method in its own class allows stopping a method from ballooning in size.
// This also allows splitting it into submethods within the class, without polluting the original class with utility methods.
//
//
// Drawbacks
//
// Another class is added, increasing the overall complexity of the program.
//
//
// How to Refactor
//
// 1) Create a new class. Name it based on the purpose of the method that you’re refactoring.
// 2) In the new class, create a private field for storing a reference to an instance of the class in which the method was previously located. It could be used to get some required data from the original class if needed.
// 3) Create a separate private field for each local variable of the method.
// 4) Create a constructor that accepts as parameters the values of all local variables of the method and also initializes the corresponding private fields.
// 5) Declare the main method and copy the code of the original method to it, replacing the local variables with private fields.
// 6) Replace the body of the original method in the original class by creating a method object and calling its main method.

