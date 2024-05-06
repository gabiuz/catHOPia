using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    public GameObject gameOverText;
    public GameObject gameOverScreen;
    public Button retry;
    public Button exit;
    public Button Screenshot;
    public Button Pause;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextWord;
    public TextMeshProUGUI scoreTextGameOver;
    public TextMeshProUGUI scoreTextWordGameOver;
    public TextMeshProUGUI BestScoreText;
    public TextMeshProUGUI BestScoreTextNumber;

    private Player player;
    private Spawner spawner;
    private Parallax parallax;

    private float score;
    private float BestScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        parallax = FindObjectOfType<Parallax>(); 

        NewGame();
    }

    public void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        gameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        retry.gameObject.SetActive(false);
        gameOverScreen.SetActive(false);
        gameOverText.SetActive(false);
        scoreTextGameOver.gameObject.SetActive(false);
        scoreTextWordGameOver.gameObject.SetActive(false);
        BestScoreText.gameObject.SetActive(false);
        BestScoreTextNumber.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        Screenshot.gameObject.SetActive(false);

    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        scoreTextWord.gameObject.SetActive(false);
        retry.gameObject.SetActive(true);
        gameOverScreen.SetActive(true);
        gameOverText.SetActive(true);
        scoreTextWordGameOver.gameObject.SetActive(true);
        scoreTextGameOver.gameObject.SetActive(true);
        BestScoreText.gameObject.SetActive(true);
        BestScoreTextNumber.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);
        Screenshot.gameObject.SetActive(true);
        Pause.gameObject.SetActive(false);

        UpdateBestScore();

        parallax.animationSpeed = 0f;



    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
        scoreTextGameOver.text = Mathf.FloorToInt(score).ToString("D5");
    }

    private void UpdateBestScore()
    {
        float BestScore = PlayerPrefs.GetFloat("BestScore", 0);

        if (score > BestScore)
        {
            BestScore = score;
            PlayerPrefs.SetFloat("BestScore", BestScore);
        }

        BestScoreTextNumber.text = Mathf.FloorToInt(BestScore).ToString("D5");

    }
}
