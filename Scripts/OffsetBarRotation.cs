using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffsetBarRotation : MonoBehaviour {

    public float offset;
    public Image barMain;
    public Image[] bars;

	// Use this for initialization
	void Start () {
		
	}
	public float BarDeg
    {
        get
        {
            return barMain.fillAmount * 360;
        }
    }
    public float OffsetDeg
    {
        get
        {
            if (float.IsNaN(BarDeg))
                return 0;
            return offset - (BarDeg/2);
        }
    }
	// Update is called once per frame
	void Update () {
        float deg = OffsetDeg;
        if (float.IsNaN(deg))
           deg = 0;
        Debug.Log(deg);
        barMain.rectTransform.localEulerAngles = new Vector3(0, 0, deg);
        foreach (Image bar in bars)
            bar.rectTransform.localEulerAngles = new Vector3(0, 0, deg);
    }
}
