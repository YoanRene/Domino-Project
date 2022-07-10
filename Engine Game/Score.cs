namespace Project;

public class ScoreCalculatorA : IScoreCalculator
{
    public ScoreCalculatorA() { }

    public string Print()
    {
        return "Classic";
    }

    public void ToCalculateScore(Game game)
    {
        Auxiliar_((i, j) => false, game);
    }
    public void Auxiliar_(Func<int, int, bool> func, Game game)
    {
        if (game.IsEndRound_)
        {
            double[] score = new double[game.Players.Count];
            for (int i = 0; i < game.Players.Count; i++)
                for (int j = 0; j < game.Players[i].Hand.Count; j++)
                {
                    if (func(i, j))
                        game.Players[i].ScoreGame += game.Players[i].Hand[j].Right + game.Players[i].Hand[j].Left;
                    game.Players[i].ScoreGame += game.Players[i].Hand[j].Right + game.Players[i].Hand[j].Left;
                }
        }
    }
}
public class ScoreCalculatorB : IScoreCalculator
{
    public ScoreCalculatorB() { }

    public string Print()
    {
        return "Doubles Have Double Puntuaction";
    }

    public void ToCalculateScore(Game game)
    {
        ScoreCalculatorA scoreCalculatorA = new ScoreCalculatorA();
        scoreCalculatorA.Auxiliar_((i, j) => game.Players[i].Hand[j].IsDouble, game);
    }
}