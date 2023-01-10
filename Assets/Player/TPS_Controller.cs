using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;


public class TPS_Controller : MonoBehaviour
{
    [SerializeField]  private CinemachineVirtualCamera AimingCamera;

    // Sensitivity values 
    [SerializeField] private float DefaultSensitivity;
    [SerializeField] private float AimingSensitivity;

    private ThirdPersonController TPC;
    private StarterAssetsInputs StarterInputs;

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
    
    // Update Function
    void Update()
    {
        // Enables and disables aiming camera when player aims
        if (StarterInputs.Aim) 
        {
            AimingCamera.gameObject.SetActive(true);
            TPC.SetSensitivity(AimingSensitivity);
        }

        else 
        {
            AimingCamera.gameObject.SetActive(false);
            TPC.SetSensitivity(DefaultSensitivity);
        }
    }
}
