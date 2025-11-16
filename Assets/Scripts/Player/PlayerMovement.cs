using UnityEngine;

public class PlayerMovementSimple : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public float rotationSpeed = 10f;

    private CharacterController controller;
    private Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        // Si el Animator está en un hijo del Player, usa GetComponentInChildren
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 inputDir = new Vector3(h, 0, v).normalized;

        if (inputDir.magnitude >= 0.1f)
        {
            // Rotación hacia la dirección del movimiento
            Quaternion targetRot = Quaternion.LookRotation(inputDir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);

            // ¿Está corriendo?
            bool isRunning = Input.GetKey(KeyCode.LeftShift);

            // Movimiento
            float currentSpeed = isRunning ? runSpeed : walkSpeed;
            controller.Move(inputDir * currentSpeed * Time.deltaTime);

            // Animaciones
            anim.SetBool("isWalking", !isRunning);
            anim.SetBool("isRunning", isRunning);
        }
        else
        {
            // Idle
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
    }
}
