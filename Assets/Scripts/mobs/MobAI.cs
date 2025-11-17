using UnityEngine;
using UnityEngine.AI;

public class MobAI : MonoBehaviour
{
    public Transform target; // El jugador
    public float detectionRange = 10f;

    private NavMeshAgent agent;
    private Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= detectionRange)
        {
            agent.SetDestination(target.position);

            if (anim != null)
                anim.SetBool("isWalking", true);
        }
        else
        {
            agent.ResetPath();

            if (anim != null)
                anim.SetBool("isWalking", false);
        }
    }
}
