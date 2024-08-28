namespace Calculator.Test;
using Parser;

[TestClass]
public class ParserTest
{

    [TestInitialize]
    public void BeforeAll()
    {
    }

    [TestMethod]
    public void ParsingAoneShouldReturnAnInt16Of1()
    {
        Lexer lex = new("1");
        List<Token> tokens = lex.Tokenize();
        Parser parser = new(tokens);

        Assert.AreEqual(1, parser.Expr());
    }

    [TestMethod]
    public void ParsingANegativeNumberShouldreturnNegative()
    {
        Lexer lex = new("-1");
        List<Token> tokens = lex.Tokenize();
        Parser parser = new(tokens);

        Assert.AreEqual(-1, parser.Expr());
    }

    
    [TestMethod]
    public void CanAddTwoNumbers()
    {
        Lexer lex = new("1.01 + 1");
        List<Token> tokens = lex.Tokenize();
        Parser parser = new(tokens);

        Assert.AreEqual(2.01, parser.Expr());
    }

    [TestMethod]
    public void CanMultiplyTwoNumbers() 
    {
        Lexer lex = new("3*2");
        List<Token> tokens = lex.Tokenize();
        Parser parser = new(tokens);

        Assert.AreEqual(6, parser.Expr());
    }

    [TestMethod]
    public void CanMultiplyAndAddNumbers()
    {
        Lexer lex = new("1*2*(3+3)");
        List<Token> tokens = lex.Tokenize();
        Parser parser = new(tokens);

        Assert.AreEqual(12.00, parser.Expr());
    }

}