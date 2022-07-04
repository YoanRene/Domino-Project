namespace Project;
public class IntelligentRandomStrategy : IStrategy
{
    public Token TokenToPlay(List<Token> itIsOkPlayed, Player player, int cursor, Table table)
    {
        IStrategy istrategy = new RandomStrategy();
        List<int> values = Auxiliar.SmartValuesToPlay(itIsOkPlayed, table);
        List<Token> smartTokens = Auxiliar.WinnerTokens(itIsOkPlayed, values, player, cursor, table);

        if (smartTokens.Count != 0)
            return istrategy.TokenToPlay(smartTokens, player, cursor, table);
        return istrategy.TokenToPlay(smartTokens, player, cursor, table);
    }

}
class RandomStrategy : ObjectWithRandom, IStrategy
{
    public Token TokenToPlay(List<Token> itIsOkPlayed, Player player, int cursor, Table table)
    {
        return itIsOkPlayed[Random_.Next(0, itIsOkPlayed.Count)];
    }
}
class BotagordaStrategy : IStrategy
{
    public Token TokenToPlay(List<Token> itIsOkPlayed, Player player, int cursor, Table table)
    {
        List<int> values = new List<int>(itIsOkPlayed.Count);
        for (int i = 0; i < values.Count; i++)
            values[i] += itIsOkPlayed[i].Left + itIsOkPlayed[i].Right;
        return itIsOkPlayed[values.IndexOf(values.Max())];
    }
}

class IntelligentBotagordaStrategy : IStrategy//implementacion de la interface
{
    public Token TokenToPlay(List<Token> itIsOkPlayed, Player player, int cursor, Table table)
    {
        List<int> smartValues = Auxiliar.SmartValuesToPlay(itIsOkPlayed, table);
        List<Token> intelligentplays = Auxiliar.WinnerTokens(itIsOkPlayed, smartValues, player, cursor, table);
        BotagordaStrategy botagordaStrategy = new BotagordaStrategy();

        if (intelligentplays.Count > 0)
            return botagordaStrategy.TokenToPlay(intelligentplays, player, cursor, table);
        return botagordaStrategy.TokenToPlay(itIsOkPlayed, player, cursor, table);
    }
}

class IntelligentStrategy : IStrategy
{
    public Token TokenToPlay(List<Token> itIsOkPlayed, Player player, int cursor, Table table)
    {
        List<int> smartValuesToPlay = Auxiliar.SmartValuesToPlay(itIsOkPlayed, table);
        List<Token> smartTokens = Auxiliar.WinnerTokens(itIsOkPlayed, smartValuesToPlay, player, cursor, table);

        if (smartTokens.Count > 0)
            return smartTokens[0];

        int piecesNotGame = table.TokensOutGame.Count;

        int[] statsAux = table.Stats;
        for (int i = 0; i < player.Hand.Count; i++)
        {
            statsAux[player.Hand[i].Left]++;
            statsAux[player.Hand[i].Right]++;
        }
        double[] probabilities = new double[smartValuesToPlay.Count];
        double min = double.MaxValue;
        int indexAux = 0;
        for (int i = 0; i < probabilities.Length; i++)
        {
            probabilities[i] = 1 / ((double)(statsAux.Length + 1 - statsAux[smartValuesToPlay[i]]) * piecesNotGame);
            if (min > probabilities[i])
            {
                min = probabilities[i];
                indexAux = i;
            }
        }
        return itIsOkPlayed[indexAux];
    }
}