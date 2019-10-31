using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haptic : MonoBehaviour
{
    //private AssailantState assailant;
    [SerializeField]
    protected OVRInput.Controller m_controller;
    public AudioClip audiofile;
    OVRHapticsClip buzz;

    // Start is called before the first frame update
    void Start()
    {
        //buzz = new OVRHapticsClip(audiofile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider otherCollider)//for haptic (audiofile)
                                               //everytime the rigidbody on the hands collides with another physical object
    {
        OVRHapticsClip buzz = new OVRHapticsClip(audiofile);
        //if (m_controller == OVRInput.Controller.LTouch)//for default hands
        if (otherCollider.gameObject.tag == "LeftHand")
        {
            OVRHaptics.LeftChannel.Preempt(buzz);
            //assailant.setPoked();
            
        }

        if (otherCollider.gameObject.tag == "RightHand")
        {
            OVRHaptics.RightChannel.Preempt(buzz);
        }
    }

    }
