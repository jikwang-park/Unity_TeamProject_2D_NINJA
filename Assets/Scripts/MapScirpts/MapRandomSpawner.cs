using System.Collections.Generic;
using UnityEngine;

public class MapRandomSpawner : MonoBehaviour
{

    public List<MapScripts> maps;

    public MapScripts lastGo;

    private int index;

    private bool isSpawned = false;

    private void Awake()
    {

    }


    private void Start()
    {



        if (maps == null || maps.Count == 0)
        {
            Debug.Log("CAN'T FOUND MAPS");
        }


        RandomMapSpawn();
        RandomMapSpawn();
        RandomMapSpawn();

    }

    private void Update()
    {

    }
    public void RandomMapSpawn()
    {
        int rand = Random.Range(0, maps.Count);

        MapScripts newtile = Instantiate(maps[rand], lastGo.endPos.position, Quaternion.identity);
        newtile.spawner = this;
        lastGo = newtile;
    }

}
