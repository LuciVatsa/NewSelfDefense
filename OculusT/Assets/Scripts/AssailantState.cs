using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssailantState : MonoBehaviour
{
    public Animator anim;
    public bool reset = false;
    public bool poked = false;


    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))//button A
        {
            anim.SetTrigger("pokeApproach");//animations for poke & punch approach and fail state are the same / differ in win state
            anim.SetBool("poke", true);// on launch of approach animation
        }


        //if (Input.GetKeyDown(KeyCode.Space))
        if (OVRInput.Get(OVRInput.Button.Three))//button x
        {
            anim.SetTrigger("groinApproach");
            anim.SetBool("punch", true);


        }

        //if (Input.GetKeyDown(KeyCode.X))
        if (OVRInput.Get(OVRInput.Button.Four))//button Y
        {
            anim.SetTrigger("punchApproach");
            anim.SetBool("groin", true);
        }
        //Eye Poke
        //anim.SetBool("gotPoked", true);
        //groin punch
        //anim.SetBool("groinHit", true);
        //Block
        //anim.SetBool("gotBlock", true);
        //Reset to idle
        //anim.SetBool("reset",true);
        //Reset()
    }

    public void Reset()//button B defined in collisionDetection.cs
    {
        //Clearing out
        //Eye Poke
        anim.SetBool("gotPoked", false);
        //groin punch
        anim.SetBool("groinHit", false);
        //Block
        anim.SetBool("gotBlock", false);
        anim.SetBool("groin", false);
        anim.SetBool("punch", false);
        anim.SetBool("poke", false);
        //Reset to idle
        anim.SetBool("reset",false);
    }

    public void setPoked()
    {
        anim.SetBool("gotPoked", true);
    }

   
}
