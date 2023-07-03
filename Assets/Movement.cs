using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] public Direction DirectionToMove;
    //Vector3 CurrentLimit = new Vector3(100, 0, 100);
    float mouseX = 0;
    float mouseY = 0;
    Rigidbody RB;
    //Vector3 ClamppedPos;
    bool FrontTouched = false;
    bool BackTouched = false;
    public float moveSpeed = 5f; // The speed at which the object moves towards the target position
    public float lerpSmoothness = 0.5f; // The smoothness factor for lerping

    private Vector3 targetPosition; // The target position to move towards
    bool IsROundStarted = false;
    //PositionClamper m_positionClamper;
    private void OnEnable()
    {
        CarEscapeManager.OnROundStart += OnRoundStarted;

    }



    private void OnDisable()
    {

        CarEscapeManager.OnROundStart -= OnRoundStarted;
    }

    private void OnRoundStarted()
    {
        IsROundStarted=true;
    }

    private void Start()
    {
        targetPosition = transform.position;
        RB = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!IsROundStarted) return;
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

       // transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSmoothness * Time.deltaTime * moveSpeed);
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


       
        Vector3 mouseOffset = Input.mousePosition - lastMousePos;

        if (DirectionToMove == Direction.x)
        {
            mouseOffset.y = 0;
            if (FrontTouched && (mouseX > 0))
            {
                mouseOffset.x = 0;
                mouseOffset.y = 0;
            }
            else if (BackTouched && (mouseX < 0))
            {
                mouseOffset.x = 0;
                mouseOffset.y = 0;
            }
        }

        else
        {
            mouseOffset.x = 0;
            if (FrontTouched && (mouseY > 0))
            {
                mouseOffset.x = 0;
                mouseOffset.y = 0;
            }
            else if (BackTouched && (mouseY < 0))
            {
                mouseOffset.x = 0;
                mouseOffset.y = 0;
            }
        }
            // Reset the Y component to prevent movement on the Y-axis

       
        transform.position += new Vector3(mouseOffset.x, 0, mouseOffset.y) * Time.fixedDeltaTime*moveSpeed;

        lastMousePos = Input.mousePosition;
    }
    private void OnMouseUp()
    {
        dragging = false;
        RB.velocity=Vector3.zero;
    }
    public void SetTriggerTouched(CarFace Facing,bool status)
    {
        if (Facing == CarFace.Front)
        {
            FrontTouched = status;
            BackTouched = false;
        }
        else
        {
            FrontTouched = false;
            BackTouched = status;
        }
    }
}
