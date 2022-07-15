namespace Project;

public class ScoreCalculatorA : IScoreCalculator
{
    public string Print()
    {
        return "Classic";
    }

    public void ToCalculateScore(Game game)
    {
        Auxiliar.ScoreCalculate((i, j) => false, game);
    }
}
public class ScoreCalculatorB : IScoreCalculator
{
    public string Print()
    {
        return "Doubles Have Double Puntuaction";
    }

    public void ToCalculateScore(Game game)
    {
        Auxiliar.ScoreCalculate((i, j) => game.Players[i].Hand[j].IsDouble, game);
    }
}