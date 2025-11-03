using UnityEngine;

public class CameraParallax : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layerTransform;   // Layer object (e.g., Layer_1)
        [Range(0f, 1f)]
        public float parallaxFactor = 0.5f; // 0 = di chuyển chậm, 1 = theo camera hoàn toàn
    }

    [SerializeField] private ParallaxLayer[] layers;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        foreach (var layer in layers)
        {
            if (layer.layerTransform != null)
            {
                float factor = layer.parallaxFactor;
                layer.layerTransform.position += new Vector3(deltaMovement.x * factor, deltaMovement.y * factor, 0);
            }
        }

        lastCameraPosition = cameraTransform.position;
    }
}
