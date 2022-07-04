namespace Project;
public class Player
{
    public int CountIsContiniousPassed { get; private set; } = 0;
    public List<Token> Hand { get; } = new List<Token>();
    public SortedSet<int> IDoNotHaveProvedInGame { get; }
    public int TokensCount { get { return Hand.Count; } }
    public string Name { get; }
    public double ScoreGame { get; set; } = 0;
    public double ScoreRound { get; set; } = 0;
    public List <Player> GameMates { get; set; }
    public Player(string name, List <Player> gameMates)
    {
        Name = name;
        IDoNotHaveProvedInGame = new SortedSet<int>();
        GameMates = gameMates;    
    }
    public Token Play(int next,Table table,List<Token> itIsOkPlayed,IStrategy strategy)
    {
        if (itIsOkPlayed.Count == 0)
        {
            IDoNotHaveProvedInGame.Add(table.Left);
            IDoNotHaveProvedInGame.Add(table.Right);
            CountIsContiniousPassed++;
            return null;
        }
        CountIsContiniousPassed = 0;
        Token token = strategy.TokenToPlay(itIsOkPlayed, this, next,table);
        return token;
    }
}