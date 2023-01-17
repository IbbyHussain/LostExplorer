using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage; // set in editor

    private void OnTriggerEnter(Collider other)
    {
        // check if hit player then take damage
        TPS_Controller TPSController = other.GetComponent<TPS_Controller>();
        if(TPSController != null) 
        {
            TPSController.TakeDamage(Damage);
        }
    }
}
