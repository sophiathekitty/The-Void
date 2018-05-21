using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntSwitch : MonoBehaviour {

    public enum SwitchMode {Loop, PingPong}
    public SwitchMode switchMode;
    public IntVariable State;
    public int Max;
    private int index = 0;
    private int step = 1;

    private int StateValue
    {
        get
        {
            if (State == null)
                return 0;
            return State.RuntimeValue;
        }
        set
        {
            if(State != null)
                State.RuntimeValue = value;
        }
    }

    public void Next()
    {
        index = StateValue;
        index += step;
        if (index > Max)
            if (switchMode == SwitchMode.Loop)
                index = 0;
            else
            {
                index = Max - 1;
                step = -1;
            }
        if(index < 0)
        {
            index = 1;
            step = 1;
        }
        StateValue = index;
    }
    public void GoTo(int i)
    {
        index = i;
        if (index > Max)
            index = Max;
        else if (index < 0)
            index = 0;
        StateValue = index;
    }
}
