using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    [SerializeField] private AudioClip _sound; 

    // Start is called before the first frame update
    public void PlaySound()
    {
        AudioMgr.instance.PlaySound(_sound); 
    }

    
}
