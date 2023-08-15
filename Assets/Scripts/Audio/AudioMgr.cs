using UnityEngine;
using UnityEngine.UI;

public class AudioMgr : MonoBehaviour
{
    //  Create our singleton, this can also be accessed by other files which we want so frogMovement and FrogMovement2 can access this code and play audio
    public static AudioMgr instance; 

     //  Reference to the menu slider 
    [SerializeField] private Slider _slider = null;

    //  Enables Unity editior to show variable even though it's private 
    [SerializeField] 
    //  Game music and audio sources (needs to be underscore otherwise cannot access the PlayOneShot function)
    private AudioSource _soundEffect; 

    [SerializeField]
    //  _ is for c# private var convention but for some reason it's also needed if we want to access functions for AudioSource
    private AudioSource _music; 

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

    void Start()
    {
        //  We need to add a listener to update when any changes occur so we can adjust the volume
        _slider.onValueChanged.AddListener(value => ChangeMasterVolume(value)); 
    }

    public void PlaySound(AudioClip soundEffect)
    {
        //  We use PlayOneShot() over Play() so we can play multiple sounds at once if needed
        _soundEffect.PlayOneShot(soundEffect); 
    }

    public void ChangeMasterVolume(float volume)
    {
        //  AudioListener is what needs to be modified to change the volume 
        AudioListener.volume = volume;
    }

}
