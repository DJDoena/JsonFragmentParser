using System;

namespace DoenaSoft.JsonFragmentParser;

public sealed class ParseException(string message)
    : Exception(message)
{
}