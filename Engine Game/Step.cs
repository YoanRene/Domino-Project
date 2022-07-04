using System.Collections;

namespace Project;
class ClassicStep : IStep
{
    public int IndexNextPlayer(Game game)
    {
        return (game.Cursor + 1) % game.Players.Count;
    }
}
class ChangeDirectionWithPassStep : IStep
{
    public int IndexNextPlayer(Game game)
    {
        if (game.Players[game.Cursor].CountIsContiniousPassed > 0)
            return (game.Cursor - 1 + game.Players.Count) % game.Players.Count;
        ClassicStep classicStep = new();
        return classicStep.IndexNextPlayer(game);
    }
}