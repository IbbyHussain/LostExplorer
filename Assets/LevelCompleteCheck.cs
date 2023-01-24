using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteCheck : MonoBehaviour
{
    PlayerCollectibles playerCollectiblesScript;

    private void OnTriggerEnter(Collider other)
    {
        // check if player collides with level complete object using script
        TPS_Controller TPSController = other.GetComponent<TPS_Controller>();

        if (TPSController != null)
        {
            TPSController.LVLComplete.LevelCompleted();
            gameObject.SetActive(false);
        }
    }
}
