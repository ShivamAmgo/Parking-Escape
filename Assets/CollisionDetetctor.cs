using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetetctor : MonoBehaviour
{

    [SerializeField] Transform FrontDetector;
    [SerializeField] Transform BackDetector;
    [SerializeField] float RayLength = 5;
    RaycastHit FrontHit;
    RaycastHit BackHit;
    RigidMover m_rigidMover;
    bool Raycasting = false;
    private void Start()
    {
        m_rigidMover = GetComponent<RigidMover>();
    }
    private void OnMouseDown()
    {
        Raycasting = true;
    }
    private void OnMouseUp()
    {
        Raycasting= false;
    }
    private void Update()
    {
        if (!Raycasting) return;
        Physics.Raycast(FrontDetector.position, transform.forward, out FrontHit, RayLength);
        Physics.Raycast(FrontDetector.position, -transform.forward, out BackHit, RayLength);
        //if (FrontHit.transform.root == transform.root || BackHit.transform.root == transform.root) return;
        if (FrontHit.transform != null)
            FrontDetect();

        if(BackHit.transform!=null)
            BackDetect();
       
       
       // 
    }
    void FrontDetect()
    {
        if ((FrontHit.transform.root.CompareTag("Car") || FrontHit.transform.root.CompareTag("Player")) &&
           transform.root != FrontHit.transform.root)
        {
            m_rigidMover.FrontColliding = true;
            
        }
        else
            m_rigidMover.FrontColliding = false;

        Debug.Log("Collideing Front");
        //Debug.DrawRay(FrontDetector.transform.position, transform.forward * RayLength, Color.blue,5);
    }
    void BackDetect()
    {

        if ((BackHit.transform.root.CompareTag("Car") || BackHit.transform.root.CompareTag("Player")) &&
            transform.root != BackHit.transform.root)
        {
            m_rigidMover.BackColliding = true;
            
        }
        else
            m_rigidMover.BackColliding = false;
        Debug.Log("Collideing Back");
        //Debug.DrawRay(BackDetector.transform.position, -transform.forward * RayLength, Color.blue,5);
    }
}
