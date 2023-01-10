using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;


public class TPS_Controller : MonoBehaviour
{
    [SerializeField]  private CinemachineVirtualCamera AimingCamera;

    private StarterAssetsInputs StarterInputs;

    // Get starter inputs
    private void Awake()
    {
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
        }

        else 
        {
            AimingCamera.gameObject.SetActive(false);
        }
    }
}
