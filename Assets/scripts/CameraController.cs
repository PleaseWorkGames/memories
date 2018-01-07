using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraOffsetY;
    
    public GameObject targetDungeon;

    public Camera camera;
    
    public int sensitivity;

    public float minOrthographicSize;
    
    public float maxOrthographicSize;

    // Use this for initialization
    void Start()
    {
        updateTarget(targetDungeon);
    }

    // Update is called once per frame
    void Update()
    {
        var orthographicSize = camera.orthographicSize;
        orthographicSize += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        orthographicSize = Mathf.Clamp(orthographicSize, minOrthographicSize, maxOrthographicSize);
        camera.orthographicSize = orthographicSize;
    }

    public void updateTarget(GameObject newTarget)
    {
        this.targetDungeon = newTarget;
        this.transform.SetPositionAndRotation(
            new Vector3(targetDungeon.transform.position.x, targetDungeon.transform.position.y + cameraOffsetY,
            this.transform.position.z), this.transform.rotation
        );
    }
}
