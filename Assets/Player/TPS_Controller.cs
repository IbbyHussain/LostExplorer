using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;


public class TPS_Controller : MonoBehaviour
{
    [SerializeField]  private CinemachineVirtualCamera AimingCamera;

    // Sensitivity values 
    [SerializeField] private float DefaultSensitivity;
    [SerializeField] private float AimingSensitivity;

    [SerializeField] private LayerMask AimColliderLayerMask = new LayerMask();

    [SerializeField] private Transform DebugTransform;

    // Shoot 

    [SerializeField] private Transform VFXHitGreen;
    [SerializeField] private Transform VFXHitRed;


    private ThirdPersonController TPC;
    private StarterAssetsInputs StarterInputs;

    // General

    [SerializeField] HPBar HPBarScript;
    [SerializeField] public STBar STBarScript;

    public float CurrentHealth = 100;
    public float MaxHealth = 100;

    public float CurrentStamina = 100;
    public float MaxStamina = 100;

    float SprintDrain = 0.01f;

    // Get starter inputs
    private void Awake()
    {
        TPC = GetComponent<ThirdPersonController>();
        StarterInputs = GetComponent<StarterAssetsInputs>();
    }

    // Start Function
    void Start()
    {
        
    }

    // Sprint Function
    void Sprint() 
    {
        // If player presses sprint and there is enough stamina -- Doesnt actually stop player from sprinting
        if (StarterInputs.sprint) 
        {
            // sprint if enough stamina
            if(CurrentStamina >= SprintDrain) 
            {
                StarterInputs.sprint = true;
                StarterInputs.Aim = false; // disable aiming when sprinting
                StarterInputs.Shoot = false; // disable shooting when sprinting

                CurrentStamina -= SprintDrain;

                STBarScript.SetCurrentStamina(CurrentStamina);
            }

            else 
            {
                StarterInputs.sprint = false;
                StarterInputs.Aim = true;
                StarterInputs.Shoot = true;
            }
        }
    }

    // Damage
    void TakeDamage(float Amount) 
    {
        if(CurrentHealth >= 0) 
        {
            CurrentHealth -= Amount;

            HPBarScript.SetCurrentHealth(CurrentHealth);

            if(CurrentHealth <= 0) 
            {
                // Death

                Debug.Log("Dead");
            }
        }
    }

  
    
    // Update Function
    void Update()
    {

        Sprint();

        Vector3 MouseWorldPosition = Vector3.zero;

        // Get centre of screen for raycast
        Vector2 ScreenCentrePoint = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);

        // Ray cast to centre of screen
        Ray RayCast = Camera.main.ScreenPointToRay(ScreenCentrePoint);

        Transform HitTransform = null;

        // If ray cast hit object
        if (Physics.Raycast(RayCast, out RaycastHit RayCastHitPosition, 999.0f, AimColliderLayerMask))
        {
            DebugTransform.position = RayCastHitPosition.point;
            MouseWorldPosition = RayCastHitPosition.point;
            HitTransform = RayCastHitPosition.transform;
        }

        // Enables and disables aiming camera when player aims
        if (StarterInputs.Aim) 
        {
            AimingCamera.gameObject.SetActive(true);
            TPC.SetSensitivity(AimingSensitivity);
            TPC.SetRotateOnMove(false);

            // Get rotation of where player is aiming
            Vector3 WorldAimTraget = MouseWorldPosition;
            WorldAimTraget.y = transform.position.y;
            Vector3 AimDirection = (WorldAimTraget - transform.position).normalized;

            //Rotates player in aim direction (Lerp for smooth rotation)
            transform.forward = Vector3.Lerp(transform.forward, AimDirection, Time.deltaTime * 20.0f);
        }

        else 
        {
            AimingCamera.gameObject.SetActive(false);
            TPC.SetSensitivity(DefaultSensitivity);
            TPC.SetRotateOnMove(true);
        }

        if (StarterInputs.Shoot) 
        {
            if(HitTransform != null) 
            {
                if(HitTransform.GetComponent<BulletTarget>() != null) 
                {
                    // Hit target
                    Instantiate(VFXHitGreen, DebugTransform.position, Quaternion.identity);
                }

                else 
                {
                    // Hit soemthing else
                    Instantiate(VFXHitRed, DebugTransform.position, Quaternion.identity);
                }
            }

            StarterInputs.Shoot = false;

        }
        
    }
}
