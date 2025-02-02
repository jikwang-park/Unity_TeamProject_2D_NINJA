using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
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
