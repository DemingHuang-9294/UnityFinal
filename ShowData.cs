using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ShowData : MonoBehaviour
{
    private const string _higestScoreName= "Name";
    private const string _higestScore = "Score";

    [SerializeField] TextMeshProUGUI[] _textForName;
    [SerializeField] TextMeshProUGUI[] _textForScore;

    public static int _allowSave = 0;

    void Start()
    {

        DisplayData();

    }
    private void FixedUpdate()
    {
        DisplayData();
    }
  
    public void SaveData()
    {
        int newScore = GameManager._instance.GetScore();
        string newName = GameManager._instance.GetName();

        if (_allowSave >= 1)
        {
            return;
        }
        else
        {

           
            _allowSave++;
            GameManager._instance.ResetForNewPlayer();
            MenuControl.AllowToEnableInpitField();
            SceneMOnPlayAndPause.ResetToStartGameCondition();   
        }

        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey(_higestScore + i))
            {
                if (newScore >= PlayerPrefs.GetInt(_higestScore + i))
                {

                    int tempScore = PlayerPrefs.GetInt(_higestScore + i);
                    string tempName = PlayerPrefs.GetString(_higestScoreName + i);


                    PlayerPrefs.SetInt(_higestScore + i, newScore);
                    PlayerPrefs.SetString(_higestScoreName + i, newName);


                    newScore = tempScore;
                    newName = tempName;
                }
            }
            else
            {
                PlayerPrefs.SetInt(_higestScore + i, newScore);
                PlayerPrefs.SetString(_higestScoreName + i, newName);
                break;
            }

        }

    }
    public void DisplayData()
    {
        for (int i = 0; i <  5; i++)
        {
            if (PlayerPrefs.HasKey(_higestScoreName + i))
            {
                _textForName[i].text="Name :"+PlayerPrefs.GetString(_higestScoreName+i);
                _textForScore[i].text = "Score :" + PlayerPrefs.GetInt(_higestScore+i);
            }
            else
            {
                _textForName[i].text = "Name :";
                _textForScore[i].text = "Score :";
            }


        }
    
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");

        AllowSaveCondition();
        SceneMOnPlayAndPause.ResetToStartGameCondition();
        MenuControl.SetStartBottomActive();
    }


    public void DeleteAllKey()
    {
        PlayerPrefs.DeleteAll();
    }

    public static void AllowSaveCondition()
    {
        _allowSave = 0;
    }
}

