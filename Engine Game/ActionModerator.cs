namespace Project;
class DoubleWhiteActionToAdd : IActionModeratorToAdd
{
    public List<Token> TokensToAddThatItIsOk()
    {
        List<Token> TokensToAdd=new List<Token>();
        TokensToAdd.Add(new Token(0, 0));
        return TokensToAdd;
    }
}
public class ClassicActionToAdd : IActionModeratorToAdd// implemetacion de la interface
{
    public List<Token> TokensToAddThatItIsOk()
    {
        return new List<Token>();
    }
}
class ClassicActionToSub : IActionModeratorToSub
{
    public List<Token> TokensToSubThatItIsNotOk()
    {
        return new List<Token>();
    }
}