using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public GameObject eggPrefab;
    public Transform cam;
    public float offset;
    GameObject eggInstance;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(eggPrefab, transform.position + (transform.forward*offset), cam.rotation);
        }
    }

    
}
