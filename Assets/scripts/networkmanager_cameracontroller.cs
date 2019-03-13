using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class networkmanager_cameracontroller : NetworkManager
{
    [Header("Scene Camera Properties")]
    [SerializeField] Transform sceneCamera;
    [SerializeField] float cameraRotationRadius = 24f;
    [SerializeField] float cameraRotationSPeed = 3f;
    [SerializeField] bool canRotate = true;

    float rotation;
    public Camera cam;

    public override void OnStartClient(NetworkClient client)
    {
        base.OnStartClient(client);
        canRotate = false;
        cam.enabled = false;
    }

    public override void OnStartHost()
    {
        base.OnStartHost();
        canRotate = false;
        cam.enabled = false;
    }

    public override void OnStopClient()
    {
        base.OnStopClient();
        canRotate = true;
        cam.enabled = true;
    }

    public override void OnStopHost()
    {
        base.OnStopHost();
        canRotate = true;
        cam.enabled = true;
    }

    private void Update()
    {
        if (!canRotate)
        {
            return;
        }

        rotation += cameraRotationSPeed * Time.deltaTime;
        if (rotation >= 360f)
        {
            rotation -= 360f;
        }

        sceneCamera.position = Vector3.zero;
        sceneCamera.rotation = Quaternion.Euler(0f, rotation, 0f);
        sceneCamera.Translate(0f, cameraRotationRadius, cameraRotationRadius);
        sceneCamera.LookAt(Vector3.zero);
    }
}
