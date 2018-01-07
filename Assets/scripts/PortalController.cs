using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour {

    public PortalController target;
    private CameraController camera;

    private bool active;

	// Use this for initialization
	void Start () {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        active = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Teleport the player to the target portal and update the camera
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( active && 
             collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().stopMovement();
            target.active = false; // Prevents constant teleportation
            collision.gameObject.GetComponent<Rigidbody2D>().MovePosition(target.transform.position);

            this.camera.updateTarget(target.gameObject.transform.parent.gameObject.transform.parent.gameObject);
        }
    }

    // Reactivate the portal when player leaves portal area
    private void OnTriggerExit2D(Collider2D collision)
    {
        active = true;
    }
}
