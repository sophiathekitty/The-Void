using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingDisplay : MonoBehaviour {

    public RectTransform[] rings;
    public int mainRing;
    public float mainRadius = 50;
    public float childRadius = 25;
    public float orbit = 50;
    public float orbitStep = 45;
    public float orbitCenterOffset = 200;

    public int ChildCount
    {
        get
        {
            int c = 0;
            foreach (RectTransform r in rings)
                if (r.gameObject.activeSelf)
                    c++;
            return c-1;
        }
    }
    public float OrbitStart
    {
        get
        {
            return orbitCenterOffset - ((orbitStep * (ChildCount-1)) / 2);
        }
    }
	// Use this for initialization
	void Start () {
        PositionRings();
    }

    // Update is called once per frame
    void Update () {
        PositionRings();
    }
    public void PositionRings()
    {
        if (mainRing < 0) mainRing = 0;
        if (mainRing > rings.Length - 1) mainRing = rings.Length - 1;
        rings[mainRing].sizeDelta = new Vector2(mainRadius * 2, mainRadius * 2);
        rings[mainRing].localPosition = new Vector3(0, 0, 0);
        rings[mainRing].gameObject.SetActive(true);

        float s = OrbitStart;
        int ia = 0;
        for (int i = 0; i < rings.Length; i++)
        {
            if (i != mainRing && rings[i].gameObject.activeSelf)
            {
                rings[i].sizeDelta = new Vector2(childRadius * 2, childRadius * 2);
                rings[i].localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (orbitStep * ia + s)) * orbit, Mathf.Sin(Mathf.Deg2Rad * (orbitStep * ia+s)) * orbit, 0);
                ia++;
            }
        }

    }
}
