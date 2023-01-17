using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{

    Transform PlayerTransform;
    float Distance;
    public float TurretSight; // distance until turret will fire at player

    public GameObject Projectile;

    public Transform TurretBarrelTransform;

    // Fire Rate
    public float FireRate;
    float NextFire;

    void TurretFire() 
    {
        // Instantiate projectile
        GameObject ProjectileRef = Instantiate(Projectile, TurretBarrelTransform.position, TurretBarrelTransform.rotation);
        ProjectileRef.GetComponent<Rigidbody>().AddForce(TurretBarrelTransform.up * 1500f * -1f);
        Destroy(ProjectileRef, 5.0f);
    }

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

            // Adjustment as mesh was rotated wrong in blender
            transform.Rotate(-90, 0, 0);

            if(Time.time >= NextFire) 
            {
                NextFire = Time.time + 1f / FireRate;
                TurretFire();
            }
        }
    }
}
