using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CameraRaycaster))]
public class CursorAffordance : MonoBehaviour {

    /**
    *  VARIABLES
    * */
    [SerializeField] Texture2D walkCursor = null;
    [SerializeField] Texture2D attackCursor = null;
    [SerializeField] Texture2D noWalkCursor = null;
    [SerializeField] Vector2 cursorHotspot = new Vector2(0, 0);
    private CameraRaycaster cameraRaycaster;





    /**
    *  CLASS FUNCTIONS
    * */
    private void Start()
    {
        cameraRaycaster = GameObject.FindObjectOfType<CameraRaycaster>();
        cameraRaycaster.layerChangeObserver += OnLayerChange;                       // Add our function to the delegate list
    }











    /**
    *  FUNCTIONS
    * */
    private void OnLayerChange()
    {
        switch (cameraRaycaster.currentLayerHit)
        {
            case Layer.Walkable:
                Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.Enemy:
                Cursor.SetCursor(attackCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.RaycastEndStop:
                Cursor.SetCursor(noWalkCursor, cursorHotspot, CursorMode.Auto);
                break;
            default:
                Debug.LogError("CursorAffordance-Update-Layer not supported");
                break;
        }

    }
}
