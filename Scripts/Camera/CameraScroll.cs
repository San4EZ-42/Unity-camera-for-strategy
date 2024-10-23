using System.Diagnostics;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public float scrollSpeed = 10f, smoothTime = 0.3f;  //Set the speed and time values ​​for smooth scrolling
    public float minY = 22f, minYMount = 40f, maxY = 60f;  //Here we define the limits beyond which the camera should not fly along the Y axis.
    public float targetY, currentVelocity;  //Required variables for the Math.SmoothDamp method

    void Start(){
        targetY = transform.position.y;  //We accept in advance the value of the current position of the camera on the map
    }

    void Update()
    {
    float scroll = Input.GetAxis("Mouse ScrollWheel");
    targetY -= scroll * scrollSpeed;
    
    bool isInMountainArea = //We indicate the coordinates where the camera should not fly
    transform.position.x >= 35f && transform.position.x <= 60f 
    && transform.position.z <= -60f && transform.position.z >= -110f; 

    if (isInMountainArea && targetY < minYMount){
        targetY = minYMount;
    }

    targetY = Mathf.Clamp(targetY, minY, maxY); //We specify a ban on the intersection of the specified values ​​minY & maxY

    float newY = Mathf.SmoothDamp(transform.position.y, targetY, ref currentVelocity, smoothTime); //We provide smooth scrolling here

    Vector3 pos = transform.position;
    pos.y = newY;
    transform.position = pos;
    }
}
