using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveData 
{
   public int Version { get; protected set; }

    public abstract SaveData VersionUp();

}

public class SaveDataV1 : SaveData
{
    //저장될 데이터들 , 저장되는순간 기억하기

    PlayerStateSaveData playerStateSaveData;

    public SaveDataV1()
    {
        Version = 1;
    }

    public override SaveData VersionUp()
    {
        throw new System.NotImplementedException();
    }
}


