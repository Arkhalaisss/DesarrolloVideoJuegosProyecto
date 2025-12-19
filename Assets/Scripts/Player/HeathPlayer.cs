using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animator anim;
    public Transform RespawnPoint;


    void Start(){
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        PlayerBlock block = GetComponent<PlayerBlock>();
        if (block != null && block.isBlocking)
        {
            // Reducir daño si está bloqueando
            amount = Mathf.FloorToInt(amount * 1); // solo 30% del daño
            Debug.Log("Jugador bloqueó el daño!");

        }
        else {
            currentHealth -= amount;
        }
            
        Debug.Log("Jugador recibió daño. Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            anim.SetTrigger("Die");
           
        }
    }

    public void Die()
    {
        
        Debug.Log("Jugador murió!");
        // Mover al jugador al respawn
        GetComponent<CharacterController>().enabled = false;
        transform.position = RespawnPoint.position;
        anim.SetTrigger("Respawn");
        GetComponent<CharacterController>().enabled = true;
        // Restaurar vida
        currentHealth = maxHealth;
        
    }
}
