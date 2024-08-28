namespace Calculator.Parser;
using System.Collections.Generic;

#nullable enable
public class Program
{
    public static void Main(string[] args){
        while( true )
        {
            string? input = System.Console.ReadLine();
            if( input == "" || input == "/0" || input == null) break;
            else{
                Lexer lex = new(input);
                List<Token> tokens = lex.Tokenize();
                Parser parser = new(tokens);
                System.Console.WriteLine(parser.Expr().ToString("n2").Replace(",", ""));
            }
        }
    }
}