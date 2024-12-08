using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
 

   
    static public int _tempScore;

    [SerializeField] private TextMeshProUGUI _scoreText;

   
    private void Update()
    {
        _scoreText.text = "Score"+" "+_tempScore;
        
    }
    private void Start()
    {
        _tempScore = GameManager._instance.GetScore();
    }
    static public void AddScore(int value)
    {
        _tempScore += value;
       
    }
    static public void ResetScore()
    {
        _tempScore = GameManager._instance.GetScore();
    }
    static public void assignScore()
    {
        GameManager._instance.SetScore( _tempScore );

    }
}
