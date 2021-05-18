using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPlaying = false;

    [SerializeField] private Slider timerSlider;
    [SerializeField] private GameObject round1;
    [SerializeField] private GameObject round2;
    [SerializeField] private GameObject round3;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private Text GameOverScore;


    [SerializeField] private float maxLifetimeRound1;
    [SerializeField] private float maxLifetimeRound2;
    [SerializeField] private float maxLifetimeRound3;

    [SerializeField] private List<GameObject> characters;
    [SerializeField] private int CharacterCount;
    [SerializeField] private int EnemyPoolSize;
    [SerializeField] private float RoundLength = 10f;

    private GameObject LevelType;
    private EnemySetter enemySetter;

    private float timer;
    private int round;
    private int score;

    public float maxCharLifetime;
    public float TimeIntervalBetweenSpawns;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        enemySetter = GetComponent<EnemySetter>();
    }
private void Start()
    {
        //characters.Capacity += EnemyPoolSize;
        
        maxCharLifetime = maxLifetimeRound1;
        round = 0;
        score = 0;
        ResetSlider();
    }
    private void Update()
    {
        if (!isPlaying)
            return;
        UpdateSlider();
    }

    public void SetLevelType(GameObject ch)
    {
        LevelType = ch;
    }
    private void UpdateSlider()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
            RoundOver();
        else
            timerSlider.value = timer;

    }
    private void RoundOver()
    {
        round++;
        if (round == 1)
        {
            maxCharLifetime = maxLifetimeRound2;
            enemySetter.SetNewEnemy();
            round1.SetActive(true);
        }
        else if (round == 2)
        {
            maxCharLifetime = maxLifetimeRound3;
            enemySetter.SetNewEnemy();
            round2.SetActive(true);
        }
        else if (round == 3)
        {
            round3.SetActive(true);
            GameOver();
        }
        else
            GameOver();
        ResetSlider();
    }

    public void StartPlaying()
    {
        enemySetter.SetEnemy();
    }
    private void GameOver()
    {
        isPlaying = false;
        GameOverScore.text = scoreText.text;
        LevelType.SetActive(false);

        GameOverScreen.SetActive(true);
    }

    public GameObject GetRandomCharacter()
    {
        int characterIndex = Random.Range(0, characters.Count);
        return Instantiate(characters[characterIndex]);
    }
    public void IncreaseEnemyPool(GameObject ch)
    {
        for (int i = 0; i < EnemyPoolSize; i++)
            characters[CharacterCount+i] = ch;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void ResetSlider()
    {
        timer = RoundLength;
        timerSlider.maxValue = RoundLength;
        timerSlider.value = RoundLength;
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

}
