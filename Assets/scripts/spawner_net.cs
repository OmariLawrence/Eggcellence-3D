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
                if (isServer)
                {
                    Debug.Log("Shooting form server");
                    CmdSpawnEggServer();
                }
                else
                {
                    Debug.Log("Shooting from client");
                    CmdSpawnEggClient();
                }
                anim.SetBool("throwing", true);
            }
            else
            {
                anim.SetBool("throwing", false);
            }
        }
    }

    [Command]
    void CmdSpawnEggServer()
    {
        GameObject instance = Instantiate(eggPrefab, trans.position + (trans.forward * offset), cam.rotation);
        instance.GetComponent<Rigidbody>().AddForce(instance.transform.forward * power);
        NetworkServer.Spawn(instance);
        
    }
    [Command]
    void CmdSpawnEggClient()
    {
        GameObject instance = Instantiate(eggPrefab, trans.position + (trans.forward * offset), cam.rotation);
        instance.GetComponent<Rigidbody>().AddForce((instance.transform.forward * -1) * power);
        NetworkServer.Spawn(instance);

    }
}
