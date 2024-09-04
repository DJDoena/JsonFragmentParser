using System.Collections.Generic;
using System.Linq;

namespace DoenaSoft.JsonFragmemtParser;

public sealed class EndOfJsonParser
{
    private const char OpeningBracket = '[';
    private const char OpeningBrace = '{';
    private const char DoubleQuote = '"';
    private const char ClosingBrace = '}';
    private const char ClosingBracket = ']';

    private string Source { get; set; }

    private List<char> Chars { get; set; }

    private List<char> Indentations { get; set; }

    private int CurrentCharIndex { get; set; }

    private char CurrentChar { get; set; }

    private char CurrentIndentation
        => this.Indentations[this.Indentations.Count - 1];

    private string Target
        => (new string([.. this.Chars]));

    public string GetJson(string input)
    {
        this.Chars = new(input.Length);

        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ParseException($"{nameof(input)} is empty.");
        }

        this.Source = input.TrimStart();

        if (this.Source.Length < 2)
        {
            throw new ParseException($"{nameof(input)} is too short.");
        }

        var startChar = this.Source[0];

        this.Chars.Add(startChar);

        this.Indentations =
        [
            startChar,
        ];

        switch (startChar)
        {
            case OpeningBracket:
            case OpeningBrace:
                {
                    this.AddChars();

                    break;
                }
            default:
                {
                    throw new ParseException("Unknown JSON token");
                }
        }

        if (!this.Indentations.Any())
        {
            return this.Target;
        }
        else
        {
            throw new ParseException("JSON is not well formatted");
        }
    }

    private void AddChars()
    {
        for (this.CurrentCharIndex = 1; this.CurrentCharIndex < this.Source.Length; this.CurrentCharIndex++)
        {
            this.CurrentChar = this.Source[this.CurrentCharIndex];

            if (this.AddChar())
            {
                break;
            }
        }
    }

    private bool AddChar()
    {
        switch (this.CurrentChar)
        {
            case DoubleQuote:
                {
                    this.OpenOrCloseQuote();

                    break;
                }
            case OpeningBracket:
            case OpeningBrace:
                {
                    this.OpenIndendation();

                    break;
                }
            case ClosingBrace:
                {
                    this.CloseIndentaion(OpeningBrace);

                    break;
                }
            case ClosingBracket:
                {
                    this.CloseIndentaion(OpeningBracket);

                    break;
                }
            default:
                {
                    this.Chars.Add(this.CurrentChar);

                    break;
                }
        }

        return this.Indentations.Count == 0;
    }

    private void OpenOrCloseQuote()
    {
        if (this.CurrentIndentation == DoubleQuote)
        {
            if (!this.IsInsideString())
            {
                this.Indentations.RemoveAt(this.Indentations.Count - 1);
            }
        }
        else
        {
            this.Indentations.Add(this.CurrentChar);
        }

        this.Chars.Add(this.CurrentChar);
    }

    private void OpenIndendation()
    {
        if (!this.IsInsideString())
        {
            this.Indentations.Add(this.CurrentChar);
        }

        this.Chars.Add(this.CurrentChar);
    }

    private void CloseIndentaion(char indentationToLookFor)
    {
        if (!this.IsInsideString())
        {
            if (this.CurrentIndentation == indentationToLookFor)
            {
                this.Indentations.RemoveAt(this.Indentations.Count - 1);

                this.Chars.Add(this.CurrentChar);
            }
            else
            {
                throw new ParseException("JSON is not well formatted");
            }
        }
        else
        {
            this.Chars.Add(this.CurrentChar);
        }
    }

    private bool IsInsideString()
    {
        if (this.CurrentIndentation == DoubleQuote)
        {
            if (this.CurrentChar == DoubleQuote)
            {
                var previousChar = this.Source[this.CurrentCharIndex - 1];

                if (previousChar == '\\')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }
}