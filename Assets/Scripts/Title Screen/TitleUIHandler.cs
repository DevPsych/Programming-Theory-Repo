using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder (1000)]

public class TitleUIHandler : MonoBehaviour
{
    public int selectedHeroNumber;

    //Move to main scene
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    //Quit application
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    //Select a new hero
    public void NewHeroSelected(int selectedHeroNumber)
    {
        MainManager.instance.selectedHeroNumber = selectedHeroNumber;
    }
}
