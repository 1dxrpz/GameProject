using UnityEngine;

public class BuletCheck : MonoBehaviour
{
    private bool PlayerInZone = false;

    public GameObject Player;
    public GameObject zone;
    private bool zoneCreated = false;

    private int counter = 0;
    private Vector3 hitMem;

    GameObject light;
    GameObject zoneCol;
    private void Start()
    {
        light = GameObject.FindGameObjectWithTag("TagForPokebols");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (PlayerInZone)
        {
            transform.position = hitMem;
            counter++;
            if (!zoneCreated)
            {
                zoneCol = Instantiate(zone, transform.position + new Vector3(0,0.1f,0), transform.rotation);
                zoneCreated = true;
            }


            if (counter >= 300)
            {
                Destroy(GameObject.FindGameObjectWithTag("Bulet"));
                Destroy(zoneCol);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerInZone = true;
            hitMem = transform.position;
        }
    }
}
