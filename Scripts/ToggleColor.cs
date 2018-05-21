using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleColor : MonoBehaviour {

    public BoolVariable toggleState;
    public Color OnColor;
    public Color OffColor;
    private Renderer _renderer;
	// Use this for initialization
	void Start () {
        _renderer = GetComponent<Renderer>();
        
        if (toggleState == null)
        {
            ToggleSwitch ts = GetComponent<ToggleSwitch>();
            if (ts != null)
                toggleState = ts.toggleState;
            ToggleMovingPlatform tmp = GetComponent<ToggleMovingPlatform>();
            if (tmp != null)
                toggleState = tmp.toggleState;
        }
        if (toggleState == null)
            return;
        if (toggleState.RuntimeValue)
            _renderer.material.color = OnColor;
        else
            _renderer.material.color = OffColor;
	}
	
	// Update is called once per frame
	void Update () {
        if (toggleState == null)
            return;
        if (toggleState.RuntimeValue)
            _renderer.material.color = OnColor;
        else
            _renderer.material.color = OffColor;
    }
}
