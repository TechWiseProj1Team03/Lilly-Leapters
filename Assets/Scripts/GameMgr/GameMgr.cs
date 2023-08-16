using TMPro;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    //  Singleton reference to our gamemgr 
    public static GameMgr instance; 
    
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
           timeSeconds -= Time.deltaTime;
           ConvertRemainderToTime(timeSeconds);
        }
        else
        {
            Debug.Log("time is out");
        }
    }

    void ConvertRemainderToTime(float timeSeconds) 
    {
        timeSeconds += 1; 
        minutes = Mathf.FloorToInt(timeSeconds / 60);
        seconds = Mathf.FloorToInt(timeSeconds % 60); 
        miliseconds = (timeSeconds % 1) * 1000; 
        time.SetText(string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, miliseconds));
    }
}
