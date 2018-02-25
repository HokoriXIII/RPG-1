using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    /**
    *  VARIABLES
    * */
    public bool fixedCamera = true;



    private GameObject player;
    private GameObject myCamera;
    private Vector3 savedRotation;
    




    /**
    *  CLASS FUNCTIONS
    * */
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myCamera = GameObject.FindGameObjectWithTag("MainCamera");
        savedRotation = myCamera.transform.rotation.eulerAngles;
    }


    private void Update()
    {

    }

    private void LateUpdate()
    {
        transform.position = player.transform.position;

        if (!fixedCamera)
            myCamera.transform.rotation = player.transform.rotation;
        else
            myCamera.transform.eulerAngles  = savedRotation;
    }








    /**
    *  FUNCTIONS
    * */
}
