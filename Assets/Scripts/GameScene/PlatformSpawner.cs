using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject prefab;

    public float timeSpawnMin = 2f;
    public float timeSpawnMax = 3f;
    private float timeSpawn;

    // ÇÃ·§Æû y°ª ÃÖ´ë ÃÖ¼ÒÀ§Ä¡
    [SerializeField] private float Ymin = -3.5f;
    [SerializeField] private float Ymax = 1.5f;
    [SerializeField] private float Xpos = 20f;

    private GameObject[] platForms;
    public int platformsCount = 4;
    private int currentIndex = 0;


    private void Awake()
    {
        platForms = new GameObject[platformsCount];
        for (int i = 0; i < platformsCount; ++i)
        {
            platForms[i] = Instantiate(prefab);
            platForms[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (Time.time > timeSpawn)
        {
            SpawnPlatForm();
        }
    }

    private void SpawnPlatForm()
    {
        timeSpawn = Time.time + Random.Range(timeSpawnMin, timeSpawnMax);

        platForms[currentIndex].SetActive(false);

        platForms[currentIndex].SetActive(true);

        platForms[currentIndex].transform.position = new Vector2(Xpos,Random.Range(Ymin, Ymax));

        currentIndex = (currentIndex + 1) % platformsCount;
    }
}
