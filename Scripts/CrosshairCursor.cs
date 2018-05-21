using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Crosshair Cursor")]
public class CrosshairCursor : ScriptableObject {
    public Sprite sprite;
    public string button = "left click";
    public string verb;
    [System.NonSerialized]
    public string target;
    public string use_text = ".b to .v .t";
    
    public string UseText
    {
        get
        {
            string txt = use_text;

            txt = txt.Replace(".b", button);
            txt = txt.Replace(".v", verb);
            txt = txt.Replace(".t", target);

            return txt;
        }
    }
}
