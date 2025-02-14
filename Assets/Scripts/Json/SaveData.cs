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
    //����� �����͵� , ����Ǵ¼��� ����ϱ�

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


