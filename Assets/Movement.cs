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
    [SerializeField] public Direction DirectionToMove;
    Vector3 CurrentLimit = new Vector3(100, 0, 100);
    float mouseX = 0;
    float mouseY = 0;
    Vector3 ClamppedPos;
    bool FrontTouched = false;
    bool BackTouched = false;
    //PositionClamper m_positionClamper;
    private void Start()
    {
        //m_positionClamper=GetComponent<PositionClamper>();
    }
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

       
        transform.position += new Vector3(mouseOffset.x, 0, mouseOffset.y) * Time.deltaTime;

        lastMousePos = Input.mousePosition;
    }
    private void OnMouseUp()
    {
        dragging = false;
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
