using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAffordance : MonoBehaviour {

    /**
    *  VARIABLES
    * */
    [SerializeField] Texture2D walkCursor = null;
    [SerializeField] Texture2D attackCursor = null;
    [SerializeField] Texture2D noWalkCursor = null;
    [SerializeField] Vector2 cursorHotspot = new Vector2(96, 96);
    private CameraRaycaster cameraRaycaster;





    /**
    *  CLASS FUNCTIONS
    * */
    private void Start()
    {
        cameraRaycaster = GameObject.FindObjectOfType<CameraRaycaster>();
    }


    private void Update()
    {
        switch (cameraRaycaster.layerHit)
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








    /**
    *  FUNCTIONS
    * */
}
