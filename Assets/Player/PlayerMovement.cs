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
    private Vector3 currentDestination;
    private Vector3 clickPoint;
    private bool isMouseMovementMode = true;
    [SerializeField] float walkMoveStopRadius = 1f;
    [SerializeField] float attackMoveStopRadius = 5f;





    /**
     * CLASS FUNCTIONS
     * */
    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        character = GetComponent<ThirdPersonCharacter>();

        currentDestination = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {


        // Change our movement control system
        if (Input.GetKeyDown(KeyCode.G))
        {
            isMouseMovementMode = !isMouseMovementMode;
            currentDestination = transform.position;
        }



        // Use the mouse
        if (isMouseMovementMode)
            ProcessMouseMovement();
        // Use keyboard or gamepad
        else
            ProcessKeyboardMovement();


    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;

        // Draw a line for our current movement
        Gizmos.DrawLine(transform.position, currentDestination);
        Gizmos.DrawSphere(currentDestination, 0.1f);

        // Visualize walk stop radius
        Gizmos.DrawSphere(clickPoint, .15f);


        // Draw attack sphere
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackMoveStopRadius);
    }







    /**
     * FUNCTIONS
     * */
    private void ProcessMouseMovement()
    {
        if (Input.GetMouseButton(0))
        {
            clickPoint = cameraRaycaster.hit.point;

            switch (cameraRaycaster.currentLayerHit)
            {
                case Layer.Walkable:
                    currentDestination = ShortDestination(clickPoint, walkMoveStopRadius);
                    break;
                case Layer.Enemy:
                    currentDestination = ShortDestination(clickPoint, attackMoveStopRadius);
                    break;
                case Layer.RaycastEndStop:
                    break;
                default:
                    Debug.Log("Layer " + cameraRaycaster.currentLayerHit + " is not supported.");
                    break;
            }
        }


        // Move the character if we are in the radius of the click
        var playerToClickPoint = currentDestination - transform.position;

        if (playerToClickPoint.magnitude >= 0)
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


    private Vector3 ShortDestination(Vector3 destination, float shortening)
    {
        Vector3 reductionVector = (destination - transform.position).normalized * shortening;
        return (destination - reductionVector);
    }
}

