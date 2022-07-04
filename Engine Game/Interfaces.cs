namespace Project;

public interface IStrategy// interface que define las estrategias de cada jugador
{
    Token TokenToPlay(List<Token> itIsOkPlayed, Player player, int cursor, Table table  );
    //metodo que define la pieza a jugar por el jugador que utilice esta estrategia
}
public interface ITokensGenerator
{
    List<Token> Generated();
}
interface IEndGame
{
    bool IsEndGame(Game game);
}
interface IEndRound
{
    bool IsEndRound(Game game);
}
interface IFirstPlayer// define las distintas formas de empezar el juego
{
    int IndexFirstPlayer(Game game);// llama al primer jugador a jugar
}
interface IScoreCalculator
{
    void ToCalculateScore(Game game);
}
interface IDistribution
{
    void ToDistribute(Game game);
}
interface IMove
{
    List<Token> ItIsAOkPlayed(List<Token> hand);
}
interface IActionModeratorToAdd
{
    List<Token> TokensToAddThatItIsOk();// en el caso que las fichas se puedan jugar en cualquier momento del juego
}
interface IActionModeratorToSub
{
    List<Token> TokensToSubThatItIsNotOk();// en el caso que las fichas no se puedan jugar en juego
}
interface IStep
{
    int IndexNextPlayer(Game game);
}