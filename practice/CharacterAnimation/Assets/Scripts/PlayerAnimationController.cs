using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public GameObject character;

    void Start()
    {
        character = gameObject;
    }
    
    void Update()
    {
        if (Input.GetButton("1Key"))
        {
            Debug.Log("1 Key");
            character.GetComponent<Animator>().Play("RunFWD_HG01_Anim");    
        }
        
        if (Input.GetButtonDown("2Key"))
        {
            Debug.Log("2 Key");
            character.GetComponent<Animator>().Play("ShootSingleshot_HG01_Anim");
        }
        
        if (Input.GetButtonDown("3Key"))
        {
            Debug.Log("3 Key");
            character.GetComponent<Animator>().Play("Reloading_HG01_Anim");
        }
        
    }
}
