using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
{

   [SerializeField] private Transform _leftEdge;
   [SerializeField] private Transform _rightEdge;
   [SerializeField] private float _damage;
   [SerializeField] private float _speed;
    private bool _isLeft;


    private void Update()
    {
        if (_isLeft==false)
        {
            transform.localScale = new Vector3(3,3,3);
            transform.Translate(-_speed*Time.deltaTime, 0, 0);
            if (transform.position.x<=_leftEdge.position.x)
            {
                _isLeft = true;
            }
           
        }

        if (_isLeft == true)
        {
            transform.localScale=new Vector3(-3,3,3);
            transform.Translate(_speed*Time.deltaTime, 0, 0);
            if (transform.position.x >= _rightEdge.position.x)
            {
                _isLeft = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            collision.GetComponent<Health>().TakeDamage(_damage);
        }
    }
}
