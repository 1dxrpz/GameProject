using UnityEngine;

public class FlareonTrigger : MonoBehaviour
{
	public ParticleController Flame;
	public WallBehaviour Wall;

    PlayerController Player;
    GameObject interract;
	Collider collider;

    bool spawn = true;
	bool inTrigger = false;

	private void OnTriggerEnter(Collider other)
	{
		collider = other;
		if (other.GetComponent<PlayerController>())
		{
			Player = other.gameObject.GetComponent<PlayerController>();
		}
		inTrigger = true;
		spawn = true;
	}

	private void OnTriggerExit(Collider other)
	{
		inTrigger = false;
		Destroy(interract);
	}
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
				if (inTrigger && Input.GetKeyDown(KeyCode.E) && !Wall.Fall)
				{
					Wall.Fall = true;
					Flame.Play();
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
