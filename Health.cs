using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public class Health : SceneManage
    public class Health : MonoBehaviour
{
    private Animator _anim;

    [Header("Health Value")]
    [SerializeField] private float _totalHealth;
    public float _currentHealth { get; private set; }



    private bool _dead;

    [Header("IFrame")]
   [SerializeField] private float _iFrameDuration;
   [SerializeField] private int _frameFlash;
    private SpriteRenderer _sprite;


    private void Awake()
    {
        _currentHealth = _totalHealth;
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }


    public void TakeDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth-damage,0, _totalHealth);

        if(_currentHealth > 0)
        {
            _anim.SetTrigger("hurt");
            StartCoroutine(IFrame());
        }
        else
        {
            if (!_dead)
            {
                _anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                _dead = true;
            }
        }
       
    }
    private void Update()
    {

    }

   private IEnumerator IFrame()
    {
        Physics2D.IgnoreLayerCollision(8,9,true);
        for (int i = 0; i <_frameFlash; i++)
        {
            _sprite.color = Color.grey;
            yield return new WaitForSeconds(_iFrameDuration/(_frameFlash*2));
            _sprite.color = Color.white;
            yield return new WaitForSeconds(_iFrameDuration / (_frameFlash * 2));
        }

        Physics2D.IgnoreLayerCollision(8, 9, false);

    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}