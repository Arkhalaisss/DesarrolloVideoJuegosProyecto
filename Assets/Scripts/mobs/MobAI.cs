using UnityEngine;
using UnityEngine.AI;

public class MobAI : MonoBehaviour
{
    public Transform target;
    public float detectionRange = 5f;
    public float attackRange = 1.5f;
    public int damage = 10;
    public float attackCooldown = 1.5f;

    private NavMeshAgent agent;
    private Animator anim;
    public PlayerHealth playerHealth;

    private float lastAttackTime = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.stoppingDistance = attackRange;

        if (target != null)
            playerHealth = target.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= detectionRange)
        {
            agent.SetDestination(target.position);

            float speed = agent.velocity.magnitude;
            anim.SetBool("isWalking", speed > 0.1f);

            // Si está en rango y quieto, intenta atacar
            if (distance <= attackRange && speed <= 0.1f)
            {
                if (Time.time >= lastAttackTime + attackCooldown)
                {
                    anim.SetBool("isAttacking", true); // activa ataque
                    lastAttackTime = Time.time;
                }
            }
            else
            {
                anim.SetBool("isAttacking", false);
            }
        }
        else
        {
            agent.ResetPath();
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
    }

    // Llamado por Animation Event en el frame del golpe
    public void DealDamage()
    {
        if (playerHealth != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance <= attackRange)
            {
              
                playerHealth.TakeDamage(damage);
            }
        }

        // Al terminar el golpe, vuelve a Idle
        anim.SetBool("isAttacking", false);
    }
}
