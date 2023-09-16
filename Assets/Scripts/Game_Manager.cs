using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Game_Manager : MonoBehaviour
{
    private int score = 0;
    private bool game_over = false;

    public static Game_Manager instance;

    [SerializeField] private TextMeshProUGUI score_text;
    [SerializeField] private GameObject game_over_text;

    [SerializeField] private GameObject[] health;


    private void Awake()
    {
        instance = this;
        score_text.text = "Score: 0";
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
        }
    }

    public void IncreaseScore(int points)
    {
        score += points;
        score_text.text = "Score: " + score;
    }

    public void GameOver()
    {
        game_over = true;
        game_over_text.SetActive(true);
        Time.timeScale = 0;
    }

    public void TakeDamage(int playerHealth){
        health[playerHealth].SetActive(false);
    }
}
