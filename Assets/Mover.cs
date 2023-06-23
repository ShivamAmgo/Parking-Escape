using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MovingDirection
{ 
    X, 
    Y,
    Z
}
public class Mover : MonoBehaviour
{
    [SerializeField] Vector3 DirectionTOmove;//Global Position
    [SerializeField] MovingDirection Direction_To_move;
    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;
    
    Touch touch;
    Vector3 startingpos;
    Vector3 StopLimit ;
    bool IsCollided=false;
    void Start()
    {
        mainCamera = Camera.main;
        startingpos = transform.position;
    }
    void OnMouseDown()
    {
        // Calculate the offset between the object's position and the mouse position
        offset = gameObject.transform.position - GetMouseWorldPosition();

        // Set the dragging flag to true
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (!isDragging ) return;
        
            // Update the object's position based on the mouse position
            Vector3 newPosition = GetMouseWorldPosition() + offset;
        
            newPosition.y = startingpos.y;// Maintain the object's original height
            
            
        if (MovingDirection.X == Direction_To_move)
            newPosition.z = transform.position.z;
        else
            newPosition.x = transform.position.x;
        
        if (IsCollided)
        {
            if (DirectionTOmove.x > 0 && Mathf.Abs(newPosition.x) >= Mathf.Abs(StopLimit.x))
            {
                newPosition = transform.position;
            }
            else if (DirectionTOmove.z > 0 && Mathf.Abs(newPosition.z) >= Mathf.Abs(StopLimit.z))
            {
                newPosition = transform.position;
            }
        }
        
            transform.position = newPosition;
        
    }

    void OnMouseUp()
    {
        // Reset the dragging flag
        isDragging = false;
        //IsCollided = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Create a ray from the camera to the mouse position
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);

        // Calculate the intersection point between the ray and the XZ plane (Y = 0)
        float distanceToGround = -ray.origin.y / ray.direction.y;
        Vector3 worldPosition = ray.origin + ray.direction * distanceToGround;

        return worldPosition;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Car") || IsCollided) return;
        Debug.Log("Entered");
        IsCollided = true;
        Collided();
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Car")) return;
        //IsCollided = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Car")) return;
        IsCollided = false;
    }
    void Collided()
    {
        StopLimit = transform.position;
    }
}
