using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BezierFollow : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes; //will include more than one curve for complex shapes

    private int routeToGo;
    private float tParam;
    private Vector3 handPosition;
    private float speedModifier;
    public bool coroutineAllowed;
    private bool keypress;
    

    int numberOfGhostTrails = 1;
    public int routeType;
    /*
     * 1 Poke
     * 2 Punch
     * 3 Groin
     */
    public GameObject obj_assailant;
    public Animator animator;
  

    // Start is called before the first frame update
    void Start()
    {
        routeToGo = 0;//start with first curve
        tParam = 0f;
        speedModifier = 0.4f;
        keypress = false;
       
        GameObject obj_assailant = GameObject.FindWithTag("Assailant");

        if (obj_assailant != null)
        {
            animator = obj_assailant.GetComponent<Animator>();

        }
        if (obj_assailant == null)
        {
            Debug.Log("Cannot Find Assailaint object");
        }

        
        //coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (animator.GetBool("poke")) //approach animation started
        {
            routeType = 1;
            Debug.Log("routeType in BezierFollow is 1");
            
        }

        if (animator.GetBool("punch"))
        {
            routeType = 2;
            Debug.Log("routeType in BezierFollow is 2");
        }

        if (animator.GetBool("groin"))
        {
            routeType = 3;
            Debug.Log("routeType in BezierFollow is 3");
        }
        
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstick) && (!coroutineAllowed) && (!keypress)){
            keypress = true;
            coroutineAllowed = true;
        }

       
        if (numberOfGhostTrails <= 2)//we want to let the ghost trail run twice
        {
            keypress = false;
        if (coroutineAllowed)
            {
                StartCoroutine(GoByTheRoute(routeToGo));
            numberOfGhostTrails++;
                   
            }
        }
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;

        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;
        Vector3 p3 = routes[routeNumber].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            handPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                             3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                             3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                             Mathf.Pow(tParam, 3) * p3;
            transform.position = handPosition;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;//for the next coroutine

        /*
        for(int i = 0; i<(routes.Length - 1); i++)
        {
           
        }
        */


        /*
        while (routeToGo < routes.Length - 1)
        {
            routeToGo += 1;//to get the next curve
        }*/

        //routeToGo += 1;//to get the next curve


        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstick) && (!coroutineAllowed) && (!keypress))
        {
            if (routeToGo > routes.Length - 1)
            {
                routeToGo = 0;//loop
            }
        }

        coroutineAllowed = true;
    }

}
