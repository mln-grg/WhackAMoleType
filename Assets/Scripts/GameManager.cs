using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private Slider timerSlider;
    [SerializeField] private GameObject round1;
    [SerializeField] private GameObject round2;
    [SerializeField] private GameObject round3;
    [SerializeField] private Text scoreText;



    [SerializeField] private float maxLifetimeRound1;
    [SerializeField] private float maxLifetimeRound2;
    [SerializeField] private float maxLifetimeRound3;
    

    [SerializeField] private float RoundLength = 10f;

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
    }
private void Start()
    {
        maxCharLifetime = maxLifetimeRound1;
        round = 0;
        score = 0;
        ResetSlider();
    }
    private void Update()
    {
        UpdateSlider();
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
            round1.SetActive(true);
        }
        else if (round == 2)
        {
            maxCharLifetime = maxLifetimeRound3;
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

    private void GameOver()
    {

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
