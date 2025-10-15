using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomOutSize = 3f;
    public float zoomInSize = 1f;
    public float zoomSpeed = 2f;

    private float targetSize;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        targetSize = zoomInSize;
    }

    void Update()
    {
        mainCamera.orthographicSize = Mathf.Lerp(
            mainCamera.orthographicSize,
            targetSize,
            Time.deltaTime * zoomSpeed
        );
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetSize = zoomOutSize;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetSize = zoomInSize;
        }
    }
}
