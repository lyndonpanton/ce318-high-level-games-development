using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosionController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
