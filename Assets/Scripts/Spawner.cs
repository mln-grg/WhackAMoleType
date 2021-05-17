using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] characters; 

    [SerializeField] private float timeIntervalBetweenSpawns=3f;
    [SerializeField] private float characterLife = 2f;
    private float timeElapsed=0f;
    private void Start()
    {
        
    }
    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeIntervalBetweenSpawns)
        {
            Spawn();
            timeElapsed = 0;
        }
    }

    private void Spawn()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        int characterIndex = Random.Range(0, characters.Length);

        GameObject ch = Instantiate(characters[characterIndex],transform);
        ch.transform.localPosition = spawnPoints[spawnIndex].transform.localPosition;
        StartCoroutine(CharacterSpawned(ch, spawnIndex));


    }

    IEnumerator CharacterSpawned(GameObject ch, int spawnIndex)
    {
        spawnPoints[spawnIndex].GetComponent<HoleStatus>().IscharacterVisible = true;
        spawnPoints[spawnIndex].GetComponent<HoleStatus>().CharacterOnHole = ch;
        yield return new WaitForSeconds(characterLife);
        spawnPoints[spawnIndex].GetComponent<HoleStatus>().IscharacterVisible = false;
        Destroy(ch);
    }
}
