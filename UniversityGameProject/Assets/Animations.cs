using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Vector3 memVec;
    private float counter = 0;
    private bool check = true;

    private GameObject enemy;

    private Animator anim;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("AnimEnemy").GetComponent<Animator>();
        enemy = GameObject.FindGameObjectWithTag("EnemyBot");
    }

    void Update()
    {
        if(enemy.GetComponent<EnemyScr>().isTroww)
        {
            anim.SetBool("IsTrow", true);
        }
        else
        {
            anim.SetBool("IsTrow", false);
            if (check)
            {
                memVec = GameObject.FindGameObjectWithTag("EnemyBot").transform.position;
                check = false;
            }
            if (counter >= 0.2f)
            {
                if (memVec == GameObject.FindGameObjectWithTag("EnemyBot").transform.position)
                {
                    anim.SetBool("IsWalking", false);
                }
                else
                {
                    //GameObject.FindGameObjectWithTag("AnimEnemy").GetComponent<Animator>().speed = 1.5f;
                    anim.SetBool("IsWalking", true);
                }
                counter = 0;
                check = true;
            }
            counter += 0.1f;
        }
        

        
    }
}
