using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCameraController : MonoBehaviour
{
    [Header("Scene Camera Properties")]
    [SerializeField] Transform sceneCamera;
    [SerializeField] float cameraRotationRadius = 24f;
    [SerializeField] float cameraRotationSPeed = 3f;
    [SerializeField] bool canRotate = true;

    float rotation;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        canRotate = false;
        cam.enabled = false;
    }

    // Update is called once per frame
    void Update()
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

    public void StartRunning()
    {
        canRotate = false;
        cam.enabled = false;
    }
}
