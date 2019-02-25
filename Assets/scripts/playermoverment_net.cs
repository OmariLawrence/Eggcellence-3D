using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class playermoverment_net : NetworkBehaviour
{

    public CharacterController cc;
    //public Animator playAnim;
    public float speed = 10;
    public Transform cam;
    public float pitch = 0;
    //jump stuff

    void Start()
    {
        cc = GetComponent<CharacterController>();
        //playAnim = GetComponent<Animator>();
        if (!isLocalPlayer)
        {
            Destroy(cam.gameObject);
            Destroy(this);
            return;
        }
    }

    void Update()
    {
        playerUpdate();
        cameraUpdate();

    }

    void playerUpdate()
    {
        float xInput = Input.GetAxis("Horizontal") * speed;
        float zInput = Input.GetAxis("Vertical") * speed;

        Vector3 move = new Vector3(xInput, 0, zInput);
        move = Vector3.ClampMagnitude(move, speed);
        move = transform.TransformVector(move);

        if (xInput != 0 || zInput != 0)
        {
            //playAnim.SetBool("walking", true);
            cc.Move(move * Time.deltaTime);
        }
        else
        {
            //playAnim.SetBool("walking", false);
        }
    }

    void cameraUpdate()
    {
        float xMouse = Input.GetAxis("Mouse X") * 10f;
        transform.Rotate(0, xMouse, 0);

        pitch -= Input.GetAxis("Mouse Y") * 10f;
        pitch = Mathf.Clamp(pitch, -45, 45);
        Quaternion camRotation = Quaternion.Euler(pitch, 0, 0);

        cam.localRotation = camRotation;
    }
}


