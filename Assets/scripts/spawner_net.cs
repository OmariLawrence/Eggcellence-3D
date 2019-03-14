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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        front = cam.forward;
        if (isLocalPlayer)
        {
            if (cam == null)
            {
                Debug.Log("how");
            }
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("throwing", true);
                CmdSpawnEgg();
            }
            else
            {
                anim.SetBool("throwing", false);
            }
        }
    }

    [Command]
    void CmdSpawnEgg()
    {
        GameObject instance = Instantiate(eggPrefab, transform.position + (transform.forward * offset), cam.rotation);
        instance.GetComponent<Rigidbody>().AddForce(front * power);
        NetworkServer.Spawn(instance);
        
    }
}
