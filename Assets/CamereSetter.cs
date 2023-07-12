using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CamereSetter : MonoBehaviour
{
    [SerializeField] bool Rotated = false;
    public delegate void CamereSetterDelegate();
    public static event CamereSetterDelegate OnCameraRotated;
    // Start is called before the first frame update
    void Start()
    {
        if(Rotated)
            OnCameraRotated?.Invoke();

        // Output the resolution details
        
        //float CamHeight = currentResolution.width / 1920;
        //if(currentResolution.width>=1920)
        //transform.position += new Vector3(0, CamHeight, 0);
        //Debug.Log("Refresh Rate: " + currentResolution.refreshRate);
       // Debug.Log(currentResolution.width+" Current Resolution: " + CamHeight+ "x" + currentResolution.height);
    }

}
