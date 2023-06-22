using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Drag : MonoBehaviour
{
    bool CanDrag = false;
    bool ModelPlaced = false;
    Vector3 Startpos;
    [SerializeField] float dragSpeed = 1;
    //[SerializeField] AnimationChanger ANC;
    [SerializeField] GameObject ModelPlacedFX;
    [SerializeField] float fxDelay = 0.5f;
    [SerializeField] float ScaleOnCLick = 0.2f;
    [SerializeField] float ScaleOnClickDuration = 0.25f;
    [SerializeField] AudioClip PoseChangeAudio;
    [SerializeField] AudioClip ModelPlacedAudio;
    Touch touch;
    bool IsScaling = false;
    bool IsTimerExpired = false;
    bool IsRoundStarted = false;
    bool IsDragging=false;
    Vector3 Modeloffset = Vector3.zero;
    Vector3 StartingScale;
    float distanceFromCamera;
    Plane plane;
    private GameObject planeVisualization;
    bool IsIdle = true;
    Ray ray;
    RaycastHit hit;
    private void OnEnable()
    {
       
       
        
    }

    

    private void OnDisable()
    {
       
    }

    private void TimerExpired()
    {
        IsTimerExpired = true;
        if (ModelPlaced) return;
        Reset();
    }
    
 
    private void Start()
    {
        Startpos = transform.position;
        StartingScale=transform.localScale; 
        /*
        plane = new Plane(Vector3.up, transform.position);

        planeVisualization = GameObject.CreatePrimitive(PrimitiveType.Quad);
        planeVisualization.transform.localScale = new Vector3(10f, 10f, 1f);
        planeVisualization.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        planeVisualization.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0.5f);*/
    }
   

    private void Update()
    {
        if(Input.touchCount>0)
        touch=Input.GetTouch(0);

    }
    private void RecieveOffset(float offset, Transform From)
    {
        //Startpos=new Vector3(transform.position.x,transform.position.y,From.position.z- offset);
        Modeloffset = new Vector3(transform.position.x, transform.position.y, From.position.z - offset);


        // Offest_Z = offset;
    }
    public void Reset()
    {
        transform.DOMove(Startpos, 0.15f);
    }
    void PlayFX(GameObject fx)
    { 
        fx.SetActive(false);
        fx.SetActive(true);
    }
    private void OnMouseDrag()
    {
        
      
        Vector3 touchPosition = touch.position;

        // Set the distance from the camera to the object
        float distanceFromCamera = Vector3.Distance(transform.position, Camera.main.transform.position);

        // Convert the touch position to world coordinates with the same distance from the camera
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, distanceFromCamera));

        // Set the object's position to the touch position along the X and Y axes
        float ClampedY = Mathf.Clamp(worldPosition.y, 0, 50);
        transform.position = new Vector3(worldPosition.x, ClampedY, Modeloffset.z);
       
    }
    private void OnMouseUp()
    {
       
        
       
    }
    private void OnMouseDown()
    {
        
    }
    void OnRoundStarted()
    {
        
        
        IsRoundStarted = true;
       
    }
    public void RefreshModel()
    {
        ModelPlaced = false;
        Reset();

    }
}
