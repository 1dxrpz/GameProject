using UnityEngine;

public class FlareonTrigger : MonoBehaviour
{
    PlayerController Player;
    GameObject interract;
	Collider collider;

    bool spawn = true;
	bool changing = false;

	private void OnTriggerEnter(Collider other)
	{
		collider = other;
		if (other.GetComponent<PlayerController>())
		{
			Player = other.gameObject.GetComponent<PlayerController>();
		}
		spawn = true;
	}

	private void OnTriggerExit(Collider other)
	{
		Destroy(interract);
	}

    // Update is called once per frame
    void Update()
    {
		if (collider && collider.gameObject.GetComponent<PlayerController>())
		{
			if (Player.PlayerType == PlayerType.Flareon)
			{
				if (spawn)
				{
					interract = UIController.CreateMark(UIController.InterractMark);
					interract.transform.SetParent(UIController.UI.transform);
					spawn = false;
				}
			} else
			{
				
				if (interract)
				{
					Destroy(interract);
				}
			}
		}
		if (interract)
		{
			if (Player.PlayerType == PlayerType.Flareon)
			{
				interract.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, .3f, 0));
			}
			else
			{
				Destroy(interract);
			}
		}
    }
}
