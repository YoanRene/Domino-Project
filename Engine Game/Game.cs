namespace Project;
class Game
{
    public int Cursor { get; private set; } = -1;
    public IDistribution Distribution { get; }
    public IEndGame EndGame { get; }
    public bool IsEndRound_ { get; private set; } = false;
    public IEndRound EndRound { get; }
    public IScoreCalculator ScoreCalculator { get; }
    public IFirstPlayer FirstPlayer { get; }
    public IActionModeratorToAdd ActionModeratorToAdd { get; }
    public IActionModeratorToSub ActionModeratorToSub { get; }
    public IStep Steps;
    public Table Table_{ get; private set; }
    public List<Player> Players { get; private set; }
    public Game(IDistribution distribution,IEndGame endGame,
                IEndRound endRound,IScoreCalculator scoreCalculator,
                IFirstPlayer firstPlayer, IStep steps,
                IActionModeratorToAdd actionModeratorToAdd,
                IActionModeratorToSub actionModeratorToSub,List<Player> players)
    {
        Steps = steps;
        Distribution = distribution;
        EndGame = endGame;
        EndRound = endRound;
        ScoreCalculator = scoreCalculator;
        FirstPlayer = firstPlayer;
        ActionModeratorToAdd = actionModeratorToAdd;
        ActionModeratorToSub = actionModeratorToSub;
        Players = players;
        Table_ = new Table();
    }
    public bool Play(IStrategy strategy)
    {
        if (Table_.IsStart)
        {
            Distribution.ToDistribute(this);
            Cursor = FirstPlayer.IndexFirstPlayer(this);
            BasicPlay(strategy);
            return true;
        }
        IsEndRound_ = EndRound.IsEndRound(this);
        if (!EndGame.IsEndGame(this))
        {
            if (IsEndRound_)
            {
                Table_ = new Table();
                return true;
            }
            BasicPlay(strategy);
            return true;
        }

        return false;
    }

    public void BasicPlay(IStrategy strategy)
    {
        int next = Steps.IndexNextPlayer(this);
        Player currentPlayer = Players[Cursor];
        List<Token> tokensToPlay = Auxiliar.ValidTokensToPlay(currentPlayer.Hand, ActionModeratorToAdd, ActionModeratorToSub, Table_);
        Token tokenToPlay = Players[Cursor].Play(next, Table_, tokensToPlay, strategy);
        currentPlayer.Hand.Remove(tokenToPlay);
        Table_.Eject(tokenToPlay);
        ScoreCalculator.ToCalculateScore(this);
    }
}
