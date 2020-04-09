using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Sam Ferstein
 * GameManager.cs
 * Assignment 10
 * This manages the game.
 */

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public GameObject titleScreen;
    public Button restartButton;
    public GameObject gOverScreen;
    public bool isGameLost = false;
    public bool isGameWon = false;
    public GameObject gWinScreen;
    private int score;
    public List<GameObject> targets;
    private float spawnRate = 1;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.gameObject.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

        if(score >= 7)
        {
            gameWon();
        }
    }

    public void startGame()
    {
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        isGameLost = false;
        isGameWon = false;
        scoreText.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
    }

    public void gameOver()
    {
        isGameLost = true;
        gOverScreen.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        isGameActive = false;
    }

    public void gameWon()
    {
        isGameWon = true;
        gWinScreen.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
