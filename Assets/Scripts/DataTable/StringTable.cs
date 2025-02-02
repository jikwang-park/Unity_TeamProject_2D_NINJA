using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringTable : DataTable
{
    public class Data
    {
        public string Id { get; set; }
        public string String { get; set; }
    }

    private readonly Dictionary<string, string> dictionary = new Dictionary<string, string>();


    public override void Load(string filename)
    {
        var path = string.Format(FormathPath, filename);
        var textAsset = Resources.Load<TextAsset>(path);
        var list = LoadCSV<Data>(textAsset.text);
        dictionary.Clear();
        foreach (var item in list)
        {
            if(!dictionary.ContainsKey(item.Id))
            {
                if (!dictionary.ContainsKey(item.Id))
                {
                    dictionary.Add(item.Id, item.String);
                }
                else
                {
                    Debug.LogError($"Ű �ߺ�: {item.Id}");
                }
            }
        }

    }
    public string Get(string key)
    {
        if (!dictionary.ContainsKey(key))
        {
            return "Ű ����.";
        }
        return dictionary[key];
    }
}
