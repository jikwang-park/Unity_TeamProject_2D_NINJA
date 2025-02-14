using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSpawner : MonoBehaviour
{
    public List<GameObject> monsterPos;

    private float currentTime = 0f;
    private float SpawnTime = 10f;
    public void Spawn(string id, int spawnPosIndex)
    {
        var monsterData = DataTableManager.MonsterTable.Get(id);
        var monster = Instantiate(monsterData.MonsterPrefab, monsterPos[spawnPosIndex].transform);
        monster.GetComponent<Monster>().Init(monsterData.Id, monsterData.MaxHp, monsterData.AttackDamage);
    }

    private void Start()
    {

    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime>= SpawnTime )
        {
            RandomMonsterSpawn();

            currentTime = 0f;
        }
    }

    public void RandomMonsterSpawn()
    {
        int rand = Random.Range(0, monsterPos.Count);

        // case 1 : using enum
        var monsterIndex = Random.Range(0, (int)Monsters.Count);
        Spawn(((Monsters)monsterIndex).ToString(), rand);
        Debug.Log(((Monsters)monsterIndex).ToString());

    }



 

}
