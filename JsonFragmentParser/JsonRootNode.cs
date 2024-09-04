using System.Linq;

namespace DoenaSoft.JsonFragmemtParser;

public sealed class JsonRootNode : JsonNodeBase
{
    public override string ToString()
        => $"Children: {this.Count()}";
}