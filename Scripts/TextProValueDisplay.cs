using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextProValueDisplay : MonoBehaviour {
    public AttributeVariable variable;
    private TextMeshProUGUI text;
    public int round;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (text != null && variable != null)
            text.SetText(RoundValue(variable.RuntimeValue).ToString());
    }

    private float RoundValue(float v)
    {
        if (round == 0)
            return Mathf.Round(v);
        return Mathf.Round(v * (10 * round)) / (10 * round);
    }
}
