using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{

    Transform PlayerTransform;
    float Distance;
    public float TurretSight; // distance until turret will fire at player

    public GameObject Projectile;

    public Transform TurretBarrelTransform; // Where to spawn projectile

    public float TurretHealth = 100.0f;

    public AudioSource TurretDeath;
    public ParticleSystem TurretExplosion;

    public Transform TurretExplosionTransform;

    // Fire Rate
    public float FireRate;
    float NextFire; // Time between shots, keeps fire rate synchronised

    // Fire sound
    public AudioSource FireSound;

    // Fire effect
    public ParticleSystem FireEffect;

    public void TurretTakeDamage(float DamageAmount) 
    {
        if (TurretHealth >= 0)
        {
            TurretHealth -= DamageAmount;

            // Turret Death
            if (TurretHealth <= 0)
            {
                Debug.Log("Turret Dead");

                FireEffect.Stop();

                // Play explosion effect
                if (TurretExplosion) 
                {
                    TurretExplosion.transform.position = TurretExplosionTransform.position;
                    TurretExplosion.Play();
                }
           

                // play sound
                TurretDeath.Play();

                gameObject.SetActive(false);
            }
        }
    }

    void TurretFire() 
    {
        // Instantiate projectile
        GameObject ProjectileRef = Instantiate(Projectile, TurretBarrelTransform.position, TurretBarrelTransform.rotation);
        ProjectileRef.GetComponent<Rigidbody>().AddForce(TurretBarrelTransform.up * 1500f * -1f); // .up as rotation of barrel is wrong and *1 to make it sure forwards instead of backwards

        // Play fire effect at barrel of turret
        FireEffect.transform.position = TurretBarrelTransform.position;
        FireEffect.Play();

        FireSound.Play();
        Destroy(ProjectileRef, 5.0f); // destroy after 5 seconds
    }

    void Start()
    {
        // Get player transform
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Calculate distance to player, as turret will only shoot player when they are in range
        Distance = Vector3.Distance(PlayerTransform.position, transform.position);

        if(Distance <= TurretSight) 
        {
            // rotate to face player
            transform.LookAt(PlayerTransform);

            // Adjustment as mesh was rotated wrong in blender
            transform.Rotate(-90, 0, 0);

            // fire rate setup
            if(Time.time >= NextFire) 
            {
                NextFire = Time.time + 1f / FireRate;
                TurretFire();
            }
        }

        else 
        {
            FireEffect.Pause();
        }
    }
}
