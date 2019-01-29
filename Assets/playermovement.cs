using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playermovement : MonoBehaviour
{

    public CharacterController cc;
    public Animator playAnim;
    public float speed = 10;
    public Transform cam;
    public float pitch = 0;
    //jump stuff
//    public float yspeed = 2.0317f;
//    public float gravity = -15;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        playAnim = GetComponent<Animator>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal") * speed;
        float zInput = Input.GetAxis("Vertical") * speed;

        Vector3 move = new Vector3(xInput, 0, zInput);
        move = Vector3.ClampMagnitude(move, speed);
        move = transform.TransformVector(move);
//        if (cc.isGrounded)
//        {
//            if (Input.GetButtonDown("Jump"))
//            {
//                yspeed = 15;
//            }
//            else
//            {
//                yspeed = gravity * Time.deltaTime;
//            }
//        }
//        else
//        {
//            yspeed += gravity * Time.deltaTime;
//        }
        if(xInput!=0 || zInput != 0) {
            playAnim.SetBool("walking", true);
            cc.Move(move * Time.deltaTime);
        }
        else
        {
            playAnim.SetBool("walking", false);
        }
        float xMouse = Input.GetAxis("Mouse X")*10f;
        transform.Rotate(0, xMouse, 0);

        pitch -= Input.GetAxis("Mouse Y") * 10f;
        pitch = Mathf.Clamp(pitch, -45, 45);
        Quaternion camRotation = Quaternion.Euler(pitch, 0, 0);

        cam.localRotation = camRotation;
    }
}
