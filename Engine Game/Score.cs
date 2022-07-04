namespace Project;

class ScoreCalculatorA : IScoreCalculator
{
    public ScoreCalculatorA(){ }
    public void ToCalculateScore(Game game)
    {
        double[] score = new double[game.Players.Count];
        for (int i = 0; i < game.Players.Count; i++)
            for (int j = 0; j < game.Players[i].Hand.Count; j++)
                game.Players[i].ScoreGame += game.Players[i].Hand[j].Right+game.Players[i].Hand[j].Left;
    }
}