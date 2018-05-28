using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AchievementCondition : ScriptableObject {
    public abstract float Completed();
    public abstract int Steps();
}
