using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBar : MonoBehaviour {

    public Inventory inventory;
    public enum Axes {X,Y,Z}
    public Axes axes;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (axes)
        {
            case Axes.X:
                transform.localScale = new Vector3(inventory.FillPercent(), transform.localScale.y, transform.localScale.z);
                break;
            case Axes.Y:
                transform.localScale = new Vector3(transform.localScale.x, inventory.FillPercent(), transform.localScale.z);
                break;
            case Axes.Z:
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, inventory.FillPercent());
                break;
        }
    }
}
