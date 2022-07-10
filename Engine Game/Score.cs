namespace Project;

public class ScoreCalculatorA : IScoreCalculator
{
    public ScoreCalculatorA(){ }

    public string Print()
    {
        return "Classic"; 
    }

    public void ToCalculateScore(Game game)
    {
        if (game.IsEndRound_)
        {
            double[] score = new double[game.Players.Count];
            for (int i = 0; i < game.Players.Count; i++)
                for (int j = 0; j < game.Players[i].Hand.Count; j++)
                    game.Players[i].ScoreGame += game.Players[i].Hand[j].Right + game.Players[i].Hand[j].Left;
        }
    }
}