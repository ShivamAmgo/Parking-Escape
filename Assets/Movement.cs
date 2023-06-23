using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Direction 
{
    y,x,z
}
public class Movement : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 startMousePos;
    private Vector3 startPos;
    private Vector3 lastMousePos;
    private Vector3 direction = Vector3.right;
    private bool collided = false;
    [SerializeField] Direction DirectionToMove;
    Vector3 CurrentLimit=new Vector3(100,0,100);
    float mouseX = 0;
    float mouseY = 0;
    float ClamppedPos;
    private void Update()
    {
         mouseX = Input.GetAxis("Mouse X");
         mouseY = Input.GetAxis("Mouse Y");

    }
    private void OnMouseDown()
    {
        dragging = true;
        startMousePos = Input.mousePosition;
        startPos = transform.position;
        lastMousePos = startMousePos;
        collided = false;
    }

    private void OnMouseDrag()
    {
        if (!dragging) return;
        

            // Calculate the mouse movement
            Vector3 mouseOffset = Input.mousePosition - lastMousePos;
            mouseOffset.y = 0f; // Reset the Y component to prevent movement on the Y-axis
        Debug.Log("Limit " + CurrentLimit+" mousepos "+mouseOffset);
        /*
        if (DirectionToMove == Direction.x)
        {
            if (Mathf.Abs(transform.position.x) > Mathf.Abs(CurrentLimit.x))
            {
                transform.position = new Vector3(CurrentLimit.x, transform.position.y, transform.position.z);
                return;
            }
            


        }
        else
        {
            if (Mathf.Abs(transform.position.z) > Mathf.Abs(CurrentLimit.z))
            {
                
                transform.position = new Vector3(transform.position.x, transform.position.y, CurrentLimit.z);
                return;
            }
            
           
        }
        if (!collided)
        {
            
            transform.position += mouseOffset * Time.deltaTime;
            
        }
        */
        //ClamppedPos=Mathf.Clamp()
        if (!collided)
        {

            transform.position += mouseOffset * Time.deltaTime;

        }
        lastMousePos = Input.mousePosition;
        // Update the object's position

    }

    private void OnMouseUp()
    {
        dragging = false;
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && dragging)
        {
            // Stop movement if obstacle detected
            collided = true;
            CurrentLimit=transform.position;
            //Vector3 mouseoffset = (lastMousePos - startMousePos);
            //transform.position -= new Vector3(mouseoffset.x,0,mouseoffset.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            collided = false;
        }
    }
}
