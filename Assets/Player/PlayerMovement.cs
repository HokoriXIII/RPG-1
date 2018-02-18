using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
    /**
     * VARIABLES
     * */
    private ThirdPersonCharacter character;   // A reference to the ThirdPersonCharacter on the object
    private CameraRaycaster cameraRaycaster;
    private Vector3 currentClickTarget;
    private bool isMouseMovementMode = true;
    [SerializeField] float walkMoveStopRadius = 5f;





    /**
     * CLASS FUNCTIONS
     * */
    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        character = GetComponent<ThirdPersonCharacter>();

        currentClickTarget = transform.position;
    }



    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {


        // Change our movement control system
        if (Input.GetKeyDown(KeyCode.G))
        {
            isMouseMovementMode = !isMouseMovementMode;
            currentClickTarget = transform.position;
        }



        // Use the mouse
        if (isMouseMovementMode)
            ProcessMouseMovement();
        // Use keyboard or gamepad
        else
            ProcessKeyboardMovement();


    }







    /**
     * FUNCTIONS
     * */
    private void ProcessMouseMovement()
    {
        if (Input.GetMouseButton(0))
        {
            print("Cursor raycast hit " + cameraRaycaster.currentLayerHit);

            switch (cameraRaycaster.currentLayerHit)
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

        if (playerToClickPoint.magnitude >= walkMoveStopRadius)
            character.Move(playerToClickPoint, false, false);
        else
            character.Move(Vector3.zero, false, false);
    }


    private void ProcessKeyboardMovement()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");



        // calculate camera relative direction to move:
        Vector3 camForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 move = v * camForward + h * Camera.main.transform.right;

        character.Move(move, false, false);
    }
}

