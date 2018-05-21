using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(SavePoint))]
public class SavePointEditor : Editor {
    private SavePoint savePoint { get { return (SavePoint)target; } }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(savePoint.zone == null)
        {
            if(GUILayout.Button("Find Zone"))
            {
                Scene scene = savePoint.gameObject.scene;
                Debug.Log(scene.name);
                string[] zones = AssetDatabase.FindAssets("t:Zone");
                foreach (string z in zones)
                {
                    Zone zone = (Zone)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(z), typeof(Zone));
                    if (zone.zone == scene.name)
                        savePoint.zone = zone;
                }
            }
        }

        if(GUILayout.Button("Make Default Start"))
        {
            savePoint.transformVariable.InitialPosition = savePoint.transform.position;
            savePoint.transformVariable.InitialRotation = savePoint.transform.eulerAngles;
        }
    }
}
