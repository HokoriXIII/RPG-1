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

    // Used to save values for the fixed camera setup
    private Quaternion savedRotation;
    private Vector3 savedPositionOffset;






    /**
    *  CLASS FUNCTIONS
    * */
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myCamera = GameObject.FindGameObjectWithTag("MainCamera");

        savedRotation = myCamera.transform.rotation;
        savedPositionOffset = myCamera.transform.position;
    }


    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        // Move our camera arm to the location of our player
        transform.position = player.transform.position;



        if (fixedCamera)
        {      
            myCamera.transform.rotation = savedRotation;
            myCamera.transform.position = transform.position + savedPositionOffset;
        }
        else
        {
            myCamera.transform.rotation = Quaternion.Lerp(myCamera.transform.rotation, transform.rotation, (1f * Time.deltaTime));

        }
    }








    /**
    *  FUNCTIONS
    * */
}
