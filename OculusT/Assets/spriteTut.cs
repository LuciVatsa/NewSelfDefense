using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteTut : MonoBehaviour
{

    public Sprite runSprite1;
    public Sprite goodSprite;

    float timer = 1f;
    float delay = 1f; 

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = runSprite1;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == runSprite1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = goodSprite;
                timer = delay;
                return;
            }

            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == goodSprite)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = runSprite1;
                timer = delay;
                return;
            }

        }
    }
}
