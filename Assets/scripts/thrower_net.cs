using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class thrower_net : NetworkBehaviour
{
    public int egglife = 10;
    public float speed;
    public float power = 3000;
    private float age = 0;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb.AddForce(transform.forward * power);
    }

    // Update is called once per frame
    void Update()
    {
        timer();
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
