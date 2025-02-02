using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapScripts : MonoBehaviour
{
    public Transform endPos;
    public GameObject[] nextPlatforms;
    public MapRandomSpawner spawner;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("trigger");
        if(col.CompareTag("Player"))
        {
            Debug.Log("player");
            StartCoroutine(destroyPlatform());
        }
    }
    
    private IEnumerator destroyPlatform()
    {
        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
        spawner.RandomMapSpawn();
    }
}
