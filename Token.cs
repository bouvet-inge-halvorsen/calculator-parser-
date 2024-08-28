namespace Calculator.Parser;

public enum TokenType
{
    Number,
    Plus,
    Minus,
    Multiply,
    Divide,
    LeftParen,
    RightParen,
    EOF // end of file, end of Expression
}

#nullable enable
public class Token
{
    public TokenType Type { get; }
    public string Value { get; }

    public Token(TokenType type, string? value)
    {
        Type = type;
        Value = value;
    }

    public override string ToString()
    {
        return $"Token({Type}: {Value})";
    }
}