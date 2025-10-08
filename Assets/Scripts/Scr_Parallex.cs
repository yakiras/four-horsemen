using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxSpeed = 0.5f; // smaller = slower movement
    private Vector3 lastCamPos;

    void Start()
    {
        lastCamPos = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cameraTransform.position - lastCamPos;
        // add delta * factor (not subtract). If it looks reversed, flip sign of factor.
        transform.position += new Vector3(delta.x * -parallaxSpeed, 0f, 0f);
        lastCamPos = cameraTransform.position;
    }
}
