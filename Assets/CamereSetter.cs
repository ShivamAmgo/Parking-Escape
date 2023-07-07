using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Resolution currentResolution = Screen.currentResolution;

        // Output the resolution details
        
        float CamHeight = currentResolution.width / 1920;
        if(currentResolution.width>=1920)
        transform.position += new Vector3(0, CamHeight, 0);
        //Debug.Log("Refresh Rate: " + currentResolution.refreshRate);
       // Debug.Log(currentResolution.width+" Current Resolution: " + CamHeight+ "x" + currentResolution.height);
    }

}
