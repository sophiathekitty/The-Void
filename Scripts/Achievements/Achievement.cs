using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Achievement : ScriptableObject {
    public string display_name;
    public Sprite icon;
    public int points;
    public string description;
    public AchievementCondition[] conditions;
}
