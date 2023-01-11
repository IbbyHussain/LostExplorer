using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AimBaseState
{

    // Base functions for anim states

    public abstract void EnterState(AimStateManager AimManager);
    public abstract void UpdateState(AimStateManager AimManager);

}
