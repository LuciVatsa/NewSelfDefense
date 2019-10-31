using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticBuzz : MonoBehaviour

{
    OVRHapticsClip buzz;
    public AudioClip audiofile;

    // Start is called before the first frame update
    void Start()
    {
        buzz = new OVRHapticsClip(audiofile);

    }

    // Update is called once per frame//won't use that since we want to use triggers
    private void OnTriggerEnter(Collider hand)
    {
       OVRHaptics.LeftChannel.Mix(buzz);
       OVRHaptics.RightChannel.Mix(buzz);
    
       if (hand.gameObject.tag == "LeftHand")
        {
            if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            {
                OVRHaptics.LeftChannel.Mix(buzz);
            }
        }

        if (hand.gameObject.tag == "RightHand")
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
            {
                OVRHaptics.RightChannel.Mix(buzz);
            }
        }
        
    }

        private void OnTriggerStay(Collider hand)
    {
        if (hand.gameObject.tag == "LeftHand")
        {
            if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            {
                OVRHaptics.LeftChannel.Mix(buzz);
            }
        }

        if (hand.gameObject.tag == "RightHand")
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
            {
                OVRHaptics.RightChannel.Mix(buzz);
            }
        }
    }

}