using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public Transform bulletSpawnPoint2;
    public PlayerController playerController;
    public AudioClip bulletSound;
    private AudioSource playerAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.hasPowerup && Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            playerAudio.PlayOneShot(bulletSound, .5f);
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Instantiate(bulletPrefab, bulletSpawnPoint2.position, bulletSpawnPoint2.rotation);
    }
}
