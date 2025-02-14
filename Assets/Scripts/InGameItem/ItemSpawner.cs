using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private float currentTime = 0f;

    private float potionSpawnTime = 15f;

    private Vector3 playerPos;

    private InfinityModeGameManager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<InfinityModeGameManager>();

    }
    public void SpawnPotion(string id, Vector3 pos)
    {

        var itemData = DataTableManager.ItemTable.Get(id);
        var potion = Instantiate(itemData.ItemPrefab, pos, Quaternion.identity);
        potion.GetComponent<Potion>().Init(itemData.Id, itemData.Amount);
    }

    public void Update()
    {
        playerPos = manager.player.transform.position;
        currentTime += Time.deltaTime;
        if(currentTime > potionSpawnTime)
        {
            RandomPotionSpawn(playerPos);
            Debug.Log("Potion");
            currentTime = 0f;
        }
    }

 
    public void RandomPotionSpawn(Vector3 playerPos)
    {
        int potionIndex = Random.Range(0, (int)PotionSize.Count);
        string potionId = ((PotionSize)potionIndex).ToString();
        Vector3 spawnPos = new Vector3(playerPos.x + 10f, playerPos.y + Random.Range(-1, 2), playerPos.z);
        SpawnPotion(potionId, spawnPos);
    }

}
