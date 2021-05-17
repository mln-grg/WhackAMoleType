using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] characters; 

    private float timeIntervalBetweenSpawns;
    private float timeElapsed=0f;

    private void Start()
    {
        timeIntervalBetweenSpawns = GameManager.instance.TimeIntervalBetweenSpawns;
        timeElapsed = timeIntervalBetweenSpawns - 1f;
    }
    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeIntervalBetweenSpawns)
        {
            //Spawn();
            for(int i = 0; i < Random.Range(1, spawnPoints.Length); i++)
            {
                Spawn();
            }
            timeElapsed = 0;
        }
    }

    private void Spawn()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        if (!spawnPoints[spawnIndex].GetComponent<HoleStatus>().IsHoleEmpty)
            return;
        int characterIndex = Random.Range(0, characters.Length);
        float characterLife = Random.Range(1, GameManager.instance.maxCharLifetime);

        GameObject ch = Instantiate(characters[characterIndex],transform);
        ch.transform.localPosition = spawnPoints[spawnIndex].transform.localPosition;
        StartCoroutine(CharacterSpawned(ch, spawnIndex,characterLife));


    }

    IEnumerator CharacterSpawned(GameObject ch, int spawnIndex,float characterLife)
    {
        spawnPoints[spawnIndex].GetComponent<HoleStatus>().IsHoleEmpty = false;
        spawnPoints[spawnIndex].GetComponent<HoleStatus>().CharacterOnHole = ch;
        yield return new WaitForSeconds(characterLife);
        spawnPoints[spawnIndex].GetComponent<HoleStatus>().IsHoleEmpty = true;
        Destroy(ch);
    }
}
