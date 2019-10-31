using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    public Color greencolor = new Color(0.0f, 1.0f, 0.0f, 1.0f);
    public Color whitecolor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    bool bCollision;

    public Animator animator;
    public AssailantState assailant;
    public GameObject obj_assailant;

    public int animationType;
    /*1 Poke
     *2 Punch
     *3 Groin     
    */

 
    // Start is called before the first frame update
    void Start()
    {
        //assailant = GetComponent<AssailantState>();
        //animator = GetComponent<Animator>();
        //animator = gameObject.GetComponent<Animator>();
        //assailant = gameObject.GetComponent<AssailantState>();
        GameObject obj_assailant = GameObject.FindWithTag("Assailant");
        //bCollision = false;
        if (obj_assailant != null)
        {
            animator = obj_assailant.GetComponent<Animator>();
            
        }
        if (obj_assailant == null)
        {
            Debug.Log("Cannot Find Assailaint object");
        }

        if (gameObject.tag == "Poke")
        {
            animationType = 1;
        }

        if (gameObject.tag == "Punch")
        {
            animationType = 2;
        }

        if (gameObject.tag == "Groin")
        {
            animationType = 3;
        }



    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (bCollision)
        {
            animator.SetBool("gotPoked", true);
        }
        */
        

        if (OVRInput.Get(OVRInput.Button.Two))
        {
            if (OVRInput.Get(OVRInput.Button.Two))
            {
                animator.SetBool("reset", true);
                animator.SetBool("gotPoked", false);
                animator.SetBool("gotBlock", false);
                animator.SetBool("groinHit", false);

            }
            
        }
    }

    /*

    //at least one of the colliding objects needs a rigid body
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 point = collision.contacts[0].point;

        foreach( var contact in collision.contacts)//array of all contact points of collision
        {
            
        }
    }
    */
   
   
    private void OnTriggerEnter(Collider other)
    {
        transform.GetComponent<Renderer>().material.color = greencolor;
        //GameObject obj_assailant = GameObject.FindWithTag("Assailant");
        //GameObject obj_animator = GameObject.FindWithTag("Assailant");
        
       
        switch (animationType)
        {
            case 1://poke animation
                animator.SetBool("gotPoked", true);
                break;
            case 2://punch animation
                animator.SetBool("gotBlock", true);
                break;
            case 3://groin animation
                animator.SetBool("groinHit", true);
                break;
        }
        

      /*
       //works
        if (gameObject.tag == "Poke")
        {
            animator.SetBool("gotPoked", true);
        }

        */
        
        /*
        if (obj_assailant != null)
        {
            animator = obj_assailant.GetComponent<Animator>();
            animator.SetBool("gotPoked", true);
        }
        if (obj_assailant == null)
        {
            Debug.Log("Cannot Find Assailaint object");
        }
        */
       
    }


    private void OnTriggerExit(Collider other)
    {
        transform.GetComponent<Renderer>().material.color = whitecolor;
    }
    
}
