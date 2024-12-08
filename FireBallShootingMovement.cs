using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallShootingMovement : MonoBehaviour
{
    private Transform _fireBallTransform;
    private Animator _anim;
    private BoxCollider2D _boxCollider;
    
    [SerializeField] private float _speed;
    private bool hit;
 
    private float _direction;
   


    private float _lifeTime;


   

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _fireBallTransform=GetComponent<Transform>();
        _boxCollider= GetComponent<BoxCollider2D>();
    }

    private void Update()
    {



        if (hit) { return; }

        _fireBallTransform.Translate(_speed * Time.deltaTime, 0, 0);

        _lifeTime += Time.deltaTime;
        if (_lifeTime > 5f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        hit = true;
    
        _boxCollider.enabled = false;
        _anim.SetTrigger("explode");
       
    }

    //public void SetDirection(float direction)
    //{
    //    _lifeTime = 0;
    //    _direction = direction;
    //    gameObject.SetActive(true);
    //    hit = false;
    //    _boxCollider.enabled = true;



    //    float localScalex = transform.localScale.x;
    //    if (Mathf.Sign(localScalex) != direction)
    //    {
    //        localScalex = -localScalex;
    //    }
    //    transform.localScale = new Vector3(localScalex, transform.localScale.y, transform.localScale.z);



    //}

    public void SetDirection()
    {
        _lifeTime = 0;

        gameObject.SetActive(true);
        hit = false;
        _boxCollider.enabled = true;



     

    }


        public void SetPosition(Transform position)
    {
        transform.position = position.position;
    }



  
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
    
}
