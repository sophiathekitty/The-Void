using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour {

    public SaveObject saveObject;
    public AudioMixer audioMixer;
    public VolControl[] channels;

	// Use this for initialization
	void Start () {
        
	}
    private void OnEnable()
    {
        if(saveObject != null)
            saveObject.LoadData();
    }
    private void OnDisable()
    {
        if(saveObject != null)
            saveObject.SaveData();
    }

    // Update is called once per frame
    void Update () {
		foreach(VolControl vol in channels)
            if(vol.variable != null)
                audioMixer.SetFloat(vol.name, vol.variable.RuntimeValue);
    }
    [System.Serializable]
    public class VolControl
    {
        public string name;
        public FloatVariable variable;
    }
}
