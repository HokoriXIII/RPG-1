using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CameraRaycaster))]
public class CursorAffordance : MonoBehaviour {

    /**
    *  VARIABLES
    * */
    [SerializeField] const int walkableLayerNumber = 8;
    [SerializeField] const int enemyLayerNumber = 9;


    [SerializeField] Texture2D walkCursor = null;
    [SerializeField] Texture2D attackCursor = null;
    [SerializeField] Texture2D unknownCursor = null;
    [SerializeField] Vector2 cursorHotspot = new Vector2(0, 0);
    

    private CameraRaycaster cameraRaycaster;





    /**
    *  CLASS FUNCTIONS
    * */
    private void Start()
    {
        cameraRaycaster = GameObject.FindObjectOfType<CameraRaycaster>();
        cameraRaycaster.notifyLayerChangeObservers += OnLayerChange;                       // Add our function to the delegate list
    }











    /**
    *  FUNCTIONS
    * */
    private void OnLayerChange(int newLayer)
    {
        switch (newLayer)
        {
            case walkableLayerNumber:
                Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
                break;
            case enemyLayerNumber:
                Cursor.SetCursor(attackCursor, cursorHotspot, CursorMode.Auto);
                break;
            default:
                Cursor.SetCursor(unknownCursor, cursorHotspot, CursorMode.Auto);
                break;
        }

    }
}
