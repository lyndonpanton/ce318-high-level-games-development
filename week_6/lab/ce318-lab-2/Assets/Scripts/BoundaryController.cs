using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    // [SerializeField] private GameObject gameController;
    private GameController _gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.Find("GameController")
            .GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        // Debug.Log("Boundary triggered");
        
        if (other.gameObject.CompareTag("Bolt")
            || other.gameObject.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
        }
    }
}
