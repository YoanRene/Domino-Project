namespace Project;
public class Token:IEquatable<Token> // Pieza
{
    public int Left { get; private set; }
    public int Right { get; private set; }
    public bool IsDouble { get; }
    public Token(int left, int right)//constructor
    {
        Left = left;
        Right = right;
        IsDouble = Left == Right;
    }
    public void ToTurn()// Girar la ficha
    {
        int temp = Left;
        Left = Right;
        Right = temp;
    }
    public override string ToString()// pintar la ficha
    {
        return "[" + this.Left + "/" + this.Right + "]";
    }

    public bool Equals(Token? other)
    {
        return (Left == other.Left && Right == other.Right) ||
               (Left == other.Right && Right == other.Left);
    }
}