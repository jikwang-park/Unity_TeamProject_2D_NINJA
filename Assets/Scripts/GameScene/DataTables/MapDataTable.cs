//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public enum MapTypes
//{
//    Long,
//    Short
//}

//public class MapData
//{
//    public string Id { get; set; }

//    public MapTypes Type { get; set; }

//    public string Name { get; set; }

//    public int RoundNum { get; set; }

//    public string PrefabsName { get; set; }

//    public override string ToString()
//    {
//        return $"{Id} / {Type} / {Name} / {RoundNum} / {PrefabsName} ";
//    }

//    public GameObject prefab
//    {
//        get
//        {
//            return Resources.Load<GameObject>($"prefabs/{PrefabsName}");
//        }
//    }
//}
//public class MapDataTable : DataTable
//{
//    private static readonly Dictionary<string, MapData> table = new Dictionary<string, MapData>();

//    public override void Load(string filename)
//    {
//        var path = string.Format(FormatPath, filename);
//        var textAsset = Resources.Load<TextAsset>(path);
//        var list = LoadCSV<MapData>(textAsset.text);
//        table.Clear();
//        foreach (var map in list)
//        {
//            table.Add(map.Id, map);
//        }

//    }

//    public MapData Get(string id)
//    {
//        if (!table.ContainsKey(id))
//            return null;
//        return table[id];
//    }
//}

