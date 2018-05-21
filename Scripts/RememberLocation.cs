using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberLocation : MonoBehaviour {
    public SaveObject saveObject;
    public TransformVariable transformVariable;
    public vp_SpawnPoint spawnPoint;
    private bool loaded = false;


	// Use this for initialization
	void Awake () {
        if (transformVariable == null)
            return;
        if (!transformVariable.loaded)
            transformVariable.OnAfterDeserialize();

        if (saveObject != null)
            saveObject.LoadData();

        if (spawnPoint == null)
        {
            transform.position = transformVariable.RuntimePosition;
            transform.Rotate(transformVariable.RuntimeRotation);
            transform.localScale = transformVariable.RuntimeScale;
        }
        else
        {
            spawnPoint.transform.position = transformVariable.RuntimePosition;
            spawnPoint.transform.Rotate(transformVariable.RuntimeRotation);
            spawnPoint.transform.localScale = transformVariable.RuntimeScale;
            vp_PlayerRespawner playerRespawn = GetComponent<vp_PlayerRespawner>();
            //playerRespawn.Respawn();
        }
        loaded = true;
    }
    private void OnDisable()
    {
        if (saveObject != null)
            saveObject.SaveData();
    }

    // Update is called once per frame
    void Update () {
        //if (transformVariable == null)
            //return;
        //transformVariable.RuntimePosition = transform.position;
        //transformVariable.RuntimeRotation = transform.rotation.eulerAngles;
        //transformVariable.RuntimeScale = transform.localScale;
	}
}
