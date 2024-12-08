using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFxManager : MonoBehaviour
{
   public static SoundFxManager _instance;

    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    public void PlaySoundFxClip(AudioClip audioClip, Transform spawnTransform)
    {
        AudioSource audioSource = Instantiate(_audioSource,spawnTransform.position,Quaternion.identity);

        audioSource.clip = audioClip;

      //  audioSource.volume = volume;

        audioSource.Play();

        float clipLength=audioSource.clip.length;

      Destroy(audioSource.gameObject,clipLength);
    }
}
