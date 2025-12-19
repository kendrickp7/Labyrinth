using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour {
    public AIState state;
    public FSM()
    {
        state = AIState.Idle;
    }

    public void Update()
    {
        switch (state)
        {
            
            case AIState.Idle:
                break;
            case AIState.Chase:
                break;
            case AIState.Attack:
                break;
            case AIState.Run:
                break;
            default:
                state = AIState.Idle;
                break;
        }
    }
    public enum AIState
    {
        Idle,
        Chase,
        Attack,
        Run
    }

}
