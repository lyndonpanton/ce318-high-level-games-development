using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 _offset;
    
    // Start is called before the first frame update
    private void Start()
    {
        _offset = transform.position;
    }
    
    // LateUpdate is called after every update in a frame
    private void LateUpdate()
    {
        transform.position = player.transform.position + _offset;
    }
}
