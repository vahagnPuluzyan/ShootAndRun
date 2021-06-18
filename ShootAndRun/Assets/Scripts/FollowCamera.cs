using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    [SerializeField] float _distance;

    void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,target.position.z - _distance); 
    }
}
