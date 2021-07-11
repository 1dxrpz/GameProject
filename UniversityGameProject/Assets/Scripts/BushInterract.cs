using UnityEngine;

public class BushInterract : MonoBehaviour
{
	bool inside = false;
	Collider collider;
	Vector3 TempPosition;
	GameObject interract;
	bool spawn = true;
	private void OnTriggerEnter(Collider other)
	{
		inside = true;
		spawn = true;
		collider = other;
	}
	private void OnTriggerExit(Collider other)
	{
		inside = false;
	}
	void Update()
    {
		if (inside && collider.GetComponent<PlayerController>() && collider.GetComponent<PlayerController>().PlayerType == PlayerType.Eevee)
		{
			PlayerController player = collider.GetComponent<PlayerController>();
			if (spawn)
			{
				interract = UIController.CreateMark(UIController.BushMark);
				interract.transform.SetParent(UIController.UI.transform);
				spawn = false;
			}
			if (interract)
			{
				interract.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, .3f, 0));
			}
			if (player.PlayerType == PlayerType.Eevee && Input.GetKeyDown(KeyCode.E))
			{
				if (player.CanWalk)
				{
					player.IsHidden = true;
					TempPosition = player.transform.position;
					player.transform.position = transform.position + new Vector3(0, -.2f, 0);
					Destroy(interract);
				}
				else
				{
					player.IsHidden = false;
					spawn = true;
					player.transform.position = TempPosition;
				}
				player.CanWalk = !player.CanWalk;
				player.Puff(TempPosition + new Vector3(0, -.1f, 0));

			}
		}
		else if (interract)
		{
			Destroy(interract);
		}
    }
}
