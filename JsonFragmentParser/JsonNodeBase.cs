using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DoenaSoft.JsonFragmentParser;

public abstract class JsonNodeBase : IEnumerable<JsonNode>
{
    private readonly IList<JsonNode> _children;

    public JsonNode this[int index]
        => _children[index];

    public JsonNode this[string name]
        => _children.FirstOrDefault(c => c.Name == name);

    public int Count
        => _children.Count;

    protected JsonNodeBase()
    {
        _children = [];
    }

    public void Add(JsonNode jsonNode)
    {
        _children.Add(jsonNode);
    }

    public IEnumerator<JsonNode> GetEnumerator()
        => _children.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
}