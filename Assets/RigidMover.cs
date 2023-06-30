using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class RigidMover : MonoBehaviour
{
    /*
    public float swipeForce = 5f;   // The force to apply to the object on swipe
    private Rigidbody rb;
    private Vector2 startPos;
    private bool isSwiping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            isSwiping = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isSwiping = false;
            Vector2 endPos = Input.mousePosition;
            Vector2 swipeDirection = endPos - startPos;
            if (swipeDirection.y != 0)
            {
                rb.AddForce(Vector3.forward * swipeForce * swipeDirection.y, ForceMode.Impulse);
                Debug.Log(swipeDirection+" "+ swipeForce * swipeDirection.y);
                return;
            }
                
            rb.AddForce(swipeDirection * swipeForce, ForceMode.Impulse);
        }
    }
    */
    [SerializeField] Direction DirectionToMove;
    [SerializeField]bool FacingBack=false;
    public float dragForce = 5f;   // The force to apply to the object while dragging
    private Rigidbody rb;
    private bool isDragging = false;
    private Vector3 dragStartPosition;
    float mouseX;
    float mouseY;
    float DIR = 0;
    float DirModifier = 1;

   // public Vector3 localForceDirection = Vector3.forward;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        RigidbodyConstraints Rc=rb.constraints;
        if (DirectionToMove == Direction.x)
        {
            Rc |= RigidbodyConstraints.FreezePositionZ;
            

        }
        else
        {
            Rc |= RigidbodyConstraints.FreezePositionX;
        }
        rb.constraints = Rc;
        if (FacingBack)
            DirModifier = -1;
    }
    private void OnMouseDown()
    {
        isDragging = true;
        dragStartPosition = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void OnMouseDrag()
    {
        if(DirectionToMove==Direction.x)
         DIR = Input.GetAxis("Mouse X");
        else
         DIR = Input.GetAxis("Mouse Y");


        if (isDragging)
        {
            
            //Vector3 worldForceDirection = transform.TransformDirection(localForceDirection);
            rb.AddForce(transform.forward*DIR*DirModifier * dragForce*Time.fixedDeltaTime, ForceMode.Force);
            //Debug.Log(transform.name+" FOrce "+DIR * dragForce );
        }
    }
}
