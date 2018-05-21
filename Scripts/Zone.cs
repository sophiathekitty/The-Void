using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Zone")]
public class Zone : ScriptableObject {
    public string display_name;
    public string zone;
    public Sprite sprite;
    public string description;
    public List<Zone> neighbor = new List<Zone>();
    //private Dictionary<string, int> distance_cache = new Dictionary<string, int>();

    public int Distance(string scene, int d = 0, bool useCache = true)
    {
        //if (distance_cache.ContainsKey(scene) && useCache)
            //return distance_cache[scene];

        bool rLevel = (d == 0);

        if (zone == scene || d > 3)
            return d;
        int minD = 10;
        foreach (Zone z in neighbor)
        {
            if (z.zone == scene)
            {
                //if (rLevel)
                //    distance_cache[scene] = d + 1;
                //else
                //    distance_cache[scene] = 1;
                return d + 1;
            }
            else
            {
                int dd = z.Distance(scene, d + 1,useCache);
                if (dd < minD)
                    minD = dd;
            }
        }
        //distance_cache[scene] = minD;
        return minD;
    }

}
