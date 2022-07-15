namespace Project;

public class ClassicDistributionTen : ObjectWithRandom,IDistribution
{
    public string Print()
    {
        return "Classic";
    }

    public void ToDistribute(List<Token> tokens,List<Player> players,int count)
    {
        for (int i = 0; i < players.Count; i++)
            for (int j = 0; j < count; j++)
            {
                if (tokens.Count > 0)
                {
                    Token token = tokens[Random_.Next(0, tokens.Count)];
                    tokens.Remove(token);
                    players[i].Hand.Add(token);
                }
            }
    }
}
public class DoublesToTrashDistribution : ObjectWithRandom, IDistribution
{
    public string Print()
    {
        return "Doubles To Trash";
    }

    public void ToDistribute(List<Token> tokens,List<Player> players,int count)
    {
        ClassicDistributionTen classicDistribution = new();
        classicDistribution.ToDistribute(tokens,players,count);
      
        foreach (var player in players)
        {
            List<Token> doubleTokens = new List<Token>();
            foreach (var token in player.Hand)
                if (token.IsDouble)
                    doubleTokens.Add(token);
            if (doubleTokens.Count >= 5)
            {
                for (int i = 0; i < doubleTokens.Count; i++)
                {
                    tokens.Add(doubleTokens[i]);
                    player.Hand.Remove(doubleTokens[i]);
                }
                ToDistributeRandomForOne(tokens, player, doubleTokens.Count);
            }
        }
    }

    void ToDistributeRandomForOne(List<Token> tokens,Player player,int count)
    {
        for (int i = 0; i < count; i++)
        {
            Token token = tokens[Random_.Next(0, tokens.Count)];
            player.Hand.Add(token);
        }
    }
}