using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // El jugador
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(0f, 2f, -2f); // Ajusta estos valores en el Inspector
    void LateUpdate()
    {
        if (target == null) return;

        // Posición deseada con offset
        Vector3 desired = target.position + offset;

        // Movimiento suave
        transform.position = Vector3.Lerp(transform.position, desired, smoothSpeed * Time.deltaTime);

        // Opcional: que la cámara siempre mire al jugador
        
    }
}
