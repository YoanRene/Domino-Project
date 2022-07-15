namespace Project;
public class IntelligentRandomStrategy : IStrategy
{
    public string Print()
    {
        return "Intelligent Random";
    }

    public Token TokenToPlay(List<Token> itIsOkPlayed, Player player, int cursor, Table table)
    {
        IStrategy strategy = new RandomStrategy();
        List<int> values = Auxiliar.ValuesToPlay(itIsOkPlayed, table);
        List<Token> smartTokens = Auxiliar.WinnerTokens(itIsOkPlayed, values, player, cursor, table);

        if (smartTokens.Count != 0)
            return strategy.TokenToPlay(smartTokens, player, cursor, table);
        return strategy.TokenToPlay(itIsOkPlayed, player, cursor, table);
    }

}
public class RandomStrategy : ObjectWithRandom, IStrategy
{
    public string Print()
    {
        return "Random";
    }

    public Token TokenToPlay(List<Token> itIsOkPlayed, Player player, int cursor, Table table)
    {
        return itIsOkPlayed[Random_.Next(0, itIsOkPlayed.Count)];
    }
}
public class BotagordaStrategy : IStrategy
{
    public string Print()
    {
        return "Botagorda";
    }

    public Token TokenToPlay(List<Token> itIsOkPlayed, Player player, int cursor, Table table)
    {
        List<int> values = new List<int>();
        for (int i = 0; i < itIsOkPlayed.Count; i++)
            values.Add(itIsOkPlayed[i].Left + itIsOkPlayed[i].Right);
        return itIsOkPlayed[values.IndexOf(values.Max())];
    }
}

public class IntelligentBotagordaStrategy : IStrategy
{
    public string Print()
    {
        return "Intelligent Botagorda";
    }

    public Token TokenToPlay(List<Token> itIsOkPlayed, Player player, int cursor, Table table)
    {
        List<int> smartValues = Auxiliar.ValuesToPlay(itIsOkPlayed, table);
        List<Token> intelligentplays = Auxiliar.WinnerTokens(itIsOkPlayed, smartValues, player, cursor, table);
        BotagordaStrategy botagordaStrategy = new BotagordaStrategy();

        if (intelligentplays.Count > 0)
            return botagordaStrategy.TokenToPlay(intelligentplays, player, cursor, table);
        return botagordaStrategy.TokenToPlay(itIsOkPlayed, player, cursor, table);
    }
}

public class IntelligentStrategy : IStrategy
{
    public string Print()
    {
        return "Intelligent";
    }

    public Token TokenToPlay(List<Token> itIsOkPlayed, Player player, int cursor, Table table)
    {
        List<int> valuesToPlay = Auxiliar.ValuesToPlay(itIsOkPlayed, table);
        List<Token> smartTokens = Auxiliar.WinnerTokens(itIsOkPlayed, valuesToPlay, player, cursor, table);

        if (smartTokens.Count > 0)
            return smartTokens[0];

        int piecesNotGame = table.TokensOutGame.Count;

        Dictionary<int, (int, int)> statsAux = table.Stats;
        for (int i = 0; i < player.Hand.Count; i++)
        {
            statsAux[player.Hand[i].Left] = (statsAux[player.Hand[i].Left].Item1 + 1, statsAux[player.Hand[i].Left].Item2);
            statsAux[player.Hand[i].Right] = (statsAux[player.Hand[i].Right].Item1 + 1, statsAux[player.Hand[i].Right].Item2);
        }

        double[] probabilities = new double[valuesToPlay.Count];
        double min = double.MaxValue;
        int indexAux = 0;
        for (int i = 0; i < probabilities.Length; i++)
        {
            probabilities[i] = 1 / ((double)(statsAux[valuesToPlay[i]].Item2 + 1 - statsAux[valuesToPlay[i]].Item1) * piecesNotGame);
            if (min > probabilities[i])
            {
                min = probabilities[i];
                indexAux = i;
            }
        }
        return itIsOkPlayed[indexAux];
    }
}