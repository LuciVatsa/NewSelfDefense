using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField]
    private Transform[] controlPoints;//we have 4 controlpoints
    private Vector3 gizmosPosition; //position of particular gizmo placed along the curve

    private void OnDrawGizmos()//all gizmos are drawn 
    {
        for(float t=0; t<= 1; t += 0.05f)//20 gizmos visualizing our curve (cubic bezier curve
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
                             3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position +
                             3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position +
                             Mathf.Pow(t, 3) * controlPoints[3].position;
            Gizmos.DrawSphere(gizmosPosition, 0.25f);//each gizmo is represented by a sphere with radius 0.25
        }

        //line from point1 to point2
        Gizmos.DrawLine(new Vector3(controlPoints[0].position.x, controlPoints[0].position.y, controlPoints[0].position.z),
                        new Vector3(controlPoints[1].position.x, controlPoints[1].position.y, controlPoints[1].position.z));

        //line from point3 to point4
        Gizmos.DrawLine(new Vector3(controlPoints[2].position.x, controlPoints[2].position.y, controlPoints[2].position.z),
                new Vector3(controlPoints[3].position.x, controlPoints[3].position.y, controlPoints[3].position.z));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
