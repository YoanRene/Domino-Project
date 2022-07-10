namespace Project;
public class TwicePassesEndGame : IEndGame
{
    public bool IsEndGame(Game game)
    {
        foreach (var player in game.Players)
            if (player.CountIsContiniousPassed == 2)
                return true;
        return false;
    }

    public string Print()
    {
        return "Twice Passes";
    }
}
public class ClassicEndRound : IEndRound
{
    public bool IsEndRound(Game game)
    {
        int countPass = 0;
        foreach (var player in game.Players)
        {
            if (player.Hand.Count == 0)
                return true;
            if (player.CountIsContiniousPassed>0)
                countPass++;
        }
        if (countPass == game.Players.Count)
            return true;
        return false;
    }

    public string Print()
    {
        return "Classic";
    }
}
public class ClassicEndGame : IEndGame
{
    public bool IsEndGame(Game game)//revisar el metodo el ultimo false
    {
        return game.IsEndRound_;
    }

    public string Print()
    {
        return "Classic";
    }
}

public class ChickenEndGame : IEndGame
{
    public bool IsEndGame(Game game)
    {
        foreach (var player in game.Players)
            if (player.ScoreGame >= 100)
                return true;
        return false;
    }

    public string Print()
    {
        return "Chicken";
    }
}
