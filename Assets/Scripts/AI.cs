using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
  
    void Start()
    {
        var fsm = new FSM();
        fsm.Update();
    }

    
    void Update()
    {
        
    }
}
