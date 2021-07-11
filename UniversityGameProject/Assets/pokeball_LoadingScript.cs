using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokeball_LoadingScript : MonoBehaviour
{
    public float RotationSpeed = 10f;
    public Vector3 rt = new Vector3(0, 1, 0);
    void FixedUpdate()
    {
        transform.Rotate(rt * RotationSpeed);
    }
}
