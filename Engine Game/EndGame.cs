namespace Project;
public class TwicePassesEndGame : IEndGame
{
    public (bool,List<Player>) IsEndGame(Game game)
    {
        List<Player> winners = new();
        foreach (var player in game.Players)
            if (player.CountIsContiniousPassed == 2)
            {
                winners.Add(game.Players[game.Cursor]);
                return (true,winners);
            }
        return (false,new List<Player>());
    }

    public string Print()
    {
        return "Twice Passes";
    }
}
public class ClassicEndRound : IEndRound
{
    public (bool,List<Player>) IsEndRound(Game game)
    {
        List<Player> winners = new();
        int countPass = 0;
        foreach (var player in game.Players)
        {
            if (player.Hand.Count == 0)
            {
                winners.Add(player);
                for (int i = 0; i < player.GameMates.Count; i++)
                    winners.Add(player.GameMates[i]);
                return (true,winners);
            }
            if (player.CountIsContiniousPassed > 0)
            {
                countPass++;
                if (player.CountIsContiniousPassed == game.Players.Count)
                    return (true, new List<Player>());
            }
        }

        if (countPass == game.Players.Count)
            return (true,new List<Player>());
        return (false,new List<Player>());
    }

    public string Print()
    {
        return "Classic";
    }
}
public class ClassicEndGame : IEndGame
{
    public (bool,List<Player>) IsEndGame(Game game)
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
    public (bool,List<Player>) IsEndGame(Game game)
    {
        List<Player> winners = game.Players.ToList();
        for (int i=0;i<game.Players.Count;i++)
            if (game.Players[i].ScoreGame >= 100)
            {
                winners.Remove(game.Players[i]);
                for (int j = 0; j < game.Players[i].GameMates.Count; j++)
                    winners.Remove(game.Players[i].GameMates[j]);
            }
        if(winners.Count==game.Players.Count)
            return (false,new List<Player>());
        return (true,winners);
    }

    public string Print()
    {
        return "Crazy Chicken";
    }
}
