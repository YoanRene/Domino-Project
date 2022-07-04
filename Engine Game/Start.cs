namespace Project;

class FirstPlayerA : ObjectWithRandom, IFirstPlayer
{
    public FirstPlayerA() { }
    public int IndexFirstPlayer(Game game)
    {
        return Random_.Next(0, game.Players.Count);
    }
}