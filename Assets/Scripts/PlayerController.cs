using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float horsepower = 100;
    private Rigidbody playerRb;
    public float rotationSpeed = 100f;   
    private float xBound = 73f;
    private float zBound = 46f;
    [SerializeField] GameObject centerOfMass;
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthBar;
    private GameManager gameManager;
    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    public AudioClip engineSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    public void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position * centerOfMass.transform.rotation.y;
        horsepower = horsepower * 1000;

        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameManager.isGameActive == true)
        {
            CarControl();
            PlayerOOB();
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        }

    }

    public void CarControl()
    {
         float carSpeed = Input.GetAxis("Vertical");
        float turningRadius = Input.GetAxis("Horizontal");
       
       carSpeed *= Time.deltaTime;
       turningRadius *= Time.deltaTime;

        //Moves the car forward vertically
        playerRb.AddRelativeForce(Vector3.back * carSpeed * horsepower);
        
        //transform.Translate(carSpeed,0 , 0 );
        //Allow the user to rotate the vehice 
        transform.Rotate(0, turningRadius * rotationSpeed, 0);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
             TakeDamage(10);
             playerAudio.PlayOneShot(crashSound, 1.0f);
        }   
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
             powerupIndicator.gameObject.SetActive(true);
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(12);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
    }
    public void PlayerOOB()
    {   //Constrains the player from moving past the game plane
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
    }
}
