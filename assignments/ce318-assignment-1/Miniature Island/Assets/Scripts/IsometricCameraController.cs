using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCameraController : MonoBehaviour
{
    [SerializeField] public GameObject focusPlayer;

    public Vector3 offset;
    // Start is called before the first frame update
    private void Start()
    {
        if (focusPlayer != null)
            offset = transform.position - focusPlayer.transform.position;
    }

    private void LateUpdate()
    {
        if (focusPlayer != null)
            transform.position = focusPlayer.transform.position + offset;
    }
}
