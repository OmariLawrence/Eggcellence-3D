using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class thrower_net : NetworkBehaviour
{
    //public Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //pelt();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!isServer)
        {
            return;
        }
        //Destroy(collision.gameObject);
        print("collided");
    }
}
