using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialHelper : MonoBehaviour
{
    public delegate void CarClicked(Transform car);
    public static event CarClicked OncarClicked;
    bool IsClicked = false;
    private void OnMouseDown()
    {
        if (IsClicked) return;
        IsClicked = true;
        OncarClicked?.Invoke(transform);
        Debug.Log("Clicked  " + transform.name);
    }
}
