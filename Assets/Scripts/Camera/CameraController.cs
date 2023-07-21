using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     private Transform _target;
    private void Awake()
    {
        _target = GameObject.FindWithTag("CameraPoint").transform;
    }


    void Update()
    {
        if (_target != null)
        {
            transform.position = _target.position;
            transform.rotation = _target.rotation;
        }

    }
}
