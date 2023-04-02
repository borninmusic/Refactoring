namespace Refactoring;

public class ExtractVariable
{
    public const string Platform = "iOS";
    public const string Browser = "Firefox";
    public const int Height = 1920;
    public const int Width = 1080;

    public void Render()
    {
        if (Platform.Contains("iOS") && Browser.Contains("Firefox") && Height > Width)
        {
            Console.WriteLine("Say Hi! from iOS device with Firefox browser in portrait orientation");
        } 
    }
    
    public void RenderRefactored()
    {
        var isiOS = Platform.Contains("iOS");
        var isFirefox = Browser.Contains("Firefox");
        var isInPortraitMode = Height > Width;
        
        if (isiOS && isFirefox && isInPortraitMode)
        {
            Console.WriteLine("Say Hi! from iOS device with Firefox browser in portrait orientation");
        } 
    }
}


// Why Refactor
//
// The main reason for extracting variables is to make a complex expression more understandable, by dividing it into its intermediate parts. These could be:
// Condition of the if() operator or a part of the ?: operator in C-based languages
// A long arithmetic expression without intermediate results
// Extracting a variable may be the first step towards performing Extract Method if you see that the extracted expression is used in other places in your code.
//
//
// Benefits
//
// More readable code! Try to give the extracted variables good names that announce the variable’s purpose loud and clear.
//
//
// Drawbacks
//
// More variables are present in your code. But this is counterbalanced by the ease of reading your code.
// When refactoring conditional expressions, remember that the compiler will most likely optimize it to minimize the amount of calculations needed to establish the resulting value.
// However, if you extract parts of this expression into variables, both methods will always be called, which might hurt performance of the program, especially if these methods do some heavyweight work.

