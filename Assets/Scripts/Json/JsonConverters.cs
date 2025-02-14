using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreditItemDataConverter : JsonConverter<CreditData>
{
    public override CreditData ReadJson(JsonReader reader, Type objectType, CreditData existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var Id = (string)reader.Value;
        return DataTableManager.CreditTable.Get(Id);
    }

    public override void WriteJson(JsonWriter writer, CreditData value, JsonSerializer serializer)
    {
        writer.WriteValue(value.Id);
    }
}

public class PlayerStateDataConverter : JsonConverter<PlayerStateData>
{
    public override PlayerStateData ReadJson(JsonReader reader, Type objectType, PlayerStateData existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var Id = (string)reader.Value;
        return DataTableManager.PlayerStateTable.Get(Id);
    }

    public override void WriteJson(JsonWriter writer, PlayerStateData value, JsonSerializer serializer)
    {
        writer.WriteValue(value.Id);
    }
}

public class ItemDataConverter : JsonConverter<ItemData>
{
    public override ItemData ReadJson(JsonReader reader, Type objectType, ItemData existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var Id = (string)reader.Value;
        return DataTableManager.ItemTable.Get(Id);
    }

    public override void WriteJson(JsonWriter writer, ItemData value, JsonSerializer serializer)
    {
        writer.WriteValue(value.Id);
    }
}
