using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData
{
    public string Id { get; set; }


    public float MaxHp { get; set; }

    public float AttackDamage { get; set; }


    public string MonsterPrefabId { get; set; }

    public GameObject MonsterPrefab;
    
}

public class MonsterDataTable : DataTable
{
    private Dictionary<string, MonsterData> monsterTable = new Dictionary<string, MonsterData>();
    private readonly string assetPath = "Prefab/Monster/{0}";
    public override void Load(string filename)
    {
        var path = string.Format(FormathPath, filename);

        var textAsset = Resources.Load<TextAsset>(path);
        monsterTable.Clear();

        var list = LoadCSV<MonsterData>(textAsset.text);

        foreach ( var monster in list )
        {

            monster.MonsterPrefab = (GameObject)(Resources.Load(string.Format(assetPath, monster.MonsterPrefabId),typeof(GameObject)));
            if(!monsterTable.ContainsKey(monster.Id))
            {
                monsterTable.Add(monster.Id, monster);
            }
            else
            {
                Debug.Log($"Key \'{monster.Id}\' exists already in Credit Table");
            }
        }
    }
    public MonsterData Get(string key)
    {
        if(!monsterTable.ContainsKey(key))
        {
            Debug.LogError($"Key \'{key}\' does not exist in Price Table.");
            return default(MonsterData);
        }
        else
        {
            return monsterTable[key];
        }
    }
    
}


