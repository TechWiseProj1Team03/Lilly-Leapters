using UnityEngine;

public class PlayMusicOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip _music; 

    // Start is called before the first frame update
    void Start()
    {
        AudioMgr.instance.PlaySound(_music); 
    }

    
}
