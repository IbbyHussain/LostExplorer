using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public AudioSource PickupSound;

    PlayerCollectibles playerCollectiblesScript;

    public TPS_Controller TPSController;

    private void OnTriggerEnter(Collider other)
    {
        // check if player collides with Health pickup using script
        playerCollectiblesScript = other.GetComponent<PlayerCollectibles>();

        // if valid
        if (playerCollectiblesScript != null)
        {
            // collect Health pickup and heal player
            TPSController.Heal(25.0f);
            PickupSound.Play(); // Play pickupSound
            gameObject.SetActive(false);
        }
    }

    // Spin Health Pickup in local space
    void SpinHealthPickup()
    {
        transform.Rotate(0f, 40 * Time.deltaTime, 0f, Space.Self);
    }

    private void Update()
    {
        SpinHealthPickup();
    }
}
