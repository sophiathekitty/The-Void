using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameController))]
public class GameControllerEditor : Editor {
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GameController gc = (GameController)target;

        if(GUILayout.Button("Find Zones"))
        {
            string[] scenes = AssetDatabase.FindAssets("t:Scene");
            string[] zones = AssetDatabase.FindAssets("t:Zone");
            foreach(string z in zones)
            {
                Zone zz = (Zone)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(z), typeof(Zone));
                if (!gc.zones.Contains(zz))
                    gc.zones.Add(zz);

            }
            foreach (string scene in scenes)
            {
                if (AssetDatabase.GUIDToAssetPath(scene).Contains("/Zones/"))
                {
                    string[] path = AssetDatabase.GUIDToAssetPath(scene).Split('/');
                    string zone_path = "";
                    for(int i = 0; i < path.Length - 1; i++)
                    {
                        zone_path += path[i]+"/";
                    }
                    string zone = path[path.Length - 1].Replace(".unity", "");
                    // now see if we can find the zones
                    bool exists = false;
                    foreach(Zone z in gc.zones)
                    {
                        if (z.name == zone)
                            exists = true;
                    }
                    if (!exists)
                    {
                        Zone nZone = ScriptableObject.CreateInstance<Zone>();
                        nZone.zone = zone;
                        nZone.name = zone;
                        AssetDatabase.CreateAsset(nZone,zone_path+zone+".asset");
                        if(!gc.zones.Contains(nZone))
                            gc.zones.Add(nZone);
                    }

                }
            }
        }
    }
}
