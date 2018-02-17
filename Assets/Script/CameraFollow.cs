using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    /**
    *  VARIABLES
    * */
    private GameObject player;





    /**
    *  CLASS FUNCTIONS
    * */
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {

    }

    private void LateUpdate()
    {
        transform.position = player.transform.position;
    }








    /**
    *  FUNCTIONS
    * */
}
