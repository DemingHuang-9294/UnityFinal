using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    private string _name;
    private int _score=0;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetScore(int score)
    {
        _score = score;
    }
    public void SetName(string name)
    {
        _name = name;
        Debug.Log("Current Name is:"+" "+_name);
    }
    
    public string GetName()
    {
        return _name;
    }
    public int GetScore()
    {
        return _score;
    }
    public void ResetForNewPlayer()
    {
        Destroy(this.gameObject);
    }

    
}

