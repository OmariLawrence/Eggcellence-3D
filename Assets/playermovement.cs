using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playermovement : MonoBehaviour
{
    public float speed;
    //    public Rigidbody rb;
    public Animator playAnim;

    private void Start()
    {
        playAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            playAnim.SetBool("walking", true);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            playAnim.SetBool("walking", true);
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            playAnim.SetBool("walking", true);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
            playAnim.SetBool("walking", true);
        }
        if(Input.GetAxis("Horizontal")==0 && Input.GetAxis("Vertical") == 0)
        {
            playAnim.SetBool("walking", false);
        }
//        if (Input.GetKeyDown("space"))
//        {
//            rb.AddForce(Vector3.up * 250);
//        }

    }
}
