using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class spawner_net : NetworkBehaviour
{
    public GameObject eggPrefab;
    public Transform cam;
    public float offset;
    GameObject eggInstance;
    public Animator anim;
    public float power = 300;
    private Vector3 front;
    private Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        front = cam.forward;
        
        if (isLocalPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("throwing", true);
                GameObject instance = Instantiate(eggPrefab, trans.position + (trans.forward * offset), cam.rotation);
                instance.GetComponent<Rigidbody>().AddForce(front * power);
                CmdSpawnEgg(instance);
            }
            else
            {
                anim.SetBool("throwing", false);
            }
        }
    }

    [Command]
    void CmdSpawnEgg(GameObject instance)
    {
        NetworkServer.Spawn(instance);
        
    }
}
