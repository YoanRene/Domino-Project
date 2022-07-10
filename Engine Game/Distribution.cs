namespace Project;

public class ClassicDistributionTen : ObjectWithRandom,IDistribution
{
    public string Print()
    {
        return "Classic Ten";
    }

    public void ToDistribute(Game game)
    {
        for (int i = 0; i < game.Players.Count; i++)
            for (int j = 0; j < 10; j++)
            {
                Token token = game.Table_.TokensTotal[Random_.Next(0, game.Table_.TokensTotal.Count)];
                game.Table_.TokensTotal.Remove(token);
                game.Players[i].Hand.Add(token);
            }
    }
}
public class DoublesToTrashDistribution : ObjectWithRandom, IDistribution
{
    public string Print()
    {
        return "Doubles To Trash";
    }

    public void ToDistribute(Game game)
    {
        ClassicDistributionTen classicDistribution = new();
        classicDistribution.ToDistribute(game);
      
        foreach (var player in game.Players)
        {
            List<Token> doubleTokens = new List<Token>();
            foreach (var token in player.Hand)
                if (token.IsDouble)
                    doubleTokens.Add(token);
            if (doubleTokens.Count >= 5)
            {
                for (int i = 0; i < doubleTokens.Count; i++)
                {
                    game.Table_.TokensTotal.Add(doubleTokens[i]);
                    player.Hand.Remove(doubleTokens[i]);
                }
                ToDistributeRandomForOne(game, player, doubleTokens.Count);
            }
        }
    }

    void ToDistributeRandomForOne(Game game,Player player,int count)
    {
        for (int i = 0; i < count; i++)
        {
            Token token = game.Table_.TokensTotal[Random_.Next(0, game.Table_.TokensTotal.Count)];
            player.Hand.Add(token);
        }
    }
}