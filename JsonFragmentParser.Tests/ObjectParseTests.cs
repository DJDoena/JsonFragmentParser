using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DoenaSoft.JsonFragmemtParser.Tests;

[TestClass]
public sealed class ObjectParseTests
{
    [TestMethod]
    public void Object()
    {
        const string Input = "{ \"Name\":\"DJ\" }";

        var jo = JObject.Parse(Input);

        JsonPrinter.PrintObject(jo, []);
    }

    [TestMethod]
    public void RootList()
    {
        var source = new List<Person>()
        {
            new() { Name = "DJ" },
            new() { Name = "Doena" },
        };

        var input = JsonConvert.SerializeObject(source);

        JsonPrinter.PrintInput(input);
    }

    [TestMethod]
    public void AnonymousRootList()
    {
        var source = new[]
        {
            new { Name= "DJ" },
            new { Name= "Doena" },
        };

        var input = JsonConvert.SerializeObject(source);

        JsonPrinter.PrintInput(input);
    }

    [TestMethod]
    public void List()
    {
        const string Input = "{ \"items\": [ { \"Name\":\"DJ\" }, { \"Name\":\"Doena\" } ] }";

        JsonPrinter.PrintInput(Input);
    }

    [TestMethod]
    public void Full()
    {
        const string Input = "{\"items\":\t[{\"id\":\"sn0698388\",\"rowTitle\":\"Tonight I'm Gonna Rock You Tonight\",\"listContent\":[{\"html\":\"(uncredited)\"}\t,{\"html\":\"Written by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0571106/?ref_=ttsnd\\\"\\u003eMichael McKean\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0733427/?ref_=ttsnd\\\"\\u003eHarry Shearer\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001661/?ref_=ttsnd\\\"\\u003eRob Reiner\\u003c/a\\u003e\"}\t,{\"html\":\"Performed by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm2346967/?ref_=ttsnd\\\"\\u003eSpinal Tap\\u003c/a\\u003e\"}],\"expandLimit\":6,\"stackedListItem\":true}\t\t\t,{\"id\":\"sn0698389\",\"rowTitle\":\"Gimme Some Money\",\"listContent\":[{\"html\":\"(uncredited)\"},{\"html\":\"Written by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0571106/?ref_=ttsnd\\\"\\u003eMichael McKean\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0733427/?ref_=ttsnd\\\"\\u003eHarry Shearer\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001661/?ref_=ttsnd\\\"\\u003eRob Reiner\\u003c/a\\u003e\"},{\"html\":\"Performed by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm2346967/?ref_=ttsnd\\\"\\u003eSpinal Tap\\u003c/a\\u003e\"}],\"expandLimit\":6,\"stackedListItem\":true},{\"id\":\"sn0698390\",\"rowTitle\":\"Big Bottom\",\"listContent\":[{\"html\":\"(uncredited)\"},{\"html\":\"Written by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0571106/?ref_=ttsnd\\\"\\u003eMichael McKean\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0733427/?ref_=ttsnd\\\"\\u003eHarry Shearer\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001661/?ref_=ttsnd\\\"\\u003eRob Reiner\\u003c/a\\u003e\"},{\"html\":\"Performed by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm2346967/?ref_=ttsnd\\\"\\u003eSpinal Tap\\u003c/a\\u003e\"}],\"expandLimit\":6,\"stackedListItem\":true},{\"id\":\"sn0698391\",\"rowTitle\":\"All the Way Home\",\"listContent\":[{\"html\":\"(uncredited)\"},{\"html\":\"Written by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0571106/?ref_=ttsnd\\\"\\u003eMichael McKean\\u003c/a\\u003e and \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e\"},{\"html\":\"Performed by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0571106/?ref_=ttsnd\\\"\\u003eMichael McKean\\u003c/a\\u003e and \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e\"}],\"expandLimit\":6,\"stackedListItem\":true},{\"id\":\"sn0698392\",\"rowTitle\":\"Hell Hole\",\"listContent\":[{\"html\":\"(uncredited)\"},{\"html\":\"Written by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0571106/?ref_=ttsnd\\\"\\u003eMichael McKean\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0733427/?ref_=ttsnd\\\"\\u003eHarry Shearer\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001661/?ref_=ttsnd\\\"\\u003eRob Reiner\\u003c/a\\u003e\"},{\"html\":\"Performed by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm2346967/?ref_=ttsnd\\\"\\u003eSpinal Tap\\u003c/a\\u003e\"}],\"expandLimit\":6,\"stackedListItem\":true},{\"id\":\"sn0698393\",\"rowTitle\":\"Cups and Cakes\",\"listContent\":[{\"html\":\"(uncredited)\"},{\"html\":\"Written by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0571106/?ref_=ttsnd\\\"\\u003eMichael McKean\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0733427/?ref_=ttsnd\\\"\\u003eHarry Shearer\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001661/?ref_=ttsnd\\\"\\u003eRob Reiner\\u003c/a\\u003e\"},{\"html\":\"Arranged by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0172339/?ref_=ttsnd\\\"\\u003eHarlan Collins\\u003c/a\\u003e\"},{\"html\":\"Performed by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0571106/?ref_=ttsnd\\\"\\u003eMichael McKean\\u003c/a\\u003e and \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e\"}],\"expandLimit\":6,\"stackedListItem\":true},{\"id\":\"sn0698394\",\"rowTitle\":\"Heartbreak Hotel\",\"listContent\":[{\"html\":\"Written by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm1505678/?ref_=ttsnd\\\"\\u003eMae Boren Axton\\u003c/a\\u003e (as Mae Axton), \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm1509801/?ref_=ttsnd\\\"\\u003eTommy Durden\\u003c/a\\u003e and \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0000062/?ref_=ttsnd\\\"\\u003eElvis Presley\\u003c/a\\u003e\"},{\"html\":\"Performed by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm2346967/?ref_=ttsnd\\\"\\u003eSpinal Tap\\u003c/a\\u003e (uncredited)\"},{\"html\":\"Copyright 1956 by Tree Publishing Co. Inc. Used by permission.\"}],\"expandLimit\":6,\"stackedListItem\":true},{\"id\":\"sn0698395\",\"rowTitle\":\"(Listen to The) Flower People\",\"listContent\":[{\"html\":\"(uncredited)\"},{\"html\":\"Written by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0571106/?ref_=ttsnd\\\"\\u003eMichael McKean\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0733427/?ref_=ttsnd\\\"\\u003eHarry Shearer\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001661/?ref_=ttsnd\\\"\\u003eRob Reiner\\u003c/a\\u003e\"},{\"html\":\"Performed by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm2346967/?ref_=ttsnd\\\"\\u003eSpinal Tap\\u003c/a\\u003e\"}],\"expandLimit\":6,\"stackedListItem\":true},{\"id\":\"sn0698396\",\"rowTitle\":\"Rock \\u0026 Roll Creation\",\"listContent\":[{\"html\":\"(uncredited)\"},{\"html\":\"Written by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0571106/?ref_=ttsnd\\\"\\u003eMichael McKean\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0733427/?ref_=ttsnd\\\"\\u003eHarry Shearer\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001661/?ref_=ttsnd\\\"\\u003eRob Reiner\\u003c/a\\u003e\"},{\"html\":\"Performed by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm2346967/?ref_=ttsnd\\\"\\u003eSpinal Tap\\u003c/a\\u003e\"}],\"expandLimit\":6,\"stackedListItem\":true},{\"id\":\"sn0698397\",\"rowTitle\":\"Heavy Duty\",\"listContent\":[{\"html\":\"(uncredited)\"},{\"html\":\"Written by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0571106/?ref_=ttsnd\\\"\\u003eMichael McKean\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0733427/?ref_=ttsnd\\\"\\u003eHarry Shearer\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001661/?ref_=ttsnd\\\"\\u003eRob Reiner\\u003c/a\\u003e\"},{\"html\":\"Performed by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm2346967/?ref_=ttsnd\\\"\\u003eSpinal Tap\\u003c/a\\u003e\"}],\"expandLimit\":6,\"stackedListItem\":true},{\"id\":\"sn0698398\",\"rowTitle\":\"Stonehenge\",\"listContent\":[{\"html\":\"(uncredited)\"},{\"html\":\"Written by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0571106/?ref_=ttsnd\\\"\\u003eMichael McKean\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0733427/?ref_=ttsnd\\\"\\u003eHarry Shearer\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001661/?ref_=ttsnd\\\"\\u003eRob Reiner\\u003c/a\\u003e\"},{\"html\":\"Performed by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm2346967/?ref_=ttsnd\\\"\\u003eSpinal Tap\\u003c/a\\u003e\"}],\"expandLimit\":6,\"stackedListItem\":true},{\"id\":\"sn0698399\",\"rowTitle\":\"Sex Farm\",\"listContent\":[{\"html\":\"(uncredited)\"},{\"html\":\"Written by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0571106/?ref_=ttsnd\\\"\\u003eMichael McKean\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0733427/?ref_=ttsnd\\\"\\u003eHarry Shearer\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001661/?ref_=ttsnd\\\"\\u003eRob Reiner\\u003c/a\\u003e\"},{\"html\":\"Performed by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm2346967/?ref_=ttsnd\\\"\\u003eSpinal Tap\\u003c/a\\u003e\"}],\"expandLimit\":6,\"stackedListItem\":true},{\"id\":\"sn0698400\",\"rowTitle\":\"Jazz Odyssey\",\"listContent\":[{\"html\":\"(uncredited)\"},{\"html\":\"Written by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0571106/?ref_=ttsnd\\\"\\u003eMichael McKean\\u003c/a\\u003e and \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0733427/?ref_=ttsnd\\\"\\u003eHarry Shearer\\u003c/a\\u003e\"},{\"html\":\"Performed by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0571106/?ref_=ttsnd\\\"\\u003eMichael McKean\\u003c/a\\u003e and \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0733427/?ref_=ttsnd\\\"\\u003eHarry Shearer\\u003c/a\\u003e\"}],\"expandLimit\":6,\"stackedListItem\":true},{\"id\":\"sn0698401\",\"rowTitle\":\"Lick My Love Pump\",\"listContent\":[{\"html\":\"(uncredited)\"},{\"html\":\"Written by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e\"},{\"html\":\"Performed by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e\"}],\"expandLimit\":6,\"stackedListItem\":true},{\"id\":\"sn0698402\",\"rowTitle\":\"The Mule Died\",\"listContent\":[{\"html\":\"(uncredited)\"},{\"html\":\"Written by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e\"},{\"html\":\"Performed by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e\"}],\"expandLimit\":6,\"stackedListItem\":true},{\"id\":\"sn0698403\",\"rowTitle\":\"A Grateful Nation\",\"listContent\":[{\"html\":\"(uncredited)\"},{\"html\":\"Written by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0571106/?ref_=ttsnd\\\"\\u003eMichael McKean\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0001302/?ref_=ttsnd\\\"\\u003eChristopher Guest\\u003c/a\\u003e, \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0733427/?ref_=ttsnd\\\"\\u003eHarry Shearer\\u003c/a\\u003e\"},{\"html\":\"Performed by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm2346967/?ref_=ttsnd\\\"\\u003eSpinal Tap\\u003c/a\\u003e\"}],\"expandLimit\":6,\"stackedListItem\":true},{\"id\":\"sn1499915\",\"rowTitle\":\"Minuet from String Quintet in E major, G.275\",\"listContent\":[{\"html\":\"(uncredited)\"},{\"html\":\"Composed by \\u003ca class=\\\"ipc-md-link ipc-md-link--entity\\\" href=\\\"/name/nm0090530/?ref_=ttsnd\\\"\\u003eLuigi Boccherini\\u003c/a\\u003e\"},{\"html\":\"[Played at the end of \\u0026quot;Heavy Duty\\u0026quot;]\"}],\"expandLimit\":6,\"stackedListItem\":true}],\"total\":17,\"endCursor\":\"c24xNDk5OTE1\"}";

        JsonPrinter.PrintInput(Input);
    }
}