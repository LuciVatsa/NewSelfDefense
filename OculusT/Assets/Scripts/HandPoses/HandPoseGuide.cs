using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPoseGuide : MonoBehaviour
{
    public HandPose handPose;

    public Color greencolor = new Color(0.0f, 1.0f, 0.0f, 1.0f);
    public Color whitecolor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    //Check for proper hand pose
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UserHandPose>())
        {
            HandPose otherHandPose = other.GetComponent<UserHandPose>().GetHandPose();
            if (otherHandPose == handPose)
            {
                transform.GetComponent<Renderer>().material.color = greencolor;
            }
        }
    }

    //Revert color to white
    private void OnTriggerExit(Collider other)
    {
        transform.GetComponent<Renderer>().material.color = whitecolor;
    }
}
