using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float health = 100;
    public float moveSpeed = 3.0f;
    private GameObject player; // Para rastrear al jugador
    private Animator animator; // Si hay animaciones para el jefe
    private int hitCount = 0;
    public float attackRange = 2.0f; // Rango de ataque
    public float attackCooldown = 3.0f; // Tiempo de espera entre ataques
    public float safeDistance = 2.0f; // Distancia de Boss
    private float lastAttackTime;

    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Alex");
        animator = GetComponent<Animator>();
        // Inicializar otros componentes si es necesario
    }

    void Update()
    {
        FollowPlayer();
        if (player != null && IsPlayerInRange() && Time.time > lastAttackTime + attackCooldown)
        {
            AttackPlayer();
        }
    }

    void FollowPlayer()
    {
        if (player == null) return;

        Vector3 playerPosition = player.transform.position;
        Vector3 bossPosition = transform.position;
        float distanceToPlayer = Vector3.Distance(bossPosition, playerPosition);

        // Mover al jefe solo si está fuera de la distancia segura
        if (distanceToPlayer > safeDistance)
        {
            Vector3 newPosition = Vector2.MoveTowards(bossPosition, new Vector2(playerPosition.x, bossPosition.y), moveSpeed * Time.deltaTime);
            transform.position = newPosition;
        }

        // Ajustar la dirección de la mirada del jefe
        if (playerPosition.x > bossPosition.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (playerPosition.x < bossPosition.x)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Implementar la lógica de colisión, por ejemplo, recibir daño de las balas
    }


    public void TakeDamage()
    {
        hitCount++; // Incrementar el contador de disparos
        animator.SetTrigger("Hurt");
        if (hitCount >= 10) // Verificar si el jefe ha recibido 10 disparos
        {
            animator.SetTrigger("Death"); // Activar la animación de muerte
            StartCoroutine(DestroyAfterAnimation());
        }
    }

    IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(1.0f); // Espera la duración de la animación de muerte
        Destroy(gameObject);
    }

    private bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= attackRange;
    }

    private void AttackPlayer()
    {
        // Aquí puedes activar una animación de ataque
        animator.SetTrigger("Attack");

        float damageAmount = 20f; // Puedes ajustar este valor según sea necesario

        // Aplicar daño al jugador
        if (IsPlayerInRange()) 
        {
            // player.GetComponent<Alex_movement>().TakeDamage(damageAmount);
            player.GetComponent<Alex_movement>().Hit();

        }
        // Aplicar daño al jugador, asumiendo que el jugador tiene un método 'TakeDamage'
        // player.GetComponent<PlayerScript>().TakeDamage(damageAmount);

        lastAttackTime = Time.time;
    }

    // Resto del código para manejar la salud, daño, etc.
}
