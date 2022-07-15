namespace Project;

public interface IStrategy:IPrinteable
{
    Token TokenToPlay(List<Token> itIsOkPlayed, Player player, int nextPlayerCursor, Table table  );
}
public interface ITokensGenerator:IPrinteable
{
    Dictionary<int,(int,int)> Stats();
    List<Token> Generated();
}
public interface IEndGame:IPrinteable
{
    (bool,List<Player>) IsEndGame(Game game);
}
public interface IEndRound:IPrinteable
{
    (bool,List<Player>) IsEndRound(Game game);
}
public interface IFirstPlayer:IPrinteable
{
    int IndexFirstPlayer(Game game);
}
public interface IScoreCalculator:IPrinteable
{
    void ToCalculateScore(Game game);
}
public interface IDistribution:IPrinteable
{
    void ToDistribute(Game game);
}
public interface IMove:IPrinteable
{
    List<Token> ItIsAOkPlayed(List<Token> hand);
}
public interface IActionModeratorToAdd:IPrinteable
{
    List<Token> TokensToAddThatItIsOk();
}
public interface IActionModeratorToSub:IPrinteable
{
    List<Token> TokensToSubThatItIsNotOk();
}
public interface IStep:IPrinteable
{
    int IndexNextPlayer(Game game);
}
public interface IPrinteable
{
    string Print();
}