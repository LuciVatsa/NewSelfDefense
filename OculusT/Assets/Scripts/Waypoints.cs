using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{

    public GameObject[] waypoints;//could also be an array of transforms
    int current = 0;//waypoint headed to
    float rotSpeed;
    public float speed;//gameobject speed
    float WPradius = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)//distance between transformPosition of waypoint and of the object
        {
            current++;//if distance is less than the radius, then we move to the next waypoint
            if (current >= waypoints.Length)//last checkpoint
            {
                current = 0;//back to start -> loop
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);//vector current, target
    }
}
