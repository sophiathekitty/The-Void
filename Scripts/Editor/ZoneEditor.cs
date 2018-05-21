using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Zone))]
public class ZoneEditor : Editor {

    private static string icon = "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";
    private static string linked = "iVBORw0KGgoAAAANSUhEUgAAABQAAAAUCAYAAACNiR0NAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAIGNIUk0AAHolAACAgwAA+f8AAIDpAAB1MAAA6mAAADqYAAAXb5JfxUYAAANMSURBVHjarNVPTNtlHMfx9/Nrf7/2VxgtxbZoWya0BQaUOQRlU8imC4cdNNkSop6MJy968m5iYjwYT/65LMZsIRwIiTEks70QZ9qmkEEMLQXq+LtBGTAopAVsYY8naxomiQnP7bm8nu/38/wTUkrOchgBhBBnokophfGfSSgUYnR0lPn5+f+FbG1tsb29TSKR+LdCAJfLRWd3JysdK8S74iw1LAHgzXjpme7hcvoyQooTYDKZJBqNlrcMkM/nCRvCDN8c5kg9wjPhQZMaK6+sMHh9EMWt0L/YjyKVMnBzc/NkhgBzc3OM9I5wrBxzcfgiTaNN7Gf3sb9uJ/VRioELAxQocO3JNbx5739GUFpuYWGBDf8GzkUnvTO9hL4KEf4pjDgStP3Qhp7TGbowxKBv8NRMS2A2mwVANajs7O1wqB5SNBV5fPMxjnUHXd910T3aTe1qLbcDt0nZUqeDQghqZ2vJ1GWY7pqm/fN23BNuMvUZJj+bxK/46f61m+JSkdDLIWKO2OlgdXU1/l/8GA+MTN2agleh/Zt2vJNeMu4M4Q/D7J3fI5vJIp9JRvwjDNUPIRX5fLChoQHfjI+WH1swFAw8eO8Buzd2af26Fc8fHladq9y7dQ/zEzPB74No+xp3W+4y1jlWhpbAQCBAc3Mz9b/X03anDdNfJmgE9wtuLn1xibqxOtZfXGfikwmqNqtovtOMdqgR6Ymw+/ZuCRRSSoQQcnZ2lpmZGWKxGOnDNOvvruMxeigWi+SWcuhhndSnKRZ7FrFuWHHcd6CYFNLvpKmMVZJ7I1d+9QwGAzU1Nfh8PsyrZgKhAONvjRPpiyAVyRXLFRq/bST7UpYd3w5am4Y9agfg2Hx88mADGI1GnE4nqqqyvLyM7Tcbwc0gyQ+SxPvjtIpWrJNWlGcK5zLnWLu6BoAlbuGAg5OgEAJN07DZbBQKBXJ/5lB+ViAHiY8TTL0/hTfixZ6ws/baGnlPHm/Eiz6g85Sn5aCqqphMJiwWC7quY7FYqKqqoqKiAu2+hjFv5GH/Qx69+ahUQDAWpG+8j6iMPr9lg8GA2WwGQNd1KisrS7BrxUXHlx1IKVEUBYfDQVNTE1a/FfWqSjweL9/ls3pgxVl/AX8PAIoWOvpQuzV+AAAAAElFTkSuQmCC";
    private static string unlinked = "iVBORw0KGgoAAAANSUhEUgAAABQAAAAUCAYAAACNiR0NAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAIGNIUk0AAHolAACAgwAA+f8AAIDpAAB1MAAA6mAAADqYAAAXb5JfxUYAAAOCSURBVHjatJTLTxtXGMV/49cMg20eYyYGYksGxwWb5w5VoCxC0xSJEimNsmDdqKvuov4JWWeTiLChaoMiUKOQCqWJ0qywEFWAtDOJk1YQSMGB+FEDBoxjz3QRqHip3aR3c3WkTz+dc6++I5imyYc8wu79QaimaQq2PTE2NsbsyAhN0Sg9S0uUFApoHg/jp04xXV2NKQjHQpLJJOl0Gk3TALDtubTMzfHlw4fUJBIsulxkJYnGVIrmyUkm+vrQzpzBsFiOAHVdJxqN/qNtQAmAcusWNYkEU7W1/NDczArwcSJB/4sXdI6NUVlaynJPD/ny8gPARCJxQNuACoBWTSPlcqH19XGirg5zZYWfFxbYsFr5StcJDw/jyGZ5efnyv76jDXADiIUCW4qCNxRC8fvxeDxIksSMzcaA3c4n6TTb797ReuUK6sICa8Egv1y9eizQAhCrqSH85g2BqSkWgkEqKioIhUKIosjrqiq+3dyk+8kTOmIxAMRDUfcDNwHGGxupTyYJ3bmDKcu8Pn+esrIyAoEAVquVltu3+VTTWJUktPp6vKqKPZM5ArQAfwH8GQwy1NYGxSLhoSH8d+9iFgpsbmzQOTLCZ5pGWpL4rq2NkkKBxokJqiYnjwVmAcJNTUTr6xlsacEQBMqmp1l/+ZLwjRt0PX1KWpYZPXuW3yMR/pBlKBZpuXmT1pkZLIciFwEikQipVIrp7W1+FEXKZJnA8DCdus5bp5NHvb0IXV2ciMcZDwQwi0X6YzF679/nUW0tv+4DAqCqKuFwmHw+z4OqKr4ZHSWQTrPidPLgwgWs3d14S0sRRZFcLsc9w8ABXHz2jK9XV7m+L/J7ss2Gqqqoqkoul6N6bY11UWSmvZ32eJyQruNwOFAUhYaGBurq6rjn86GXl/NRLncg8vuWEATsdjsOhwPDMPhNUdhyuXBmMrRoGrmpKXTDYPX0aRRFwe/3k4zHKR5qK9vhX5IkCZ/Px/eXLmEYBtbFRd6aJl/oOpGBAaxbWyx1dCBms3z+/DnNmQxzDgfk8weBdrsdURTxer04nU52dnZYX19nXpYZEUV27Hb6Z2dpHhzE8/gxjdksgeVlioLA9ZMnYX7+qEOr1Yrb7cbtdmOaJvl8nsrKSmRZ5idRJClJXIzF8O1uyyuPh+lz5zAVBa5d+38LVviP2b0SqQTkXQObu1u2ART2Bv8eACEFUYkgHVbTAAAAAElFTkSuQmCC";
    public Zone thisZone { get { return (Zone)target; } }

    public override void OnInspectorGUI()
    {
        if (thisZone != null && thisZone.display_name == "" && thisZone.name != "")
            thisZone.display_name = thisZone.name;
        thisZone.display_name = EditorGUILayout.TextField("Display Name", this.thisZone.display_name);
        GUILayout.BeginHorizontal(GUILayout.Height(64));
        thisZone.sprite = (Sprite)EditorGUILayout.ObjectField("", thisZone.sprite, typeof(Sprite), true,GUILayout.Width(64),GUILayout.Height(64));
        thisZone.description = EditorGUILayout.TextArea(thisZone.description, GUILayout.ExpandHeight(true));
        GUILayout.EndHorizontal();

        GUIStyle style = new GUIStyle();
        style.normal.background = null;
        style.hover.background = null;
        style.active.background = null;
        //base.OnInspectorGUI();
        //thisZone.zone = EditorGUILayout.TextField(thisZone.zone);
        GUILayout.BeginHorizontal();
        GUILayout.Space(20);
        GUILayout.Label("Neighbors:", GUILayout.Width(150));
        GUILayout.Label("Distance:");
        GUILayout.EndHorizontal();
        string[] zones = AssetDatabase.FindAssets("t:Zone");
        foreach (string z in zones)
        {

            Zone zz = (Zone)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(z), typeof(Zone));
            if(zz != thisZone)
            {

                GUILayout.BeginHorizontal();
                if (thisZone.neighbor.Contains(zz))
                {
                    if (GUILayout.Button(Base64ToTexture(linked),style, GUILayout.Width(20)))
                    {
                        thisZone.neighbor.Remove(zz);
                        if (zz.neighbor.Contains(thisZone))
                            zz.neighbor.Remove(thisZone);
                    }
                }
                else
                {
                    if (GUILayout.Button(Base64ToTexture(unlinked), style, GUILayout.Width(20)))
                    {
                        thisZone.neighbor.Add(zz);
                        if (!zz.neighbor.Contains(thisZone))
                            zz.neighbor.Add(thisZone);
                    }

                }
                GUILayout.Label(zz.name, GUILayout.Width(150));
                if(thisZone.neighbor.Count > 0)
                {
                    int d = zz.Distance(thisZone.zone);
                    if (d != 10)
                        GUILayout.Label(d.ToString());
                }

                GUILayout.EndHorizontal();
            }
        }
        ReloadPreviewInstances();
    }
    public override bool HasPreviewGUI()
    {
        return true;// base.HasPreviewGUI();
    }

    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        if (thisZone.sprite != null)
            return PreviewUtil.RenderStaticPreview(thisZone.sprite, width, height);
        return Base64ToTexture(icon);
    }

    private static Texture2D Base64ToTexture(string base64)
    {
        Texture2D t = new Texture2D(1, 1)
        {
            hideFlags = HideFlags.HideAndDontSave
        };
        t.LoadImage(System.Convert.FromBase64String(base64));
        return t;
    }

}
