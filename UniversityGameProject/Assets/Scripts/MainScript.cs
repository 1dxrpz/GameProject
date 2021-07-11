using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    internal static int CurrentLevel = 2;
    
    static public void ChangeLevel()
    {
        SceneManager.LoadScene(CurrentLevel);
    }
    static public void ChangeLevel(int i)
    {
        SceneManager.LoadScene(i);
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
