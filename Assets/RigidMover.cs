using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class RigidMover : MonoBehaviour
{
    [SerializeField]public Direction DirectionToMove;
    [SerializeField]bool FacingBack=false;
    [SerializeField] float TouchForce = 1;
    [SerializeField] float MaxVelocity = 30;
    [SerializeField] bool Testing = false;
    public float dragForce = 5f;   // The force to apply to the object while dragging
    private Rigidbody rb;
    private bool isDragging = false;
    private Vector3 dragStartPosition;
    float mouseX;
    float mouseY;
    float DIR = 0;
    float DirModifier = 1;
    bool IsROundStarted = false;
    bool IsROundENded = false;
    bool Raycasting=false;
    public bool FrontColliding = false;
    public bool BackColliding = false;
  
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        CarEscapeManager.OnROundStart += OnRoundStarted;
        CarEscapeManager.OnROundEnd += OnRoundEnd;
        CamereSetter.OnCameraRotated += camerarotated;

    }

    

    private void OnDisable()
    {

        CarEscapeManager.OnROundStart -= OnRoundStarted;
        CarEscapeManager.OnROundEnd -= OnRoundEnd;
        CamereSetter.OnCameraRotated -= camerarotated;
    }

    private void camerarotated()
    {
       
        DirModifier *= -1;
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
        //rb.isKinematic = true;
        if (FacingBack)
            DirModifier *= -1;
        
    }
    private void Update()
    {
        if (!Raycasting) return;
        
    }
    void RaycastDetection()
    { 
        
    }
    private void OnRoundStarted()
    {
        IsROundStarted = true;
    }
    private void OnRoundEnd()
    {
        IsROundENded = true;
        //rb.velocity = Vector3.zero;

    }
    private void OnMouseDown()
    {
        //rb.AddForce(transform.forward * DIR * DirModifier * TouchForce, ForceMode.Impulse);
        //rb.isKinematic = false;
        
        isDragging = true;
        
        dragStartPosition = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vibration.Vibrate(30);
    }

    private void OnMouseUp()
    {
        
        Raycasting = false;
        //rb.isKinematic = true;
    }

    private void OnMouseDrag()
    {
        if (!IsROundStarted || IsROundENded) return;
        if(DirectionToMove==Direction.x)
         DIR = Input.GetAxis("Mouse X");
        else
         DIR = Input.GetAxis("Mouse Y");

        if (isDragging)
        {

            //Vector3 worldForceDirection = transform.TransformDirection(localForceDirection);
            if (!FrontColliding && DIR * DirModifier > 0) 
                rb.AddForce(transform.forward*DIR*DirModifier * dragForce*Time.fixedDeltaTime, ForceMode.VelocityChange);
            else if(!BackColliding && DIR * DirModifier<0)
                rb.AddForce(transform.forward * DIR * DirModifier * dragForce * Time.fixedDeltaTime, ForceMode.VelocityChange);

        }

        
    }
    private void FixedUpdate()
    {
        
            //Vector3 velocity = rb.velocity;
            rb.velocity= Vector3.ClampMagnitude(rb.velocity, MaxVelocity);
        //if(Testing)
        //Debug.Log(transform.name + " FOrce " + DIR * DirModifier * dragForce * Time.fixedDeltaTime + "  velo " + rb.velocity.magnitude);


    }
  
}
