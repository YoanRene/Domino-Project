using System.Collections;

namespace Project;
public class ClassicStep : IStep
{
    public int IndexNextPlayer(Game game)
    {
        return (game.Cursor + 1) % game.Players.Count;
    }

    public string Print()
    {
        return "Classic";
    }
}
public class ChangeDirectionWithPassStep : IStep
{
    public int IndexNextPlayer(Game game)
    {
        if (game.Players[game.Cursor].CountIsContiniousPassed > 0)
            return (game.Cursor - 1 + game.Players.Count) % game.Players.Count;
        ClassicStep classicStep = new();
        return classicStep.IndexNextPlayer(game);
    }

    public string Print()
    {
        return "Change Direction With Pass";
    }
}