using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float planeY = 0f; // The Y position of the XZ plane
    public float moveSpeed = 5f; // The speed at which the object moves towards the target position
    public float lerpSmoothness = 0.5f; // The smoothness factor for lerping

    private Vector3 targetPosition; // The target position to move towards

    void Start()
    {
        // Initialize the target position to the initial position of the object
        targetPosition = transform.position;
    }

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
                // 4. Update the target position
                targetPosition = new Vector3(hit.point.x, transform.position.y, transform.position.z);
            }
        }
    }

    void Update()
    {
        // Move the object smoothly towards the target position using lerp
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSmoothness * Time.deltaTime * moveSpeed);
    }
}
