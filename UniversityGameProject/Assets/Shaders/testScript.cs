using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    // ?? ?????????? ??????? ? ?????????? (??????? ???? ? ???)
            if (Physics.Raycast(ray, out hit))
            {
                print(hit.transform.gameObject.ToString());
            }
        }
    }
}
