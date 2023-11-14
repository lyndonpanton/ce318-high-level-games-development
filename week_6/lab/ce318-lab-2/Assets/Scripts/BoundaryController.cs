using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt"))
        {
            Destroy(other.gameObject);
        }
    }
}
