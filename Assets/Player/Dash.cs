using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
    public float DashSpeed;
    public float TimeToDash;
    public float DashDrain = 10.0f; // Amount of stamina dash takes

    public InputAction DashInputAction;

    // custom controller reference
    TPS_Controller TPSController;

    ThirdPersonController PlayerController;

    private void OnEnable()
    {
        DashInputAction.Enable();
        DashInputAction.performed += OnDash;
    }

    private void OnDisable()
    {
        DashInputAction.Disable();
        DashInputAction.performed -= OnDash;
    }

    public void OnDash(InputAction.CallbackContext ctx)
    {
        // only dash if player has enough stamina
        if(TPSController.CurrentStamina >= DashDrain) 
        {
            TPSController.CurrentStamina -= DashDrain;

            StartCoroutine(DashRoutine());

            // Update UI
            TPSController.STBarScript.SetCurrentStamina(TPSController.CurrentStamina); 
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        // Instantiate controller references
        PlayerController = GetComponent<ThirdPersonController>();
        TPSController = GetComponent<TPS_Controller>();
    }


    // Dash
    IEnumerator DashRoutine()
    {
        float StartTime = Time.time;

        while (Time.time < StartTime + TimeToDash)
        {
            // Moes player in direction they are facing
            transform.Translate(Vector3.forward * TimeToDash);

            yield return null;
        }
    }
}
