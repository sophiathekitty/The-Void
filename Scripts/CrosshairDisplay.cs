using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrosshairDisplay : MonoBehaviour {
    public Image image;
    public TextMeshProUGUI header;
    public TextMeshProUGUI body;

    public CrosshairCursor[] cursors;


    public void SetCursor(string cursor, string target, string button = "left click")
    {
        foreach (CrosshairCursor chc in cursors)
            if (chc.name == cursor)
                SetCursor(chc);

    }
    public void SetCursor(CrosshairCursor cursor)
    {
        image.sprite = cursor.sprite;
        header.SetText(cursor.target);
        body.SetText(cursor.UseText);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
