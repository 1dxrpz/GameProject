using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public RawImage LoadingBG;
    static public Canvas UI;

    public PlayerController Player;

    public GameObject Interract;
    public GameObject Bush;

    static public GameObject InterractMark;
    static public GameObject BushMark;

    public GameObject RadialMenu;
    public RawImage[] PlayerIconsRadial;
    public RawImage[] PlayerIcons;
    static public GameObject CreateMark(GameObject mark)
    {
        return Instantiate(mark);
    }
    void Start()
    {
        if (MainScript.CurrentLevel != 0)
        {
            
            InterractMark = Interract;
            BushMark = Bush;
            UI = GetComponent<Canvas>();
            foreach (var item in PlayerIconsRadial)
                ChangeAlpha(item, .2f);
        }
    }
    float prevangle = -1;
    float angle = 0;
    bool MenuShown = false;
    internal bool levelChanging = false;
    float alphaEnd = 0;
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
            StartLevel();
        }
        if (MainScript.CurrentLevel != 0)
        {
            if (!Player.IsHidden)
            {
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    Time.timeScale = .5f;
                    MenuShown = true;
                    RadialMenu.SetActive(true);
                }
                if (Input.GetKeyUp(KeyCode.Tab))
                {
                    Time.timeScale = 1;
                    MenuShown = true;
                    RadialMenu.SetActive(false);
                    if (angle == 0)
                        SwitchType(1);
                    else if (angle == -2 || angle == 2)
                        SwitchType(3);
                    else if (angle == 1)
                        SwitchType(0);
                    else
                        SwitchType(2);
                    Player.Puff();
                }
                if (MenuShown)
                {
                    angle = Mathf.Round(Mathf.Atan2(Input.mousePosition.y - Screen.height / 2, Input.mousePosition.x - Screen.width / 2) / (Mathf.PI / 2));
                    if (angle != prevangle)
                    {
                        foreach (var item in PlayerIconsRadial)
                            ChangeAlpha(item, .2f);
                        if (angle == 0)
                            ChangeAlpha(PlayerIconsRadial[1], 1);
                        else if (angle == -2 || angle == 2)
                            ChangeAlpha(PlayerIconsRadial[3], 1);
                        else if (angle == 1)
                            ChangeAlpha(PlayerIconsRadial[0], 1);
                        else
                            ChangeAlpha(PlayerIconsRadial[2], 1);
                    }
                    prevangle = angle;
                }
            }
        }
        if (levelChanging)
		{
            LoadingBG.color = new Color(
                1, 1, 1,
                Mathf.Lerp(LoadingBG.color.a, alphaEnd, .025f)
            );
			if (Mathf.Round(LoadingBG.color.a * 100) / 100 == alphaEnd)
			{
                levelChanging = false;
			}
        }
    }
    void SwitchType(int i)
    {
        foreach (var item in PlayerIcons)
        {
            item.gameObject.SetActive(false);
        }
        Player.PlayerType = (PlayerType)i;
        PlayerIcons[i].gameObject.SetActive(true);
    }
    void ChangeAlpha(RawImage item, float a)
	{
        item.color = new Color(item.color.r, item.color.g, item.color.b, a);
    }
    void StartLevel()
	{
        LoadingBG.color = new Color(1, 1, 1, 1);
        alphaEnd = 0;
        levelChanging = true;
	}
    public void EndLevel()
	{
        LoadingBG.color = new Color(1, 1, 1, 0);
        alphaEnd = 1;
        levelChanging = true;
    }
}
