using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

   

public class PlayerStateData
{
    public string Id {  get; set; } 
    public int MaxHp {  get; set; }
    public float AttackDamage {  get; set; }
    public float Experience { get; set; }

    public string PlayerPrefabId { get; set; }

    public GameObject PlayerPrefab;
}

public class PlayerStateSaveData
{
    [JsonConverter(typeof(PlayerStateDataConverter))]
    public PlayerStateData playerStateData;
    

}

public class PlayerStateDataTable : DataTable
{
    private Dictionary<string, PlayerStateData> playerStateTable = new Dictionary<string, PlayerStateData>();
    private readonly string assetPath = "Prefab/Player/{0}";
    public override void Load(string filename)
    {
        var path = string.Format(FormathPath, filename);

        var textAsset = Resources.Load<TextAsset>(path);
        playerStateTable.Clear();

        var list = LoadCSV<PlayerStateData>(textAsset.text);

        foreach (var state in list)
        {
            state.PlayerPrefab = Resources.Load<GameObject>(string.Format(assetPath, state.PlayerPrefabId));
            if (!playerStateTable.ContainsKey(state.Id))
            {
                playerStateTable.Add(state.Id, state);
            }
            else
            {
                Debug.Log($"Key \'{state.Id}\' exists already in Credit Table");
            }
        }
    }
    public PlayerStateData Get(string key)
    {
        if (!playerStateTable.ContainsKey(key))
        {
            Debug.LogError($"Key \'{key}\' does not exist in Price Table.");
            return default(PlayerStateData);
        }
        else
        {
            return playerStateTable[key];
        }
    }

}