namespace Project;
class Generator_9_Variant : ITokensGenerator//genera la cantidad de piezas del juego en base a una cantidad  determinada de valores
{
    public List<Token> Generated()
    {
        return Auxiliar.BasicTokensGenerator(0, 9);
    }
}
class Generator_6_Variant : ITokensGenerator//genera la cantidad de piezas del juego en base a una cantidad  determinada de valores
{
    public List<Token> Generated()
    {
        return Auxiliar.BasicTokensGenerator(0, 6);
    }
}