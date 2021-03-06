using UnityEngine;

public class triggerzoneDetect : MonoBehaviour
{
    private bool PlayerInZone;
    private int counter = 0;

    void Update()
    {
        counter++;
        GetComponent<Renderer>().material.color += new Color(0, 0, 0, 0.3f * Time.deltaTime);

        if (PlayerInZone && counter >= 200)
            MainScript.ChangeLevel(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            PlayerInZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            PlayerInZone = false;
    }
}
