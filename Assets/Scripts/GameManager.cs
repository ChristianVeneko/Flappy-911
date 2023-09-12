using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] public GameObject gameOverText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Player player;
    [SerializeField] private GameObject startText;

    public int score = 0;
    public bool gameStarted = false;
    public bool isGameOver = false;
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    public void StartGame()
    {
        gameStarted = true;
        startText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStarted == false && Input.GetMouseButtonDown(0))
        {
            StartGame();
            Debug.Log("We");
        }
        if (player.isDead && Input.GetMouseButtonDown(0))
        {
            RestartGame();
        }
    }
    public void IncreaseScore()
    {
        scoreText.text = score.ToString();
        Debug.Log(score);
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }

    public void RestartGame()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
