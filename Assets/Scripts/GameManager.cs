using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject winText;
    public PlayerController player;
    public GameObject titleScreen;
    public Button restartButton;
    public GameObject healthBar;
    public bool isGameActive;
    public Button startButton;
    public SpawnManager spawnManager;
    public int winCondition = 10;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        isGameActive = false;
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(BeginGame);
        gameOverText.SetActive(false);
        winText.SetActive(false);
        
        
    }

    public void BeginGame()
    {
        isGameActive = true;
        spawnManager.StartGame();
        titleScreen.SetActive(false);
        healthBar.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.currentHealth <= 0)
        {
            GameOver();
        }
         if (EnemyMovement.enemiesDestroyed >= winCondition)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        winText.SetActive(true);
        Time.timeScale = 0; // Stop the game
        restartButton.gameObject.SetActive(true);
    }

    void GameOver()
    {
        gameOverText.SetActive(true); // Show the Game Over text
        Time.timeScale = 0; // Stop the game
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
