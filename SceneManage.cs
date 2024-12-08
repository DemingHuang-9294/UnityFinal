using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneManage : MonoBehaviour
{
    [SerializeField] private GameObject[] _ballon;
    private int _ballonDeactive=0;

    

    private void Update()
    {
        _ballonDeactive = FindActiveIn();

        if (_ballonDeactive==-1)
        {
            MoveToNextScene();
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();   
        }


    }


    private int FindActiveIn()
    {

        for (int i = 0; i < _ballon.Length; i++)
        {
            if (_ballon[i].activeInHierarchy)
            {
                return i;
            }
           
        }
        return -1;
    }


    public void ResetScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Score.ResetScore();
    }

   public void MoveToNextScene()
    {

        int currentScene = SceneManager.GetActiveScene().buildIndex;

        int nextScene = currentScene + 1;
        if(nextScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextScene);
            Score.assignScore();
        }
       
    }

   

}
