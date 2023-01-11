using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipFireState : AimBaseState
{

    // virtual function declarations
    public override void EnterState(AimStateManager AimManager) 
    {
        AimManager.Anim.SetBool("Aiming", false);
    }

    public override void UpdateState(AimStateManager AimManager) 
    {
        if (Input.GetKey(KeyCode.Mouse1)) 
        {
            AimManager.SwitchState(AimManager.Aim);
        }
    }
}
