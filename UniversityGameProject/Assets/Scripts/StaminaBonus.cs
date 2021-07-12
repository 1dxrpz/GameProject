using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBonus : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<PlayerController>())
		{
			PlayerController player = other.GetComponent<PlayerController>();
			if (player.Stamina < 1)
			{
				player.Stamina += .2f;
				Destroy(gameObject);
				if (player.Stamina >= 1)
					player.Stamina = 1;
			}
		}
	}
}
