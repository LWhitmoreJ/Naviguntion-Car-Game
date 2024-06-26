using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject playerCar; // Reference to the player car
    public float movementForce = 10f; // Force to move the enemy car
    public float rotationSpeed = 50f; // Speed of rotation
    public int maxHealth = 60;
    private int currentHealth;
    public static int enemiesDestroyed = 0;

    private Rigidbody rb;

    void Start()
    {
        playerCar = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        if (playerCar != null)
        {
            // Calculate direction to player
            Vector3 direction = (playerCar.transform.position - transform.position).normalized;
            direction.y = 0f; // Keep the direction in the horizontal plane 

            if (direction != Vector3.zero)
            {
                // Rotate towards player
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                //rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime));
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }

            // Apply force to move forward
            rb.AddForce(transform.forward * movementForce);

        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
             enemiesDestroyed++;
            Destroy(gameObject);
        }
    }
    
}   
