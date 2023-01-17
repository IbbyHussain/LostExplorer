using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public AudioSource PickupSound;

    PlayerCollectibles playerCollectiblesScript;

    private void OnTriggerEnter(Collider other)
    {
        // check if player collides with coin using script
        playerCollectiblesScript = other.GetComponent<PlayerCollectibles>();

        // if valid
        if(playerCollectiblesScript != null) 
        {
            // collect coin
            playerCollectiblesScript.CoinCollected();
            PickupSound.Play(); // Play pickupSound
            gameObject.SetActive(false);
        }
    }

    // Spin coin in local space
    void SpinCoin() 
    {
        transform.Rotate(0f, 40 * Time.deltaTime, 0f, Space.Self);
    }

    private void Update()
    {
        SpinCoin();
    }
}
