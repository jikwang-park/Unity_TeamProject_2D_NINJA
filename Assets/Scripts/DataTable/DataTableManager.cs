using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class DataTableManager
{
    private static readonly Dictionary<string, DataTable> tables = new Dictionary<string, DataTable>();

    static DataTableManager()
    {
        var table = new CreditTable();
        table.Load(DataTableIds.Credit);
        tables.Add(DataTableIds.Credit, table);

#if UNITY_EDITOR


#else
        var table = new StringTable();
        var stringTableId = DataTableIds.String[(int)Variables.currentLang];
        table.Load(stringTableId);
        tables.Add(stringTableId, table);
#endif


    }

    public static StringTable StringTable
    {
        get
        {
            return Get<StringTable>(DataTableIds.String[(int)Variables.currentLang]);
        }
    }

    public static CreditTable CreditTable
    {
        get
        {
            return Get<CreditTable>(DataTableIds.Credit);
        }
    }




    public static T Get<T>(string id) where T : DataTable
    {
        if (!tables.ContainsKey(id))
        {
            Debug.LogError("테이블 없음");
            return null;
        }
        return tables[id] as T;
    }
}
