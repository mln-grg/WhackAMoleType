using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    private float timeIntervalBetweenSpawns;
    private float timeElapsed=0f;

    private void Start()
    {
        timeIntervalBetweenSpawns = GameManager.instance.TimeIntervalBetweenSpawns;
        timeElapsed = timeIntervalBetweenSpawns - 1f;
    }
    private void Update()
    {
        if (!GameManager.instance.isPlaying)
            return;
        
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeIntervalBetweenSpawns)
        {
            //Spawn();
            for (int i = 0; i < Random.Range(1, spawnPoints.Length); i++)
            {
                Spawn();
            }
            timeElapsed = 0;
        }
    }

    private void Spawn()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        if (!spawnPoints[spawnIndex].GetComponent<HoleStatus>().isHoleEmpty)
            return;
        
        float characterLife = Random.Range(1, GameManager.instance.maxCharLifetime);

        
        GameObject ch = GameManager.instance.GetRandomCharacter();
        ch.transform.position = transform.position;
        ch.transform.parent = transform;
        
        ch.transform.localPosition = spawnPoints[spawnIndex].transform.localPosition;
        spawnPoints[spawnIndex].GetComponent<HoleStatus>().isHoleEmpty = false;
        spawnPoints[spawnIndex].GetComponent<HoleStatus>().CharacterOnHole = ch;
        Destroy(ch, characterLife);
    }

  
}
