using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    
    // Start is called before the first frame update
    private void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    
    // LateUpdate is called after every update in a frame
    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
