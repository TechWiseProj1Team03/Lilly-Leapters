using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenMgr : MonoBehaviour
{
   public void OnMainMenuClick()
   {
        SceneManager.LoadScene("MainMenu");
        AudioMgr.instance.StopSound();
   }

   public void OnRetryClicked()
   {    
        //  For now we just load the first level again, our game is small enough that having the player just start here is fine
        SceneManager.LoadScene("Level1");
        AudioMgr.instance.StopSound();
   }
}
