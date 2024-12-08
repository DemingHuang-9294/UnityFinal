using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMOnPlayAndPause : MonoBehaviour
{

    static private int _notFirstTimeInMenu=0;
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }
    public void RemoveMenuScene()
    {
        if (_notFirstTimeInMenu >= 1)
        {
            SceneManager.UnloadSceneAsync("MainMenu");
        }
       
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
       
        Debug.Log("Game Paused");
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Game Resumed");
    }


    public void DeactiveStartAtMenu()
    {
        MenuControl.SetStartBottomDeactive();
    }
    public static void AllowToStartGameCondition()
    {
        _notFirstTimeInMenu++;
    }
    public static void ResetToStartGameCondition()
    {
        _notFirstTimeInMenu=0;
    }
}
