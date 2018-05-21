using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitch : MonoBehaviour {
    public BoolVariable toggleState;
    public void Toggle()
    {
        toggleState.RuntimeValue = !toggleState.RuntimeValue;
    }
    public void TurnOn()
    {
        toggleState.RuntimeValue = true;
    }
    public void TurnOff()
    {
        toggleState.RuntimeValue = false;
    }
}
