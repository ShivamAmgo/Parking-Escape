using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionClamper : MonoBehaviour
{
    Movement movement;
    float CurrentmouseDir = 0;
    Direction direction;
    Vector3 CurrentLimit ;
    float clampVal = 0;
    bool IsClamping = false;
    private void Start()
    {
        movement = GetComponent<Movement>();
        direction = movement.DirectionToMove;
    }
    private void Update()
    {


        if (direction == Direction.x)
        {
            CurrentmouseDir = Input.GetAxis("Mouse X");
            Xclamp();
        }
        else
        { 
            CurrentmouseDir=Input.GetAxis("Mouse Y");
            Yclamp();   
        }
        //Debug.Log(CurrentmouseDir);
    }
    void Xclamp()
    {
        if (!IsClamping) return;
        if (CurrentmouseDir == 0) return;
        if (CurrentmouseDir < 0)
        {
            clampVal = Mathf.Clamp(clampVal, CurrentLimit.x, 1000);
        }
        else
        { 
            clampVal= Mathf.Clamp(clampVal,-1000, CurrentLimit.x);
        }
        transform.position = new Vector3(clampVal, transform.position.y, transform.position.z);
        //IsClamping = false;
        Debug.Log("cl "+clampVal);
    }
    void Yclamp()//IsoMetric View i e ; Z Clamp
    {
        if (!IsClamping) return;
        if (CurrentmouseDir < 0)
        {
            clampVal = Mathf.Clamp(clampVal, CurrentLimit.z, 1000);
        }
        else
        {
            clampVal = Mathf.Clamp(clampVal, -1000, CurrentLimit.z);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, clampVal);
    }
    public void SetCurrentLimit(Vector3 Limit)
    {
        if (Limit == Vector3.zero)
        {
            IsClamping = false;
            return;
        }
        
        CurrentLimit = Limit;
        IsClamping = true;
        Debug.Log(CurrentLimit);
    }



}
