using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
     static private bool _startBottomSetActive=true;
    [SerializeField] private GameObject _startBottom;







    [Header("UserInputControl")]
    [SerializeField] private TMP_InputField _name;
    [SerializeField] private GameObject[] _degameObject;
    [SerializeField] private GameObject[] _regameObject;
    private static bool _allowToEnableInputField = true;


   
     


    private void Start()
    {
        if (_allowToEnableInputField)
        {
            for (int i = 0; i < _degameObject.Length; i++)
            {
                _degameObject[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < _degameObject.Length; i++)
            {
                _degameObject[i].SetActive(false);
            }
            for (int i = 0; i < _regameObject.Length; i++)
            {
                _regameObject[i].SetActive(true);

            }
        }
        
    }

    public void DoneBottom()
    {
        if (string.IsNullOrWhiteSpace(_name.text))
        {
            return;
        }
        else
        {
            GameManager._instance.SetName(_name.text);
            _allowToEnableInputField = false;
            DeactiveInput();
            ReactiveMenu();
        }
    }

    public void DeactiveInput()
    {
        for (int i = 0; i < _degameObject.Length; i++)
        {

            _degameObject[i].SetActive(false);

        }
    }

    public void ReactiveMenu()
    {
        for (int i = 0; i < _regameObject.Length; i++)
        {

            _regameObject[i].SetActive(true);

        }
    }
    public static void AllowToEnableInpitField()
    {
        _allowToEnableInputField = true;
    }





    public static void SetStartBottomDeactive()
    {
        _startBottomSetActive = false;
    }

    public static void SetStartBottomActive()
    {
        _startBottomSetActive = true;
    }


    public void StartTheGame()
    {
        SceneMOnPlayAndPause.AllowToStartGameCondition();
        if (_startBottomSetActive)
        {
            SceneManager.LoadScene("Level 1");
            
        }
       
    }

    public void ShowRank()
    {
        SceneManager.LoadScene("LastScene");
    }
}
