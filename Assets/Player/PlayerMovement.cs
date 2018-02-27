using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.AI;

[RequireComponent(typeof (ThirdPersonCharacter))]
[RequireComponent(typeof (NavMeshAgent))]
[RequireComponent(typeof (AICharacterControl))]
public class PlayerMovement : MonoBehaviour
{
    /**
     * VARIABLES
     * */
    private ThirdPersonCharacter character = null;   // A reference to the ThirdPersonCharacter on the object
    private CameraRaycaster cameraRaycaster = null;
    private AICharacterControl aiCharacterControl = null;
    private GameObject walkTarget = null;
    private Vector3 currentDestination;
    private bool isMouseMovementMode = true;



    [SerializeField] const int walkableLayerNumber = 8;
    [SerializeField] const int enemyLayerNumber = 9;






    /**
     * CLASS FUNCTIONS
     * */
    private void Start()
    {
        // Get handles to our gameobjects
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        character = GetComponent<ThirdPersonCharacter>();
        aiCharacterControl = GetComponent<AICharacterControl>();
        walkTarget = new GameObject("walkTarget");


        // Add our function to the listener of the raycaster
        cameraRaycaster.notifyMouseClickObservers += ProccessMouseClick;


        // Save our starting position
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


    }


    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.black;

        //// Draw a line for our current movement
        //Gizmos.DrawLine(transform.position, currentDestination);
        //Gizmos.DrawSphere(currentDestination, 0.1f);

        //// Visualize walk stop radius
        //Gizmos.DrawSphere(clickPoint, .15f);


        //// Draw attack sphere
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, attackMoveStopRadius);
    }







    /**
     * FUNCTIONS
     * */
    private void ProccessMouseClick(RaycastHit raycastHit, int layerHit)
    {
        switch (layerHit)
        {
            case enemyLayerNumber:
                // Navigate to enemy
                GameObject enemy = raycastHit.collider.gameObject;
                aiCharacterControl.SetTarget(enemy.transform);
                break;
            case walkableLayerNumber:
                // Navigate to point on ground
                walkTarget.transform.position = raycastHit.point;
                aiCharacterControl.SetTarget(walkTarget.transform);
                break;
            default:
                Debug.LogError("PlayerMovement-ProcessMouseClick-Dont know the layer to use: " + layerHit);
                break;
        }

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

