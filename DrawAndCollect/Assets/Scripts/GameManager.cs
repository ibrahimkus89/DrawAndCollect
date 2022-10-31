using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallThrow _ballThrow;
    [SerializeField] private Drawline _drawline;
    [SerializeField] private GameObject[] Panels;
    [SerializeField] private TextMeshProUGUI[] ScoreTexts;
    [SerializeField] private AudioSource[] Sounds;


    int GBallNumbers;
    void Start()
    {
        Time.timeScale = 0;
        
        if (PlayerPrefs.HasKey("BestScore"))
        {
            ScoreTexts[0].text = PlayerPrefs.GetInt("BestScore").ToString();
            ScoreTexts[1].text = PlayerPrefs.GetInt("BestScore").ToString();

        }
        else
        {
            PlayerPrefs.SetInt("BestScore", 0);
            ScoreTexts[0].text = "0";
            ScoreTexts[1].text = "0";


        }
    }

  
 
    public void Continue()
    {
        GBallNumbers++;
        Sounds[0].Play();
        _ballThrow.Continue();
        _drawline.Continue();
    }

    public void GameOver()
    {
        Sounds[1].Play();
        Panels[1].SetActive(true);
        Panels[2].SetActive(false);



        ScoreTexts[1].text = PlayerPrefs.GetInt("BestScore").ToString();
        ScoreTexts[2].text = GBallNumbers.ToString();

        if (GBallNumbers>PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", GBallNumbers);
            //play effect
           
        }
        
    }


    public void GameStart()
    {
        
        Panels[0].SetActive(false);
        Time.timeScale = 1;
        _ballThrow.GameStart();
        Panels[2].SetActive(true);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
