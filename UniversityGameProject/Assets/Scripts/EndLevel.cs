using UnityEngine;

public class EndLevel : MonoBehaviour
{
	[Header("Next Level")]
    public int NextLevel = 0;
	public UIController UI;
	bool start = false;
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<PlayerController>())
		{
			UI.EndLevel();
			start = true;
		}
	}
	private void Update()
	{
		if (start && !UI.levelChanging)
		{
			MainScript.ChangeLevel(NextLevel);
			start = false;
		}
	}
}
