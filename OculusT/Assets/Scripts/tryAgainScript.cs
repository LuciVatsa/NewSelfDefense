using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tryAgainScript : MonoBehaviour
{

    public Animator animator;
    public AssailantState assailant;
    public GameObject obj_assailant;
    public tryAgainScript imageScript;
    public GameObject obj_imageScript;

    public Sprite runSprite;
    public Sprite trySprite;
    public Sprite lateSprite;
    public Sprite goodSprite;

    public SpriteRenderer renderer;

    float timer = 1f;
    float delay = 1f;

    //public AudioClip audiofile;
    public AudioSource runAudio;

    // Start is called before the first frame update
    void Start()
    {
        runAudio = this.gameObject.GetComponent<AudioSource>();
        renderer = this.gameObject.GetComponent<SpriteRenderer>();
        //runAudio.Play();
        // this.gameObject.GetComponent<SpriteRenderer>().sprite = goodSprite;
        //renderer.sprite = goodSprite;
        obj_assailant = GameObject.FindWithTag("Assailant");

        if (obj_assailant != null)
        {
            animator = obj_assailant.GetComponent<Animator>();

        }
        if (obj_assailant == null)
        {
            Debug.Log("Cannot Find Assailaint object");
        }


    }

    public IEnumerator EnableRenderer()
    {
       
        //renderer.enabled = true;
        //animator.SetBool("gotPoked", false);
        //animator.SetBool("groinHit", false);
        //animator.SetBool("gotBlocked", false);
        if (animator.GetBool("gotPoked") || animator.GetBool("groinHit") || animator.GetBool("gotBlock"))
        {
            runAudio.Play();
            renderer.enabled = true;
            //Debug.Log("poked is true in tryagainScript");
            this.gameObject.GetComponent<SpriteRenderer>().sprite = runSprite;
            //renderer.enabled = false;
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(DisableRenderer());

        }
    }

    public  IEnumerator DisableRenderer()
    {
        yield return new WaitForSeconds(2f);
        renderer.enabled = false;
        animator.SetBool("gotPoked", false);
        animator.SetBool("groinHit", false);
        animator.SetBool("gotBlock", false);
    }
    // Update is called once per frame
    void Update()
    {
        
        if (animator.GetBool("gotPoked") || animator.GetBool("groinHit") || animator.GetBool("gotBlock"))
        {
            StartCoroutine(EnableRenderer());
            
            //runAudio.Play();
            //renderer.enabled = true;
            //Debug.Log("poked is true in tryagainScript");
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = runSprite;
            //renderer.enabled = false;

            //StartCoroutine(DisableRenderer());

        }



        /*
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == runSprite)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = goodSprite;
                timer = delay;
                return;
            }

            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == goodSprite)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = runSprite;
                timer = delay;
                return;
            }

        }*/
    }
}
