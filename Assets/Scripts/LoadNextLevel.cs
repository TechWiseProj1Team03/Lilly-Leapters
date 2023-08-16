
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoadNextLevel : MonoBehaviour
{
    [Tooltip("Enter name of scene here and it will be loaded next. Make sure the scene is apart of the build queue in build settings.")]
    public string sceneName; 

    //  When player triggers collider we load the next scene
    void OnTriggerEnter2D(Collider2D otherObj)
    {
        if (otherObj.tag == "FrogOne" || otherObj.tag == "FrogTwo")
        {
            AudioMgr.instance.StopSound();
            SceneManager.LoadScene(sceneName);
        }
    }
}
