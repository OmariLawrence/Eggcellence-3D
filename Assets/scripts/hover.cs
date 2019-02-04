using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour
{

    public float hoverHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, hoverHeight*10))
        {
            //print(hit.distance);
            if (hit.distance < hoverHeight)
            {
                transform.Translate(Vector3.up/10);
            }
            if ((hit.distance+0.2) > hoverHeight)
            {
                transform.Translate(Vector3.down/10);

            }
        }
    }
}
