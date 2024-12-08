using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeControl : MonoBehaviour
{
   

   [SerializeField] private Slider _volumeSlider; 

    void Start()
    {
       
        _volumeSlider.value = AudioListener.volume;

     
        _volumeSlider.onValueChanged.AddListener(SetVolume);
    }

   
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; 
    }


}
