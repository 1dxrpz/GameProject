using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveSound : MonoBehaviour
{
    private AudioSource source;
    public AudioClip RunMove;
    public AudioClip WalkMove;


    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
