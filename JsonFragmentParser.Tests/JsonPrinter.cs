using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace DoenaSoft.JsonFragmemtParser.Tests;

internal static class JsonPrinter
{
    internal static void PrintInput(string input)
    {
        var jt = JToken.Parse(input);

        PrintToken(jt, []);
    }

    internal static void PrintObject(JObject jo, List<string> parents)
    {
        try
        {
            if (jo.HasValues)
            {
                foreach (var jt in jo.Children())
                {
                    PrintToken(jt, parents);
                }
            }
        }
        catch { }
    }

    private static void PrintArray(JArray ja, List<string> parents)
    {
        if (ja.HasValues)
        {
            var index = 0;

            foreach (var jt in ja.Children())
            {
                var newParents = new List<string>(parents)
                {
                    $"[{index}]",
                };

                PrintToken(jt, newParents);

                index++;
            }
        }
    }

    private static void PrintToken(JToken jt, List<string> parents)
    {
        if (jt is JObject jo)
        {
            PrintObject(jo, parents);
        }
        else if (jt is JArray ija)
        {
            PrintArray(ija, parents);
        }
        else if (jt is JProperty jp)
        {
            PrintProperty(jp, parents);
        }
        else if (jt is JValue jv)
        {
            var parentText = string.Join("/", parents);

            Debug.WriteLine($"{parentText}: {jv.Value}");
        }
        else
        {
            Debug.WriteLine(jt.GetType().Name);
        }
    }

    private static void PrintProperty(JProperty jp, List<string> parents)
    {
        if (jp.HasValues)
        {
            foreach (var ijp in jp.Children())
            {
                var newParents = new List<string>(parents)
                {
                    jp.Name,
                };

                PrintToken(ijp, newParents);
            }
        }
        else
        {
            Debug.WriteLine($"{jp.Name} ({jp.GetType().Name}): {jp.Value}");
        }
    }
}