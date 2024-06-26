using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float distance = 10f; // Distance from player
    public float height = 2f; // Height above player

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = player.position - player.forward * distance;
        desiredPosition.y = player.position.y + height;

        // Set the position of the camera
        transform.position = desiredPosition;

        // Look at the player
        transform.LookAt(player);
    }
}
