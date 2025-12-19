using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    private Animator anim;
    public bool isBlocking = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Mantener botón derecho del mouse para bloquear
        if (Input.GetMouseButton(1)) // botón derecho
        {
            isBlocking = true;
            anim.SetBool("isBlocking", true);
        }
        else
        {
            isBlocking = false;
            anim.SetBool("isBlocking", false);
        }
    }
}
