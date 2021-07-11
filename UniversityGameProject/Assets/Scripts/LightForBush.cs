using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightForBush : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<Light>().intensity = 3;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<Light>().intensity = 0;
        }
    }
}
