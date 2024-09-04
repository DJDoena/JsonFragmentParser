using Newtonsoft.Json.Linq;

namespace DoenaSoft.JsonFragmentParser;

public static class JsonTreeBuilder
{
    public static JsonRootNode Build(string input)
    {
        var jt = JToken.Parse(input);

        var rootNode = new JsonRootNode();

        AddToken(jt, rootNode);

        return rootNode;
    }

    private static void AddToken(JToken jt, JsonNodeBase jsonNode)
    {
        if (jt is JObject jo)
        {
            AddObject(jo, jsonNode);
        }
        else if (jt is JArray ija)
        {
            AddArray(ija, jsonNode);
        }
        else if (jt is JProperty jp)
        {
            AddProperty(jp, jsonNode);
        }
        else if (jt is JValue jv && jsonNode is JsonNode jn)
        {
            jn.Value = jv.Value;
        }
        else
        {
            System.Diagnostics.Debug.WriteLine(jt.GetType().Name);
        }
    }

    private static void AddObject(JObject jo, JsonNodeBase jsonNode)
    {
        try
        {
            if (jo.HasValues)
            {
                foreach (var jt in jo.Children())
                {
                    AddToken(jt, jsonNode);
                }
            }
        }
        catch { }
    }

    private static void AddArray(JArray ja, JsonNodeBase jsonNode)
    {
        if (ja.HasValues)
        {
            var index = 0;

            foreach (var jt in ja.Children())
            {
                var childNode = new JsonNode(jsonNode, $"[{index}]");

                jsonNode.Add(childNode);

                AddToken(jt, childNode);

                index++;
            }
        }
    }

    private static void AddProperty(JProperty jp, JsonNodeBase jsonNode)
    {
        if (jp.HasValues)
        {
            foreach (var ijp in jp.Children())
            {
                var childNode = new JsonNode(jsonNode, jp.Name);

                jsonNode.Add(childNode);

                AddToken(ijp, childNode);
            }
        }
        else
        {
            //Debug.WriteLine($"{jp.Name} ({jp.GetType().Name}): {jp.Value}");
        }
    }
}