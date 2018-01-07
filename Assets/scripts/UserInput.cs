using UnityEngine;

/*
 * A class that allows for keyboard and point-and-click movement
 */
public class UserInput : MonoBehaviour{

    private Vector2 target;

    private bool manualMovement;
    void Start() {
        manualMovement = true;
        target = Vector2.zero;
    }
    /**
     * Get the vertical and horizontal vector movement
     *  @return Vector2  
     */
    public Vector2 GetMovementVector(Vector2 current){
        if ( manualMovement ) {
            return new Vector2(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"));
        }
        else {
            float vertical = 0;
            float horizontal = 0;

            if (Mathf.Abs(current.x-target.x)>.05 ) {
                vertical = current.x > target.x ? -1 : 1;
            }
            
            if (Mathf.Abs(current.y - target.y)>.05 ) {
                horizontal = current.y > target.y ? -1 : 1;
            }
            return new Vector2(horizontal,vertical);
        }
    }

    void Update() {
        if ( Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0){
            manualMovement = true;
        }
        else if (Input.GetMouseButtonDown(0)) {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            manualMovement = false;
        }
    }

    public void SetManualMovement(bool val) {
        manualMovement = val;
    }
}