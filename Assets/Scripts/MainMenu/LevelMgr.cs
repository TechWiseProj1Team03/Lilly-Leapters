using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMgr : MonoBehaviour
{
    //  List of strings which contains all our scene names which is assigned in the editor on the EventSystem component 
    public List<string> sceneNames;

    //  When a button on level select is clicked we pass it's number corresponding to it's level and load the scene that number correlates with
    public void OnLevelSelected(int levelNumber)
    {
        SceneManager.LoadScene(sceneNames[levelNumber]);
    } 
    
}
