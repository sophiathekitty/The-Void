using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(vp_MovingPlatform))]
public class ToggleMovingPlatform : MonoBehaviour {
    public BoolVariable toggleState;
    private vp_MovingPlatform platform;
    private bool lastState;
    void Start()
    {
        platform = GetComponent<vp_MovingPlatform>();
        if (toggleState == null)
            throw new MissingReferenceException("Missing ToggleState Reference");
        if (toggleState.RuntimeValue)
            platform.GoTo(1);
        lastState = toggleState.RuntimeValue;
    }
    void Update()
    {
        if (toggleState == null)
            throw new MissingReferenceException("Missing ToggleState Reference");
        if (lastState == toggleState.RuntimeValue)
            return;
        if (toggleState.RuntimeValue)
            platform.GoTo(1);
        else
            platform.GoTo(0);
        lastState = toggleState.RuntimeValue;
    }
}
