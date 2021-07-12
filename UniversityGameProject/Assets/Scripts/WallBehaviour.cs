using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{
    internal bool Fall = false;
    bool Particle = true;
    public ParticleController[] Particles;

    void Update()
    {
		if (Fall)
		{
            transform.Translate(Vector3.down * .0025f);
			if (Particle)
			{
				foreach (var item in Particles)
				{
					item.Play();
				}
				Particle = false;
			}
		}
    }
}
