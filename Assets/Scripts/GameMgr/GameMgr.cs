using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; 

//  This class is a singleton and is used to manage game state which includes managing players, game time, etc. For our game this will manage the players, 
//  managing loading certain scenes such as the next level, as well as the death and respawn system of players
public class GameMgr : MonoBehaviour
{
    //  Singleton reference to our gamemgr 
    public static GameMgr instance; 

    [Tooltip("This is a reference to our player one so that the gamemgr can manage the player i.e respawn them, etc")]
    public GameObject frogOne; 

    [Tooltip("This is a reference to our player two so that the gamemgr can manage the player i.e respawn them, etc")]
    public GameObject frogTwo; 
    
    [Tooltip("This sets the timers start value, this needs to be seconds entered here.")]
    public float timeSeconds; 

    [Tooltip("Reference to our UI text in game, link UI prefab to this.")]
    public TMP_Text time; 

    //  Class variables for our different units of time 
    private float minutes;  
    private float seconds;
    private float miliseconds; 

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

    // Update is called once per frame
    void Update()
    {
        if (timeSeconds > 0) 
        {
           //   Time.deltaTime is used here as it is the time between frames which is essentially equivalent to a clock over many frames
           timeSeconds -= Time.deltaTime;
           ConvertRemainderToTime(timeSeconds);
        }
        else
        {
            AudioMgr.instance.StopSound();
            SceneManager.LoadScene("DeathScreen");
            Destroy(gameObject);
        }
    }


    //  We handle formatting here 
    void ConvertRemainderToTime(float timeSeconds) 
    {
        //  We add 1 to our seconds so that when we hit 1 instead of staying on 0 for a full second it just says 1 and then the second it hits 0 the game ends
        timeSeconds += 1; 

        //  Round the float down so that we get a normal counter that doesn't jump values
        minutes = Mathf.FloorToInt(timeSeconds / 60);
        seconds = Mathf.FloorToInt(timeSeconds % 60); 
        
        //  We mod by 1 to get the decimal remainder, i.e 1.567 = .567, multiple by 100 to make that a non-decimal 
        miliseconds = (timeSeconds % 1) * 1000; 
        time.SetText(string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, miliseconds));
    }
}
