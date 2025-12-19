using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera cam;
    public float attackRange = 4f;
    public int damage = 20;
    public LayerMask hitLayers;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // click izquierdo
        {
            anim.SetTrigger("Attack"); // dispara animación
            Attack();
        }
    }

    void Attack()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, hitLayers))
        {
            Vector3 lookPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(lookPoint);

            float distance = Vector3.Distance(transform.position, hit.point);
            Debug.Log("Raycast golpeó: " + hit.collider.name + " a distancia " + distance);

            if (distance <= attackRange)
            {
                MobHealth mobHealth = hit.collider.GetComponentInParent<MobHealth>();
                if (mobHealth != null)
                {
                    mobHealth.TakeDamage(damage);
                    Debug.Log("Jugador golpeó a " + hit.collider.name);
                }
                else
                {
                    Debug.Log("No se encontró MobHealth en " + hit.collider.name);
                }
            }
        }
    }

}
