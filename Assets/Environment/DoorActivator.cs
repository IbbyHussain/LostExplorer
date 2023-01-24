using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivator : MonoBehaviour
{
    // If the door is actiavted by a turret death or pressure plate
    public bool IsTurretActivated = true;

    public TurretAI Turret;

    public GameObject Door;

    // Where the door will be when its opened
    public Transform OpenDoorTransform;

    void ShouldActivateDoor() 
    {
        // Activate door when turret is killed
        if (IsTurretActivated) 
        {
            if(Turret.TurretHealth <= 0.0f) 
            {
                // Open door by changing its transfrom
                Door.transform.position = OpenDoorTransform.position;
            }
        }
    }

    void Update()
    {
        ShouldActivateDoor();
    }
}
