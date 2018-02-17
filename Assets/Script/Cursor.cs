using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    /**
    *  VARIABLES
    * */
    CameraRaycaster cameraRaycaster;





    /**
    *  CLASS FUNCTIONS
    * */
    private void Start()
    {
        cameraRaycaster = GameObject.FindObjectOfType<CameraRaycaster>();
    }


    private void Update()
    {
        
    }








    /**
    *  FUNCTIONS
    * */
}
