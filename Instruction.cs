using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    [SerializeField] private GameObject _insctructionPanel;
  




    public void InstructionPanelActivate()
    {
        _insctructionPanel.SetActive(true);
    }


    public void DeactiveTheInstruction()
    {
        gameObject.SetActive(false);
       
    }
}
   
