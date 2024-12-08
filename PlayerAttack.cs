using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _anim;

    [Header("PLayer Attack cooldown controll")]
    [SerializeField]private float _attackCoolDown ;
    private float _attackTimer = Mathf.Infinity;



    [Header("FireBall Object")]
    [SerializeField] private GameObject[] _fireBall;
    [SerializeField] private Transform _fireBallPostion;
 


    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {


        if (_attackTimer > _attackCoolDown && Input.GetMouseButtonDown(0))
        {


            Attack();


        }
        else
        {


            _attackTimer += Time.deltaTime;
        }
    }


private void Attack()
    {
        _attackTimer = 0;
        _anim.SetTrigger("attack");
        _fireBall[FindFireBall()].GetComponent<FireBallShootingMovement>().SetPosition(_fireBallPostion);

        //_fireBall[FindFireBall()].GetComponent<FireBallShootingMovement>().SetDirection(Mathf.Sign(transform.localScale.y));
        _fireBall[FindFireBall()].GetComponent<FireBallShootingMovement>().SetDirection();


    }
  

    private int FindFireBall()
    {

        for (int i = 0; i < _fireBall.Length; i++)
        {
            if (!_fireBall[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
        
    }
}
