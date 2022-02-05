using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float trackSpeed = 10;
    
    void LateUpdate() 
    { 
        FollowCamOnX();
    }

    private void FollowCamOnX()
    {
        Vector3 targetTransform = transform.position;
        targetTransform.x = target.position.x;
        transform.position = Vector3.MoveTowards(transform.position, targetTransform,trackSpeed * Time.deltaTime);
    }
}
