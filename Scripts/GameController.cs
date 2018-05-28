using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {
    public static GameController gameController;

    public SaveObject gameSave;
    public SaveObject prefSave;
    public ZoneManager zoneManager;
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
        Debug.Log("GameController::NewGame");
        gameSave.clearSaveData();
        StartGame();
    }
    public void StartGame()
    {
        Debug.Log("GameController::Start");
        LoadGame();
        zoneManager.Unload(menuScene);
        zoneManager.SetZone(zoneManager.currentZone.RuntimeValue,true);
        zoneManager.Load(playerScene);
        Camera.main.GetComponent<AudioListener>().enabled = false;
    }
    public void QuitGame()
    {
        SaveGame();
        SceneManager.LoadScene(menuScene);
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
        Debug.Log("GameController::OnSceneLoaded("+scene.name + ": " + mode.ToString()+")");
        if(!loadedScenes.ContainsKey(scene.name))
            loadedScenes.Add(scene.name, true);
    }
    private void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("GameController::OnSceneUnLoaded(" + scene.name + ": UNLOADED)");
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
