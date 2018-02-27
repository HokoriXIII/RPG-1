using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{

    /**
     * VARIABLES
     * */

    public Layer[] layerPriorities = {
        Layer.Enemy,
        Layer.Walkable
    };
    public delegate void OnLayerHasChanged(Layer newLayer);               // Delclare the delagate
    public event OnLayerHasChanged layerChangeObserver;           // Instantiate an observer



    [SerializeField]float distanceToBackground = 100f;



    private Camera viewCamera;
    private RaycastHit raycastHit;
    private Layer layerHit;

    




   



    /**
     * CLASS FUNCTIONS
     * */
    private void Start()
    {
        viewCamera = Camera.main;
    }

    private void Update()
    {
        // Look for and return priority layer hit
        foreach (Layer layer in layerPriorities)
        {
            var hit = RaycastForLayer(layer);
            if (hit.HasValue)
            {
                raycastHit = hit.Value;

                // If we are looking at a different layer than let all functions listening to our delagate know
                if (layerHit != layer)
                {
                    layerHit = layer;
                    layerChangeObserver(layer);
                }

                layerHit = layer;
                return;
            }
        }


        // Otherwise return background hit
        raycastHit.distance = distanceToBackground;
        layerHit = Layer.RaycastEndStop;
        layerChangeObserver(layerHit);

    }






    /**
     * FUNCTIONS
     * */
    public RaycastHit? RaycastForLayer(Layer layer)
    {
        int layerMask = 1 << (int)layer; // See Unity docs for mask formation
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit; // used as an out parameter
        bool hasHit = Physics.Raycast(ray, out hit, distanceToBackground, layerMask);
        if (hasHit)
        {
            return hit;
        }
        return null;
    }

    public Layer currentLayerHit
    {
        get { return layerHit; }
    }

    public RaycastHit hit
    {
        get { return raycastHit; }
    }
}
