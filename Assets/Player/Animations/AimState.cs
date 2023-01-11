using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimState : AimBaseState
{
    // virtual function declarations
    public override void EnterState(AimStateManager AimManager)
    {
        AimManager.Anim.SetBool("Aiming", true);
    }

    public override void UpdateState(AimStateManager AimManager)
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            AimManager.SwitchState(AimManager.Aim);
        }
    }
}
