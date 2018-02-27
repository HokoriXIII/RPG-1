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
        



        if (fixedCamera)
        {
            transform.position = player.transform.position;
            myCamera.transform.rotation = savedRotation;
            myCamera.transform.position = transform.position + savedPositionOffset;
        }
        else
        {
            //SmoothFollow();           

        }
    }








    /**
    *  FUNCTIONS
    * */

    // TODO: Still working on this
    private void SmoothFollow()
    {
        float distanceFromTarget = 8f;
        float heightAboveGround = 2f;

        float rotationDamping = 10f;
        float moveDamping = 5f;




        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * moveDamping);
        Vector3 wantedCameraPosition = transform.TransformPoint(0, heightAboveGround, -distanceFromTarget);  
        myCamera.transform.position = Vector3.Lerp(myCamera.transform.position, wantedCameraPosition, Time.deltaTime * moveDamping);




        Quaternion wantedRotation = Quaternion.LookRotation(player.transform.position - transform.position, player.transform.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
        //myCamera.transform.rotation.SetLookRotation(transform.position);




    }
}
