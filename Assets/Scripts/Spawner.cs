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
        int characterIndex = Random.Range(0, characters.Length);
        float characterLife = Random.Range(1, GameManager.instance.maxCharLifetime);

        
        GameObject ch = Instantiate(characters[characterIndex],transform);
        
        ch.transform.localPosition = spawnPoints[spawnIndex].transform.localPosition;
        spawnPoints[spawnIndex].GetComponent<HoleStatus>().isHoleEmpty = false;
        spawnPoints[spawnIndex].GetComponent<HoleStatus>().CharacterOnHole = ch;
        Destroy(ch, characterLife);
    }

  
}
