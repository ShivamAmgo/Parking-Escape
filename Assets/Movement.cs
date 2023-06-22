using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Vector3 DirectionTOmove;
    Touch touch;
    Vector3 startingpos;
    private void Start()
    {
        startingpos=transform.position;
    }
    private void Update()
    {
        if (Input.touchCount > 0)
            touch = Input.GetTouch(0);

    }
    private void OnMouseDrag()
    {
        Vector3 touchPosition = touch.position;

        // Set the distance from the camera to the object
        float distanceFromCamera = Vector3.Distance(transform.position, Camera.main.transform.position);

        // Convert the touch position to world coordinates with the same distance from the camera
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, distanceFromCamera, touchPosition.z));
        transform.position = new Vector3(worldPosition.x,startingpos.y,worldPosition.z);
        //Debug.Log(worldPosition);
        //transform.position = worldPosition;
        //float ClampedY = Mathf.Clamp(worldPosition.y, 0, 50);
        
    }
    private void OnMouseUp()
    {
        
    }
}
