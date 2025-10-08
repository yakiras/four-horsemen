using UnityEngine;

public class Scr_CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform mapLeft;
    public Transform mapRight;
    public Transform mapTop;
    public Transform mapBottom;
    public float smooth = 1f;

    private Vector2 minPosition;
    private Vector2 maxPosition;
    private Vector3 offset;
    private float halfWidth;
    private float halfHeight;

    void Start()
    {
        offset = transform.position - target.position;

        minPosition.x = mapLeft.position.x;
        maxPosition.x = mapRight.position.x;
        minPosition.y = mapBottom.position.y;
        maxPosition.y = mapTop.position.y;

        Camera cam = GetComponent<Camera>();
        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * cam.aspect;
    }

    void LateUpdate()
    {
        Vector3 desired = target.position + offset + (3*Vector3.up);
        Vector3 clamped = new Vector3(
            Mathf.Clamp(desired.x, minPosition.x + halfWidth, maxPosition.x - halfWidth),
            Mathf.Clamp(desired.y, minPosition.y + halfHeight, maxPosition.y - halfHeight),
            desired.z
        );
        transform.position = Vector3.Lerp(transform.position, clamped, smooth);
    }
}
