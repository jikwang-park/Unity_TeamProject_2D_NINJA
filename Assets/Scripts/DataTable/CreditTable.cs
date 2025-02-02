using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;




public class CreditData
{
    public string Id { get; set; }
    public int MaxFunds { get; set; }
    public int MinFunds {  get; set; }
    public string Icon { get; set; }
    

    public Sprite IconSprite
    {
        get
        {
            return Resources.Load<Sprite>($"icon/{Icon}");
        }
    }
}

public class CreditSaveData
{
    [JsonConverter(typeof(CreditItemDataConverter))]
    public CreditData creditData;
    public int CurrentAmount;
}


public class CreditTable : DataTable
{
    private Dictionary<string,CreditData> creditDictionary = new Dictionary<string,CreditData>();

    public override void Load(string filename)
    {
        var path = string.Format(FormathPath, filename);
        var textAsset = Resources.Load<TextAsset>(path);
        var list = LoadCSV<CreditData>(textAsset.text);

        creditDictionary.Clear();
        foreach(var credit in list)
        {
            if(!creditDictionary.ContainsKey(credit.Id))
            {
                creditDictionary.Add(credit.Id, credit);
            }
            else
            {
                Debug.Log($"Key \'{credit.Id}\' exists already in Credit Table");
            }
        }
    }
    
    public CreditData Get(string key)
    {
        if (!creditDictionary.ContainsKey(key))
        {
            Debug.LogError($"Key \'{key}\' does not exist in Price Table.");
            return default(CreditData);
        }
        else
        {
            return creditDictionary[key];
        }
    }

    public List<string> GetPriceKeyList()
    {
        return creditDictionary.Keys.ToList();
    }
}
