using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject loseUI;
    public GameObject winUI;
    public int score=0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI inGameScoreText;
    void Start()
    {
        
    }


    public void  AddScore( int pointValue)
    {
        score += pointValue;
        scoreText.text = "Score: "+ score;
    } 
    public void NextLevel()
    {
        winUI.gameObject.SetActive(true);
        scoreText.text = "Score: " + score;
        inGameScoreText.gameObject.SetActive(false);

    }
    public void LevelEnd() {
        loseUI.gameObject.SetActive(true);
        scoreText.text = "Score: " + score;
        inGameScoreText.gameObject.SetActive(false);
    }

    public void TryAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
    }

    public void QuitGame() {
     Application.Quit();
    
    }


}
