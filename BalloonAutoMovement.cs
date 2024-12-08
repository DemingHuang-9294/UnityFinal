using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonAutoMovement : MonoBehaviour
{
    private bool _moveLeft;
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    private float _rightMaxDistance;
    private float _leftMaxDistance;
    [SerializeField] private float _growthScaleRstriction;
    private float _elapsedTime = 0f;
 
    private float _maxSizeLifeTime;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;  
 

    private void Awake()
    {
        _audioSource=GetComponent<AudioSource>();   
       
    }
    private void Start()
    {
        _moveLeft =true;
        _rightMaxDistance= transform.position.x+_range;
        _leftMaxDistance = transform.position.x+-_range;
         _maxSizeLifeTime = 0;

}

    private void Update()
    {
       
        if (_moveLeft)
        {
            transform.Translate(-(_speed)*Time.deltaTime,0,0);
            if (transform.position.x <= _leftMaxDistance)
            {
                _moveLeft=false;
            }


        }
        else
        {
            transform.Translate((_speed) * Time.deltaTime, 0, 0);
            if(transform.position.x >= _rightMaxDistance)
            {
                _moveLeft=true;
            }
        }
    }

    private void FixedUpdate()
    {
        _elapsedTime += Time.deltaTime;

        float sizeRestriction = Mathf.Lerp(0.5f, 1.5f, _elapsedTime/_growthScaleRstriction);
       
            transform.localScale = new Vector3(sizeRestriction,sizeRestriction,sizeRestriction);

        if (transform.localScale.x >= 1.5f)
        {
            _maxSizeLifeTime += Time.deltaTime;
            if (_maxSizeLifeTime >= 3f)
            {
                gameObject.SetActive(false);
            }
        }
        
       
    }
    private void ScoreCalculate()
    {
        if (transform.localScale.x <= 1)
        {
            Score.AddScore(2);
        }
        else
        {
            Score.AddScore(1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FireBall")
        {
         

            SoundFxManager._instance.PlaySoundFxClip(_audioClip, transform);
            ScoreCalculate();
            gameObject.SetActive(false);

        }
    }
}
