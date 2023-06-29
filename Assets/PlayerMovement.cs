using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.EventSystems;


public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private List<Rigidbody> RigRigidbodies;
    [SerializeField] public float Speed = 3;
    [SerializeField] private float StrafeSpeed = 3;

    [SerializeField] private float RotateSpeed = 10;

    [SerializeField] private Animator PlayerAnim;
    public bool isMoving = false;
    private Touch Xmove;
    public float posX = 0;
    public float posY = 0;
    public float YAxisMove = 0;

    private Vector3 Offset = new Vector3(0, 0.6f, 0);

    [SerializeField] private float PlayerClampXPos = 5.5f;
    //[SerializeField] private Joystick JoystickController;
    Vector3 ClampPlayerPosX = Vector3.zero;
    private bool IsDead = false;
    public bool UseJoystick = true;
    private bool IsEditor = false;
    [SerializeField]Direction DirectionToMOve = Direction.y;

    public delegate void PlayerInfoRaise(PlayerMovement Player);

    public static event PlayerInfoRaise DeliverPlayerInfo;


   
    private void Start()
    {
        //PlayerAnim = GetComponent<Animator>();
        //RagdollActive(false);
        if(Application.isEditor)
            IsEditor = true;
       

        DeliverPlayerInfo?.Invoke(this);
    }


  

    private void RoundStarted()
    {
        isMoving = true;
    }

    private void OnWIn(bool winstatus)
    {
        StrafeSpeed = 0;
        Speed = 0;
       
    }
    private void OnMouseDown()
    {
        isMoving = true;
    }
    private void OnMouseUp()
    {
        isMoving = false;
    }

    private void FixedUpdate()
    {
        DOMovement();
    }

    private void Update()
    {
        /*
        if (!isMoving && EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("UI");
            return;
        }
        */
       
       
    }
    
    private void FinishLineCrossed()
    {
        //isMoving = false;
        Speed = 0;
        StrafeSpeed = 0;
        transform.DOMoveX(0, 1).SetEase(Ease.Linear);
    }

    public void OnScaleChange(float ScaleVal)
    {
        Debug.Log("scale val " + ScaleVal);
        if (ScaleVal < 0)
        {
            PlayerClampXPos -= (ScaleVal * 2);
        }

        if (ScaleVal > 0)
        {
            PlayerClampXPos -= (ScaleVal * 2);
        }
    }

    private void OnPlayerDead(Transform player)
    {
        IsDead = true;
        //AlliesMovement.Instance.SetState(AllieState.Idle);
    }

    private void OnLevelFinish(Transform t)
    {
        //AlliesMovement.Instance.SetState(AllieState.Idle);
        PlayerAnim.SetTrigger("Win");
        //GameManagerTelekenisis.Instance.Win(true);
    }

    public void DOMovement()
    {
        if (IsDead || !isMoving)
        {
            return;
        }

        if (IsEditor)
        {
            posX = Input.GetAxis("Mouse X");
            posY = Input.GetAxis("Mouse Y");
            //posX = JoystickController.Horizontal;
            //YAxisMove = JoystickController.Vertical;


            //ClampPlayerPos();
        }
        else
        {
            Xmove = Input.GetTouch(0);
            //ClampPlayerPos();

            if (Xmove.phase == TouchPhase.Moved)
            {
                //For Joystick
                //posX = JoystickController.Horizontal;
                //YAxisMove = JoystickController.Vertical;
                posX = Input.GetAxis("Mouse X");
            }
            else if (Xmove.phase == TouchPhase.Ended)
            {
                posX = 0;
                YAxisMove = 0;
            }
        }

        Move(new Vector3(posX,posY,0));
    }

    void ClampPlayerPos()
    {
        ClampPlayerPosX = transform.position;
        ClampPlayerPosX.x = Mathf.Clamp(ClampPlayerPosX.x, -PlayerClampXPos, PlayerClampXPos);
        transform.position = ClampPlayerPosX;
    }

    void Move(Vector3 Axismove)
    {
        //Debug.Log("Move");
        //Vector3 playerpos = transform.position;
        // playerpos.x += Axismove.x;
        //transform.position = playerpos;
        if (DirectionToMOve == Direction.y)
            StrafeSpeed = 0;
        else
            Speed = 0;

        transform.position = new Vector3(Input.mousePosition.x, transform.position.y, Input.mousePosition.y);
        return;
            transform.position += (Vector3.right * Axismove.x * Time.deltaTime * StrafeSpeed +
                                   Vector3.forward * Time.deltaTime * Speed*Axismove.y);
        
    }


}