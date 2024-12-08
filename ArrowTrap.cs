using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
   [SerializeField] private float _arrowTrapcoolDownNeed;
     private float _coolDownTime;

    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject[] _arrowContainer;




    private void Attack()
    {
        _coolDownTime = 0;


        _arrowContainer[FindArrowInHierarchy()].transform.position = _firePoint.position;
        _arrowContainer[FindArrowInHierarchy()].GetComponent<EnemyProjectile>().ActiveObject();
    }

    private int FindArrowInHierarchy()
    {
        for (int i = 0; i < _arrowContainer.Length; i++)
        {
            if (_arrowContainer[i].activeInHierarchy == false)
            {
                return i;
            }
        }
        return 0;
    }
    private void Update()
    {
        _coolDownTime += Time.deltaTime;
        if (_coolDownTime >= _arrowTrapcoolDownNeed)
        {
            Attack();
        }
        
    }

}
