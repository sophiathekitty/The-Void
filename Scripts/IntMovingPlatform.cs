using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(vp_MovingPlatform))]
public class IntMovingPlatform : MonoBehaviour {
    public IntVariable State;
    private vp_MovingPlatform platform;
    private int index;
    void Start()
    {
        platform = GetComponent<vp_MovingPlatform>();
        if (State == null)
            throw new MissingReferenceException("Missing ToggleState Reference");
        platform.GoTo(State.RuntimeValue);
        index = State.RuntimeValue;
    }
    void Update()
    {
        if (State == null)
            throw new MissingReferenceException("Missing ToggleState Reference");
        if (index == State.RuntimeValue)
            return;
        platform.GoTo(State.RuntimeValue);
        index = State.RuntimeValue;
    }
}
