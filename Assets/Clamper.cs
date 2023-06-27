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
    Movement m_movement;
    Vector3 CurrentLimit;
    bool IsClamping = false;
    private void Start()
    {
        Target = transform.root;
        m_movement = GetComponentInParent<Movement>();
    }
    

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car") || other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Player"))
        {
            m_movement.SetTriggerTouched(Face, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Car") || other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Player"))
        {
            m_movement.SetTriggerTouched(Face, false);
        }
    }
}
