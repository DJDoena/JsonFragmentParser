using System.Linq;

namespace DoenaSoft.JsonFragmemtParser;
public sealed class JsonNode : JsonNodeBase
{
    public JsonNodeBase Parent { get; }

    public string Name { get; }

    public string ValueAsString
        => this.Value?.ToString();

    public object Value { get; set; }

    public JsonNode(JsonNodeBase parent, string name)
    {
        this.Parent = parent;
        this.Name = name;
    }

    public override string ToString()
    {
        if (!string.IsNullOrEmpty(this.Name))
        {
            if (this.ValueAsString != null)
            {
                return $"{this.Name}: {this.ValueAsString}";
            }
            else
            {
                return $"{this.Name}";
            }
        }
        else
        {
            return $"Children: {this.Count()}";
        }
    }
}