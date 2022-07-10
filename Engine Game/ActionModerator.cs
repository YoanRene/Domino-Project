namespace Project;
public class DoubleWhiteActionToAdd : IActionModeratorToAdd
{
    public string Print()
    {
        return "Double White is a Valid Token always";
    }

    public List<Token> TokensToAddThatItIsOk()
    {
        List<Token> TokensToAdd=new List<Token>();
        TokensToAdd.Add(new Token(0, 0));
        return TokensToAdd;
    }
}
public class ClassicActionToAdd : IActionModeratorToAdd// implementacion de la interface
{
    public string Print()
    {
        return "Classic";
    }

    public List<Token> TokensToAddThatItIsOk()
    {
        return new List<Token>();
    }
}
public class ClassicActionToSub : IActionModeratorToSub
{
    public string Print()
    {
        return "Classic";
    }

    public List<Token> TokensToSubThatItIsNotOk()
    {
        return new List<Token>();
    }
}