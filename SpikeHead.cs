using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead :MonoBehaviour
{
    private Vector3 _destination;
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    [SerializeField] private float _checkDelay;
    private float _checkTimer;
    private bool _attacking;
    [SerializeField] private LayerMask _playerLayer;
    private Vector3[] _direction = new Vector3[4];



    private void OnEnable()
    {
        Stop();
        CalculateDirection();
    }
    private void Update()
    {

        if (_attacking)
        {
            transform.Translate(_destination * Time.deltaTime * _speed);
        }
        else
        {
            _checkTimer += Time.deltaTime;
            if (_checkTimer >= _checkDelay)
            {
                CheckForPlayer();

            }

        }



    }

    private void CheckForPlayer()
    {
        

        for (int i = 0; i < _direction.Length; i++)
        {
            Debug.DrawRay(transform.position, _direction[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, _direction[i], _range, _playerLayer);

            if (hit.collider != null && !_attacking)
            {
                _attacking = true;
                _destination = _direction[i];
                _checkTimer = 0;
            }
        }
    }
    private void CalculateDirection()
    {
        _direction[0] = transform.right * _range;
        _direction[1] = -transform.right * _range;
        _direction[2] = transform.up * _range;
        _direction[3] = -transform.up * _range;
    }

    private void Stop()
    {
        _destination = transform.position;
        _attacking = false;
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player" || collision.tag == "Wall" || collision.tag == "Ground")
        {
            Stop();

        }
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(1);
        }


    }



}


