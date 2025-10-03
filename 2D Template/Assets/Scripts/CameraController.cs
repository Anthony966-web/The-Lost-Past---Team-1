using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0, 0.1f)]
    public float smoothTime;

    public Transform playerTransform;
    public float amountToZoom = 10f;

    public void FixedUpdate()
    {
        Vector3 pos = GetComponent<Transform>().position;

        pos.x = Mathf.Lerp(pos.x, playerTransform.position.x, smoothTime);
        pos.y = Mathf.Lerp(pos.y, playerTransform.position.y, smoothTime);

        //pos.x = Mathf.Clamp(pos.x, 0 + (orthoSize * 1.775f), worldSize - (orthoSize * 1.775f));

        GetComponent<Transform>().position = pos;
    }
}
