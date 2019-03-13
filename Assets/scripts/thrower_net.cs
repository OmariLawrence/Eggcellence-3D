using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class thrower_net : NetworkBehaviour
{
    public int egglife = 10;
    public float speed;
    private float age = 0;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //pelt();
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
    }

    [ServerCallback]
    private void timer()
    {
        age += Time.deltaTime;
        if (age > egglife)
        {
            NetworkServer.Destroy(gameObject);
        }
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
