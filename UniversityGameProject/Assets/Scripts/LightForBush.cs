using UnityEngine;

public class LightForBush : MonoBehaviour
{ 
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
