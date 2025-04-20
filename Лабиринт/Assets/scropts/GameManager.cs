using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public Text timerText;

    private float timer;
    private bool isGameActive;

    void Start()
    {
        restartButton.gameObject.SetActive(true);
        restartButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
        if (isGameActive)
        {
            timer += Time.deltaTime;
            UpdateTimerText();
        }
    }

    public void PublicStartGame()
    {
        isGameActive = true;
        timer = 0f;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    void UpdateTimerText()
    {
        timerText.text = "Время: " + timer.ToString("F2") + " секунд";
    }

    public void EndGame()
    {
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        timerText.text = "Игра окончена! Время: " + timer.ToString("F2") + " секунд"; 
       
    }




}
