using System;

namespace DoenaSoft.JsonFragmemtParser;

public sealed class ParseException(string message)
    : Exception(message)
{
}