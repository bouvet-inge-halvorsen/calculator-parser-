namespace Calculator.Parser;
using System.Collections.Generic;
using System;
public class Parser
{
    private readonly List<Token> _tokens;
    private int _pos = 0;

    public Parser(List<Token> tokens)
    {
        _tokens = tokens;
    }

    private Token CurrentToken => _tokens[_pos];

    private void Eat(TokenType type)
    {
        if (CurrentToken.Type == type)
        {
            _pos++;
        }
        else
        {
            throw new Exception($"Expected token {type} but got {CurrentToken.Type}");
        }
    }

    private double Factor()
    {
        var token = CurrentToken;

        if (token.Type == TokenType.Number)
        {
            Eat(TokenType.Number);
            return double.Parse(token.Value);
        }
        else if (token.Type == TokenType.LeftParen)
        {
            Eat(TokenType.LeftParen);
            var result = Expr();
            Eat(TokenType.RightParen);
            return result;
        }
        else if (token.Type == TokenType.Plus)
        {
            Eat(TokenType.Plus);
            return +Factor();
        }
        else if (token.Type == TokenType.Minus)
        {
            Eat(TokenType.Minus);
            return -Factor();
        }

        throw new Exception("Unexpected token");
    }

    private double Term()
    {
        var result = Factor();

        while (CurrentToken.Type == TokenType.Multiply || CurrentToken.Type == TokenType.Divide)
        {
            var token = CurrentToken;

            if (token.Type == TokenType.Multiply)
            {
                Eat(TokenType.Multiply);
                result *= Factor();
            }
            else if (token.Type == TokenType.Divide)
            {
                Eat(TokenType.Divide);
                result /= Factor();
            }
        }

        return result;
    }

    public double Expr()
    {
        var result = Term();

        while (CurrentToken.Type == TokenType.Plus || CurrentToken.Type == TokenType.Minus)
        {
            var token = CurrentToken;

            if (token.Type == TokenType.Plus)
            {
                Eat(TokenType.Plus);
                result += Term();
            }
            else if (token.Type == TokenType.Minus)
            {
                Eat(TokenType.Minus);
                result -= Term();
            }
        }

        return result;
    }
}
