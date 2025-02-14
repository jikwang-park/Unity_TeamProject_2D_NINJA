using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemData
{
    public string Id { get; set; }
    public float Amount { get; set; }

    public string ItemPrefabId { get; set; }

    public GameObject ItemPrefab;

}

public class ItemSaveData
{
    [JsonConverter(typeof(ItemDataConverter))]
    public ItemData ItemData { get; set; }
}
public class ItemDataTable : DataTable
{
    private Dictionary<string, ItemData> ItemTable = new Dictionary<string, ItemData>();
    private readonly string assetPath = "Prefab/Item/{0}";
    public override void Load(string filename)
    {
        var path = string.Format(FormathPath, filename);

        var textAsset = Resources.Load<TextAsset>(path);
        ItemTable.Clear();

        var list = LoadCSV<ItemData>(textAsset.text);

        foreach (var Item in list)
        {

            Item.ItemPrefab = Resources.Load<GameObject>(string.Format(assetPath, Item.ItemPrefabId));
            if (!ItemTable.ContainsKey(Item.Id))
            {
                ItemTable.Add(Item.Id, Item);
            }
            else
            {
                Debug.Log($"Key \'{Item.Id}\' exists already in Credit Table");
            }
        }
    }
    public ItemData Get(string key)
    {
        if (!ItemTable.ContainsKey(key))
        {
            Debug.LogError($"Key \'{key}\' does not exist in Item Table.");
            return default(ItemData);
        }
        else
        {
            return ItemTable[key];
        }
    }
    
}
