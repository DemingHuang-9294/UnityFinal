using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField] private Transform _cameraFollowTo;
    [SerializeField] private float _aheadDistance;
    [SerializeField] private float _cameraSpeed;
    private float _lookAhead;
                            


    private void Update()
    {
        transform.position =  new Vector3(_cameraFollowTo.position.x+_lookAhead,transform.position.y,transform.position.z);
        _lookAhead = Mathf.Lerp(_lookAhead, (_aheadDistance * Mathf.Sign(_cameraFollowTo.localScale.x)),Time.deltaTime*_cameraSpeed);
    }
}
