using UnityEngine;

public class PlayerMovementCotL : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Normalizar la dirección para que no corra más en diagonal
        Vector3 direction = new Vector3(x, 0, z).normalized;

        // Aplicar movimiento
        rb.velocity = direction * speed + new Vector3(0, rb.velocity.y, 0);

        // Rotar el modelo hacia la dirección de movimiento
        if (direction.magnitude > 0.1f)
        {
            // Rotación suave
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}
