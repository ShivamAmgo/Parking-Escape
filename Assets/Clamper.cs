using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CarFace
{
    Front,
    Back
}
public class Clamper : MonoBehaviour
{
    Transform Target;
    [SerializeField]CarFace Face = CarFace.Front;
    [SerializeField] GameObject HitFX;
    RigidMover m_RigidBodyMover;
    Vector3 CurrentLimit;
    bool IsClamping = false;
    Brakes m_Brakes;
    private void Start()
    {
        Target = transform.root;
        //m_movement = GetComponentInParent<Movement>();
        m_RigidBodyMover = GetComponentInParent<RigidMover>();
        m_Brakes = GetComponentInParent<Brakes>();
    }
    

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root == transform.root) return;
        if (other.gameObject.CompareTag("Car") || other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Player"))
        {
            //m_movement.SetTriggerTouched(Face, true);
            Brakes BR = other.transform.root.GetComponent<Brakes>();
            if (BR != null) 
            BR.PlayBrakeAnimation();
            m_Brakes.PlayBrakeAnimation();
            m_Brakes.PlayHitfx(other.ClosestPoint(transform.position));
            //Debug.Log(transform.root.name+ " trigger  collided with "+ other.transform.root.name);
            CheckDetetction(Face, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CheckDetetction(Face, false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.root == transform.root) return;
        if (other.gameObject.CompareTag("Car") || other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Player"))
            CheckDetetction(Face, true);
    }
    void CheckDetetction(CarFace facing,bool ActiveStatus)
    {
        if (facing == CarFace.Front)
        {
            m_RigidBodyMover.FrontColliding = ActiveStatus;
            Debug.Log("Feont colliding " + ActiveStatus);
        }
        else if (facing == CarFace.Back)
        { 
            m_RigidBodyMover.BackColliding = ActiveStatus;
            Debug.Log("Back colliding " + ActiveStatus);
        }        
    }
}
