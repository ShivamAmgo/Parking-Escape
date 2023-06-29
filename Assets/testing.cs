using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    // public float planeY = 0f; // The Y position of the XZ plane
    /*
     void OnMouseDrag()
    {
        // 1. Capture the mouse position
        Vector3 mousePosition = Input.mousePosition;

        // 2. Convert the mouse position to a world position
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y, Mathf.Abs(Camera.main.transform.position.y - planeY)));

        // 3. Move the object to the calculated world position
        //Vector3 pos = worldPosition;
        worldPosition.y=transform.position.y;
        transform.position = worldPosition;
    }
    */
    /*
    void OnMouseDrag()
    {
        // 1. Capture the mouse position
        Vector3 mousePosition = Input.mousePosition;

        // 2. Perform a raycast from the mouse position
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // 3. Check if the raycast hit the XZ plane
            if (hit.transform.CompareTag("Ground"))
            {
                // 4. Move the object to the hit point
                transform.position = new Vector3(hit.point.x, transform.position.y, transform.position.z);
            }
        }
    }
    */
    //The Y position of the XZ plane
    public float planeY = 0f; // The Y position of the XZ plane
    public float moveSpeed = 5f; // The speed at which the object moves towards the target position

    private bool isDragging = false; // Flag to track if the object is being dragged
    private Vector3 targetPosition; // The target position to move towards
    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (isDragging)
        {
            // Capture the mouse position and perform a raycast
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.CompareTag("Ground"))
                {
                    // Update the target position to the hit point on the XZ plane
                    targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                }
            }
        }

        // Smoothly move the object towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void OnMouseDown()
    {
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}
