using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    //  Create our singleton, this can also be accessed by other files which we want so frogMovement and FrogMovement2 can access this code and play audio
    public static AudioMgr instance; 

    //  Enables Unity editior to show variable even though it's private 
    [SerializeField] 
    //  Game music and audio sources 
    private AudioSource soundEffect; 

    [SerializeField]
    private AudioSource music; 

    //  Function is called when game is loaded 
    void Awake()
    {
        //  If we haven't instanciated our singleton then we do so 
        if (instance == null) 
        {
            instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
        //  Otherwise we destory the gameObject for management purposes
        else 
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip soundEffect)
    {

    }
}
