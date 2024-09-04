using System.Linq;

namespace DoenaSoft.JsonFragmentParser;

public sealed class JsonRootNode : JsonNodeBase
{
    public override string ToString()
        => $"Children: {this.Count()}";
}