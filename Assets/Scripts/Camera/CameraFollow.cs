using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // El jugador
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desired = new Vector3(
            target.position.x,
            transform.position.y,
            target.position.z - 8f
        );

        transform.position = Vector3.Lerp(transform.position, desired, smoothSpeed * Time.deltaTime);
    }
}
