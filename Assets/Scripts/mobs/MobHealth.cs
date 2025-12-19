using UnityEngine;
using UnityEngine.AI;

public class MobHealth : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;
    private Animator anim;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        Debug.Log(gameObject.name + " recibió daño. Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
       // else
        //{
            //if (anim != null)
               // anim.SetTrigger("Hit"); // animación de golpe opcional
       // }
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log(gameObject.name + " murió!");

        if (anim != null)
            anim.SetTrigger("Die");

        // Desactivar IA y colisiones
        GetComponent<MobAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // Destruir después de unos segundos
        Destroy(gameObject, 3f);
    }
}
