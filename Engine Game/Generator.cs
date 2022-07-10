namespace Project;
public class Generator_9_Variant : ITokensGenerator//genera la cantidad de piezas del juego en base a una cantidad  determinada de valores
{
    public List<Token> Generated()
    {
        return Auxiliar.BasicTokensGenerator(0, 9);
    }
    public Dictionary<int,(int,int)> Stats()
    {
        Dictionary<int, (int, int)> stats = new Dictionary<int, (int, int)>();
        for (int i = 0; i <= 9; i++)
        {
            stats[i] = (0, 10);
        }
        return stats;
    }
    public string Print()
    {
        return "Double Nine";
    }
}
public class Generator_6_Variant : ITokensGenerator//genera la cantidad de piezas del juego en base a una cantidad  determinada de valores
{
    public List<Token> Generated()
    {
        return Auxiliar.BasicTokensGenerator(0, 6);
    }
    public Dictionary<int, (int, int)> Stats()
    {
        Dictionary<int, (int, int)> stats = new Dictionary<int, (int, int)>();
        for (int i = 0; i <= 6; i++)
        {
            stats[i] = (0, 7);
        }
        return stats;
    }
    public string Print()
    {
        return "Double Six";
    }
}