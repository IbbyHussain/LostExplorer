using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{

    Transform PlayerTransform;
    float Distance;
    public float TurretSight; // distance until turret will fire at player

    void Start()
    {
        // Get player transform
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Distance = Vector3.Distance(PlayerTransform.position, transform.position);

        if(Distance <= TurretSight) 
        {
            transform.LookAt(PlayerTransform);
            transform.Rotate(-90, 0, 0);
        }
    }
}
