using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tryAgainScript : MonoBehaviour
{

    public Animator animator;
    public AssailantState assailant;
    public GameObject obj_assailant;

    public Sprite runSprite;
    public Sprite trySprite;
    public Sprite lateSprite;
    public Sprite goodSprite;

    public SpriteRenderer renderer;

    float timer = 1f;
    float delay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        renderer = this.gameObject.GetComponent<SpriteRenderer>();
        // this.gameObject.GetComponent<SpriteRenderer>().sprite = goodSprite;
        renderer.sprite = goodSprite;
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

    public  IEnumerator DisableRnderer()
    {
        yield return new WaitForSeconds(2f);
        renderer.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (animator.GetBool("gotPoked"))
        {
            renderer.enabled = true;
            Debug.Log("poked is true in tryagainScript");
            this.gameObject.GetComponent<SpriteRenderer>().sprite = runSprite;
            //renderer.enabled = false;
            StartCoroutine(DisableRnderer());

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
