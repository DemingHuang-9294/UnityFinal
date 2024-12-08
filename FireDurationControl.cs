using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDurationControl :MonoBehaviour
{
    [Header("FireTimer")]
    [SerializeField] private float _triggerTime;
    [SerializeField] private float _fireDurationTime;


    private Animator _anim;
    private SpriteRenderer _sprite;

    private bool _trigger;
    private bool _active;

   [SerializeField] private float _damage;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        
    }

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !_trigger)
        {

            StartCoroutine(FireTrapActive());

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && _active)
        {
            collision.GetComponent<Health>().TakeDamage(_damage);
        }
    }

    private IEnumerator FireTrapActive()
    {
        _trigger = true;
        for (int i = 0; i < _triggerTime; i++)
        {
            _sprite.color = Color.red;
            yield return new WaitForSeconds(_triggerTime / 6);
            _sprite.color = Color.white;
            yield return new WaitForSeconds(_triggerTime / 6);
            
        }
        _anim.SetBool("active", true);
        _active = true;
        yield return new WaitForSeconds(_fireDurationTime);
        _anim.SetBool("active", false);
        _active = false;
        _trigger = false;



    }


}
