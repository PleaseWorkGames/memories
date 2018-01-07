using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;

    public float cameraOffsetY;
    
    public GameObject targetDungeon;
    
    public Rigidbody2D player;

    public Camera camera;
    
    public int sensitivity;

    public float minOrthographicSize;
    
    public float maxOrthographicSize;

    // Use this for initialization
    void Start()
    {
        updateTarget(targetDungeon);
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var orthographicSize = camera.orthographicSize;
        var mouseScroll = Input.GetAxis("Mouse ScrollWheel");

        if (mouseScroll > 0 || mouseScroll < 0) {
            orthographicSize += Input.GetAxis("Mouse ScrollWheel") * sensitivity * -1;
            orthographicSize = Mathf.Clamp(orthographicSize, minOrthographicSize, maxOrthographicSize);
            camera.orthographicSize = orthographicSize;
        }
    }

    public void updateTarget(GameObject newTarget)
    {
        this.targetDungeon = newTarget;
        this.transform.SetPositionAndRotation(
            new Vector3(targetDungeon.transform.position.x, targetDungeon.transform.position.y + cameraOffsetY,
            this.transform.position.z), this.transform.rotation
        );
    }
    
    public void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        camera.transform.position = player.transform.position + offset;
    }
}
