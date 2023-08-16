using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenMgr : MonoBehaviour
{
   public void OnMainMenuClick()
   {
        SceneManager.LoadScene("MainMenu");
   }

   public void OnRetryClicked()
   {
        SceneManager.LoadScene("Level1");
   }
}
