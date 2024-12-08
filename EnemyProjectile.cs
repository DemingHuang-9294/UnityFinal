using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
     private float _lifeTimeCount;

    [SerializeField] private float _damage;
    private BoxCollider2D _boxCollider;


    private float _direction;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();   
    }
   
    private void Update() {


        _lifeTimeCount += Time.deltaTime;
        transform.Translate( Time.deltaTime * _speed, 0, 0);


        if (_lifeTimeCount >= _lifeTime)
        {
            _boxCollider.enabled = false;
            gameObject.SetActive(false);
        }
            
            
            
    }


    private void SetScaleDirection()
    {
        if (_speed > 0)
        {
            transform.localScale =new Vector3(0.15f, 0.15f, 0.15f);
        }
        else
        {
            transform.localScale = new Vector3(-0.15f, 0.15f, 0.15f);
        }
        


    }
  

    public void ActiveObject()
    {
        _lifeTimeCount = 0;
        gameObject.SetActive(true);
        SetScaleDirection();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            collision.GetComponent<Health>().TakeDamage(_damage);
            //_boxCollider.enabled = false;
            gameObject.SetActive(false);
        }
    }
}


