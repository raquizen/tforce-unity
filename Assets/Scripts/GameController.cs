using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Scrip universal para controle do score do game

    public int Score;
    public Text scoreText;
    public int CoinScore;
    public Text coinText;
    public float ScorePerSecond;
    public bool PlayerIsAlive;
    public static GameController current;

    void Start()
    {
        current = this;
        PlayerIsAlive =true;
    }

    float ScoreUpdated;

    void Update()
    {
        if(PlayerIsAlive){
        ScoreUpdated += ScorePerSecond * Time.deltaTime;
        Score = (int)ScoreUpdated;

        //Atualizando elemento de texto da minha interface
        scoreText.text = Score.ToString("0000");
        }
    }

    public void AddScore(int value){
        CoinScore += value;
        coinText.text = CoinScore.ToString("0000");
    }
}
