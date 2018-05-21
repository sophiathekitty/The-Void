using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class ZoneManager : ScriptableObject {
    public Zone defaultZone;
    public StringVariable currentZone;
    public List<Zone> zones;


}
