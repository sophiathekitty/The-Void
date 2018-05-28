using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class ZoneManager : ScriptableObject {
    public Zone defaultZone;
    public StringVariable currentZone;
    public int loadDistance = 3;
    public List<Zone> zones = new List<Zone>();
    public Zone currentZoneInfo
    {
        get
        {
            if (currentZone == null || zones.Count == 0)
                return null;
            foreach (Zone z in zones)
                if (z.zone == currentZone.RuntimeValue)
                    return z;
            return null;
        }
    }

    private Dictionary<string, bool> loadedScenes = new Dictionary<string, bool>();


    public void SetZone(string scene, bool firstLoad = false)
    {
        //Debug.Log("ZoneManager::SetZone(" + scene + ")");
        if (currentZone.RuntimeValue == scene && !firstLoad)
            return;
        currentZone.RuntimeValue = scene;
        foreach (Zone zone in zones)
        {
            if (zone.zone == scene ||
                zone.Distance(scene) < 3)
            {
                Load(zone.zone);
            }
            else
            {
                Unload(zone.zone);
            }
        }
    }
    public void Load(string scene)
    {
        if (!loadedScenes.ContainsKey(scene))
            SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
    }

    public void Unload(string scene)
    {
        if (loadedScenes.ContainsKey(scene))
            SceneManager.UnloadSceneAsync(scene);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("ZoneManager::OnSceneLoaded(" + scene.name + ": " + mode.ToString() + ")");
        if (!loadedScenes.ContainsKey(scene.name))
            loadedScenes.Add(scene.name, true);
    }
    private void OnSceneUnloaded(Scene scene)
    {
        //Debug.Log("ZoneManager::OnSceneUnLoaded(" + scene.name + ": UNLOADED)");
        if (loadedScenes.ContainsKey(scene.name))
            loadedScenes.Remove(scene.name);
    }
}
