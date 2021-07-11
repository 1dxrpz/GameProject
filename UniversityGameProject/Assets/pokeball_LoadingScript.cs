using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokeball_LoadingScript : MonoBehaviour
{
    public float RotationSpeed = 10f;
    public Vector3 rt = new Vector3(0, 1, 0);
    float loading = 0;
    void FixedUpdate()
    {
        transform.Rotate(rt * RotationSpeed);
        loading += .2f;
		if (loading >= 40f)
		{
            MainScript.ChangeLevel(MainScript.CurrentLevel);
        }
    }
}
