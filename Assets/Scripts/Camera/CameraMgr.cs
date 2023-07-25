using UnityEngine;

public class CamerMgr : MonoBehaviour
{
    [Tooltip("Drag camera property on main camera into this slot")]
    //  This references the main camera of the scene and allows access to it's orthographic size 
    public Camera mainCam; 

    [Tooltip("Drag main camera object into this slot")]
    //  This references the main camera's transform object which allows us to move the camera
    public GameObject mainCamPos; 

    [Tooltip("Drag frog one (player 1) object into this slot")]
    //  This references the first player in the lvl
    public GameObject frogOne;

    [Tooltip("Drag frog two (player 2) object into this slot")]
    //  This references the second player in the lvl
    public GameObject frogTwo; 

    [Tooltip("Drag bounding box (gameobject with a collider) into this slot. Prevents players from moving beyond this sqaure i.e the camera's viewport")]
    //  This references our bounding box which prevents the players from moving beyond camera view
    public GameObject cameraBounds; 
    
    [Tooltip("Max size the camera can pan out to.")]
    //  This prevents the camera from zooming out beyond this level 
    public float maxSizeOrthographic = 20; 

    [Tooltip(tooltip: "Min size the camera can pan in to.")]
    //  This porevents the camera from zooming in beyond this level 
    public float minSizeOrthographic = 10;

    //  References for all our collider objects which we assign at runtime 
    private Transform lowerCollider; 
    private Transform upperCollider; 
    private Transform rightCollider; 
    private Transform leftCollider; 

    //  The height of our screen boundary in the game space
    private float height;

    //  The width of our screen boundary in the game space
    private float width;

    //  Called at the start of the game if script is in that scene
    void Start()
    {
        //  Grab all child colliders of our cameraBounds object
        lowerCollider = cameraBounds.transform.Find("BoundBottom");
        upperCollider = cameraBounds.transform.Find("BoundTop");
        rightCollider = cameraBounds.transform.Find("BoundRight");
        leftCollider  = cameraBounds.transform.Find("BoundLeft");

        //  Calculate our screen bounds for the camera's maxed out zoom 
        height = 2f * maxSizeOrthographic;
        width = height * mainCam.aspect; 
    }

    //  Update is called once per frame
    void Update()
    {
        //  Calculate the distance between the frogs x positions
        float distance = frogOne.transform.position.x - frogTwo.transform.position.x;

        //  For our orthographic size we don't want negative values and we want it to stay in our bounds 
        float orthographicDistance = ClampOrthoDistance(Mathf.Abs(distance));

        //  Apply orthgraphic distance to the orthographic size 
        mainCam.orthographicSize = orthographicDistance;

        //  If our orthographic distance is at it's max we enable our boundary to prevent the player from leaving 
        if (orthographicDistance == maxSizeOrthographic) 
        {
            CreateCameraBounds();
        }
        //  Otherwise disable the boundary
        else
        {
            cameraBounds.SetActive(false); 
        }

        //  Adjust the camera position based on the average distance between the two players 
        mainCamPos.transform.position = new Vector3(distance / 2, 0, -10); 
    }

    //  Prevents the orthographic size from going beyond or below our limits and is checked every frame 
    float ClampOrthoDistance(float distance)
    {
        //  Return minsize if we go below the min size (prevents low values)
        if (distance <= minSizeOrthographic) return minSizeOrthographic;

        //  Return maxsize if we go above the max size (prevents high values)
        else if (distance >= maxSizeOrthographic) return maxSizeOrthographic;

        //  Otherwise just set the orthographic size to the current distance
        else return distance; 
    }

    //  Enables and sets the position of all our camera bound colliders to prevent player from navigating further 
    void CreateCameraBounds() 
    {
        //  Get the positon of where all our collider bounds should be in the game scene
        float lowerBound = mainCamPos.transform.position.y - mainCam.orthographicSize;
        float upperBound = mainCamPos.transform.position.y + mainCam.orthographicSize;
        float rightBound = mainCamPos.transform.position.x + (width / 2);
        float leftBound  = mainCamPos.transform.position.x - (width / 2);

        //  Set the position of all our collider bounds within the game scene 
        lowerCollider.position = new Vector3(0, lowerBound, 0);
        upperCollider.position = new Vector3(0, upperBound, 0);
        rightCollider.position = new Vector3(rightBound, 0, 0);
        leftCollider.position = new Vector3(leftBound, 0, 0);

        //  Set our cameraBounds to active 
        cameraBounds.SetActive(true);
    }
}
