using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    internal static int CurrentLevel = 1;
    
    public void ChangeLevel()
    {
        SceneManager.LoadScene(CurrentLevel);
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
