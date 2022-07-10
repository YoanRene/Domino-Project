namespace Project;

public interface IStrategy:IPrinteable// interface que define las estrategias de cada jugador
{
    Token TokenToPlay(List<Token> itIsOkPlayed, Player player, int nextPlayerCursor, Table table  );
    //metodo que define la pieza a jugar por el jugador que utilice esta estrategia
}
public interface ITokensGenerator:IPrinteable
{
    Dictionary<int,(int,int)> Stats();
    List<Token> Generated();
}
public interface IEndGame:IPrinteable
{
    bool IsEndGame(Game game);
}
public interface IEndRound:IPrinteable
{
    bool IsEndRound(Game game);
}
public interface IFirstPlayer:IPrinteable// define las distintas formas de empezar el juego
{
    int IndexFirstPlayer(Game game);// llama al primer jugador a jugar
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
    List<Token> TokensToAddThatItIsOk();// en el caso que las fichas se puedan jugar en cualquier momento del juego
}
public interface IActionModeratorToSub:IPrinteable
{
    List<Token> TokensToSubThatItIsNotOk();// en el caso que las fichas no se puedan jugar en juego
}
public interface IStep:IPrinteable
{
    int IndexNextPlayer(Game game);
}
public interface IPrinteable
{
    string Print();
}