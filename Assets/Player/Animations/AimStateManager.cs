using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AimStateManager : MonoBehaviour
{
    AimBaseState CurrentState;

    // Instantiate
    public HipFireState Hip = new HipFireState();
    public AimState Aim = new AimState();

    [SerializeField] float MouseSense = 1;
    [SerializeField] Transform CamFollowPos;
    float XAxis, YAxis;

    [HideInInspector] public Animator Anim;

    void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        SwitchState(Hip);


    }

    void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void SwitchState(AimBaseState State) 
    {
        CurrentState = State;
        CurrentState.EnterState(this);
    }
}
