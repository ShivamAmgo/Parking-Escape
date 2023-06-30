using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarEscapeManager : MonoBehaviour
{
    public static CarEscapeManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        //Vibration.Init();

    }
    private void OnEnable()
    {
        ExitDoor.OnDoorExit += OnExitDoor;
    }
    private void OnDisable()
    {
        ExitDoor.OnDoorExit -= OnExitDoor;
    }

    private void OnExitDoor(bool WinStatus)
    {
        SceneManager.LoadScene(0);
    }
}
