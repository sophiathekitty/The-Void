using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {
    public static GameController gameController;

    public SaveObject gameSave;
    public SaveObject prefSave;
    public StringVariable zoneName;
    public List<Zone> zones;
    public string playerScene = "player";
    public string menuScene = "menu";
    private Dictionary<string, bool> loadedScenes = new Dictionary<string, bool>();

    public bool WorldLoaded;
    public bool PlayerLoaded
    {
        get
        {
            return (GameObject.FindGameObjectWithTag("Player") != null);
        }
    }
    public bool MenuLoaded;

    public void NewGame()
    {
        gameSave.clearSaveData();
        StartGame();
    }
    public void StartGame()
    {
        LoadGame();
        Unload(menuScene);
        SetZone(zoneName.RuntimeValue);
        Load(playerScene);
        Camera.main.GetComponent<AudioListener>().enabled = false;
    }
    public void QuitGame()
    {
        SaveGame();
        SceneManager.LoadScene(menuScene);
    }
    public void Load(string scene)
    {
        Debug.Log("load: "+scene);
        if(!loadedScenes.ContainsKey(scene))
            SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
    }
    public void Unload(string scene)
    {
        Debug.Log("unload: "+scene);
        if (loadedScenes.ContainsKey(scene))
            SceneManager.UnloadSceneAsync(scene);
    }

    public void SetZone(string scene)
    {
        zoneName.RuntimeValue = scene;
        foreach (Zone zone in zones)
        {
            if(zone.zone == scene ||
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

    // Use this for initialization
    void Start() {
        if (gameController == null)
        {
            GameObject.DontDestroyOnLoad(gameObject);
            gameController = this;
        }
        else
            GameObject.Destroy(gameObject);
    }
    public void LoadGame()
    {
        gameSave.LoadData();
    }
    public void SaveGame()
    {
        gameSave.SaveData();
        prefSave.SaveData();
    }
    // load
    private void Awake()
    {
        prefSave.LoadData();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    // save
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SaveGame();
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    // scene loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(scene.name + ": " + mode.ToString());
        if(!loadedScenes.ContainsKey(scene.name))
            loadedScenes.Add(scene.name, true);
    }
    private void OnSceneUnloaded(Scene scene)
    {
        Debug.Log(scene.name + ": unloaded");
        if (loadedScenes.ContainsKey(scene.name))
            loadedScenes.Remove(scene.name);
    }
    // Update is called once per frame
    void Update() {

    }

    [System.Serializable]
    public class ZoneScenes
    {
        public string name;
        public string[] neighbors;
    }
}
