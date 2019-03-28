using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrower : MonoBehaviour
{

    public Rigidbody rb;
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

    void OnTriggerEnter(Collider col)
    {
        //if (col.gameObject.name == "prop_powerCube")
        //{
        //    Destroy(col.gameObject);
        //}
        //print("collided");
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(collision.gameObject);
        print("collided");
    }
}
