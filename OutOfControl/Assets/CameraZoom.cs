using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour
{
    private Camera camera;
    private float zoomDuration;
    public float quickZoomSize;
    public float quickZoomDuration;
    public float originalProjectionSize;

    private bool isZooming = false;

    void Awake() {
        if (camera == null) camera = GetComponent<Camera>();
        originalProjectionSize = camera.orthographicSize;
    }

    void FixedUpdate() {
        if (zoomDuration > 0) {
            float step = (zoomDuration -= Time.deltaTime) / quickZoomDuration;
            camera.orthographicSize = Mathf.Lerp(originalProjectionSize, quickZoomSize, step);
        } else {
            zoomDuration = 0;
            isZooming = false;
        }
    }

    public void quickZoom() {
        if (!isZooming) {
            isZooming = true;
            zoomDuration = quickZoomDuration;
        }
    }
}