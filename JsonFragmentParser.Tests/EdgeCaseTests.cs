using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DoenaSoft.JsonFragmentParser.Tests;

[TestClass]
public sealed class EdgeCaseTests
{
    [TestMethod]
    public void EscapedBackslashBeforeQuote()
    {
        // This is a string containing a single backslash followed by closing quote
        // The backslash is escaped, so the quote should close the string
        const string Input = "{ \"value\":\"test\\\\\" }";

        var cleaned = Clean(Input);

        Assert.AreEqual(Input, cleaned);
    }

    [TestMethod]
    public void MultipleEscapedBackslashes()
    {
        // Even number of backslashes before quote = quote is NOT escaped
        const string Input = "{ \"value\":\"test\\\\\\\\\" }";

        var cleaned = Clean(Input);

        Assert.AreEqual(Input, cleaned);
    }

    [TestMethod]
    public void OddBackslashesBeforeQuote()
    {
        // Odd number of backslashes before quote = quote IS escaped
        const string Input = "{ \"value\":\"test\\\\\\\"\" }";

        var cleaned = Clean(Input);

        Assert.AreEqual(Input, cleaned);
    }

    [TestMethod]
    public void EscapedQuoteInString()
    {
        // Already tested in EndOfJsonParserTests.ObjectEscapedQuote
        const string Input = "{ \"Name\":\"D\\\"J\" }";

        var cleaned = Clean(Input);

        Assert.AreEqual(Input, cleaned);
    }

    [TestMethod]
    public void OtherEscapeSequences()
    {
        const string Input = "{ \"value\":\"line1\\nline2\\ttab\\r\\b\\f\" }";

        var cleaned = Clean(Input);

        Assert.AreEqual(Input, cleaned);
    }

    [TestMethod]
    public void UnicodeEscape()
    {
        const string Input = "{ \"value\":\"test\\u0041\\u0042\" }";

        var cleaned = Clean(Input);

        Assert.AreEqual(Input, cleaned);
    }

    [TestMethod]
    public void EmptyObject()
    {
        const string Input = "{}";

        var cleaned = Clean(Input);

        Assert.AreEqual(Input, cleaned);
    }

    [TestMethod]
    public void EmptyArray()
    {
        const string Input = "[]";

        var cleaned = Clean(Input);

        Assert.AreEqual(Input, cleaned);
    }

    [TestMethod]
    public void DeeplyNestedStructures()
    {
        const string Input = "{ \"a\": { \"b\": { \"c\": { \"d\": [ [ [ \"value\" ] ] ] } } } }";

        var cleaned = Clean(Input);

        Assert.AreEqual(Input, cleaned);
    }

    [TestMethod]
    public void StringWithBracesAndBrackets()
    {
        const string Input = "{ \"value\":\"text with { braces } and [ brackets ]\" }";

        var cleaned = Clean(Input);

        Assert.AreEqual(Input, cleaned);
    }

    [TestMethod]
    public void NumbersInJson()
    {
        const string Input = "{ \"int\":42, \"negative\":-123, \"decimal\":3.14, \"scientific\":1.23e-4 }";

        var cleaned = Clean(Input);

        Assert.AreEqual(Input, cleaned);
    }

    [TestMethod]
    public void BooleanAndNull()
    {
        const string Input = "{ \"bool1\":true, \"bool2\":false, \"null\":null }";

        var cleaned = Clean(Input);

        Assert.AreEqual(Input, cleaned);
    }

    [TestMethod]
    public void TrailingContent()
    {
        const string Input = "{ \"value\":\"test\" } trailing content";

        var cleaned = Clean(Input);

        const string Expected = "{ \"value\":\"test\" }";

        Assert.AreEqual(Expected, cleaned);
    }

    [TestMethod]
    public void MixedNestedStructures()
    {
        const string Input = "[ { \"arr\": [ 1, 2, 3 ] }, { \"obj\": { \"key\": \"value\" } } ]";

        var cleaned = Clean(Input);

        Assert.AreEqual(Input, cleaned);
    }

    [TestMethod]
    public void MismatchedBraces()
    {
        const string Input = "{ \"value\": ] }";

        try
        {
            Clean(Input);
            Assert.Fail("Expected ParseException was not thrown");
        }
        catch (ParseException)
        {
            // Expected
        }
    }

    [TestMethod]
    public void MismatchedBrackets()
    {
        const string Input = "[ \"value\": } ]";

        try
        {
            Clean(Input);
            Assert.Fail("Expected ParseException was not thrown");
        }
        catch (ParseException)
        {
            // Expected
        }
    }

    [TestMethod]
    public void UnclosedString()
    {
        const string Input = "{ \"value\":\"unclosed }";

        try
        {
            Clean(Input);
            Assert.Fail("Expected ParseException was not thrown");
        }
        catch (ParseException)
        {
            // Expected
        }
    }

    [TestMethod]
    public void InvalidStartCharacter()
    {
        const string Input = "\"just a string\"";

        try
        {
            Clean(Input);
            Assert.Fail("Expected ParseException was not thrown");
        }
        catch (ParseException)
        {
            // Expected
        }
    }

    [TestMethod]
    public void EmptyInput()
    {
        const string Input = "";

        try
        {
            Clean(Input);
            Assert.Fail("Expected ParseException was not thrown");
        }
        catch (ParseException)
        {
            // Expected
        }
    }

    [TestMethod]
    public void WhitespaceOnlyInput()
    {
        const string Input = "   ";

        try
        {
            Clean(Input);
            Assert.Fail("Expected ParseException was not thrown");
        }
        catch (ParseException)
        {
            // Expected
        }
    }

    [TestMethod]
    public void WhitespaceInJson()
    {
        const string Input = "{  \"value\"  :  \"test\"  ,  \"number\"  :  42  }";

        var cleaned = Clean(Input);

        Assert.AreEqual(Input, cleaned);
    }

    [TestMethod]
    public void NewlinesInJson()
    {
        const string Input = "{\n  \"value\": \"test\",\n  \"number\": 42\n}";

        var cleaned = Clean(Input);

        Assert.AreEqual(Input, cleaned);
    }

    internal static string Clean(string input)
        => (new EndOfJsonParser().GetJson(input));
}
