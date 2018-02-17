using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
    /**
     * VARIABLES
     * */
    private ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
    private CameraRaycaster cameraRaycaster;
    private Vector3 currentClickTarget;
    [SerializeField] float walkMoveStopRadius = 5f;





    /**
     * CLASS FUNCTIONS
     * */
    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }



    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            print("Cursor raycast hit " + cameraRaycaster.layerHit);

            switch(cameraRaycaster.layerHit)
            {
                case Layer.Walkable:
                    currentClickTarget = cameraRaycaster.hit.point;
                    break;
                case Layer.Enemy:
                    break;
                default:
                    Debug.Log("Layer is not supported.");
                    break;
            }



            
        }


        // Move the character if we are in the radius of the click
        var playerToClickPoint = currentClickTarget - transform.position;

        if(playerToClickPoint.magnitude >= walkMoveStopRadius)
            m_Character.Move(playerToClickPoint, false, false);
        else
            m_Character.Move(Vector3.zero, false, false);
    }







    /**
     * FUNCTIONS
     * */
}

