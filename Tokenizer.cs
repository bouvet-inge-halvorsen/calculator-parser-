namespace Calculator.Parser;

using System.Collections.Generic;
using System.Text;
using System;

public class Lexer
{
    private readonly string _text;
    private int _pos = 0;
    private char _currentChar;

    public Lexer(string text)
    {
        _text = text;
        _currentChar = _text[_pos];
    }

    private void Advance()
    {
        _pos++;
        _currentChar = _pos < _text.Length ? _text[_pos] : '\0';
    }

    private void SkipWhiteSpace()
    {
        while (_currentChar != '\0' && char.IsWhiteSpace(_currentChar))
        {
            Advance();
        }
    }

    private string Number()
    {
        StringBuilder result = new();
        if(_currentChar == ',') _currentChar = '.';
        while (_currentChar != '\0' && (char.IsDigit(_currentChar) || _currentChar == '.'))
        {
            result.Append(_currentChar);
            Advance();
        }
        return result.ToString();
    }

    public List<Token> Tokenize()
    {
        List<Token> tokens = new();

        while(_currentChar != '\0')
        {

            if (char.IsWhiteSpace(_currentChar))
            {
                SkipWhiteSpace();
                continue;
            }

            if (char.IsDigit(_currentChar))
            {
                tokens.Add(new Token(TokenType.Number, Number()));
                continue;
            }

            if (_currentChar == '+')
            {
                tokens.Add(new Token(TokenType.Plus, _currentChar.ToString()));
                Advance();
                continue;
            }

            if (_currentChar == '-')
            {
                tokens.Add(new Token(TokenType.Minus, _currentChar.ToString()));
                Advance();
                continue;
            }

            if (_currentChar == '*')
            {
                tokens.Add(new Token(TokenType.Multiply, _currentChar.ToString()));
                Advance();
                continue;
            }

            if (_currentChar == '/')
            {
                tokens.Add(new Token(TokenType.Divide, _currentChar.ToString()));
                Advance();
                continue;
            }

            if (_currentChar == '(')
            {
                tokens.Add(new Token(TokenType.LeftParen, _currentChar.ToString()));
                Advance();
                continue;
            }

            if (_currentChar == ')')
            {
                tokens.Add(new Token(TokenType.RightParen, _currentChar.ToString()));
                Advance();
                continue;
            }

            throw new Exception($"Unrecognized character: {_currentChar}");

        }
        tokens.Add(new Token(TokenType.EOF, null));
        return tokens;
    }

}