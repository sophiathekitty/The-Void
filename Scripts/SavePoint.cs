using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour {
    public SaveObject saveObject;
    public TransformVariable transformVariable;
    public vp_SpawnPoint spawnPoint;
    public Color color = Color.green;
    public Zone zone;

    private Vector3 gizmoPos = new Vector3(0f, 1f, 0f);
    private Vector3 gizmoSize = new Vector3(1f, 2f, 1f);

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            transformVariable.RuntimePosition = transform.position;
            transformVariable.RuntimeRotation = transform.rotation.eulerAngles;
            transformVariable.RuntimeScale = transform.localScale;

            if (spawnPoint == null)
            {
                GameObject gameObject = GameObject.FindGameObjectWithTag("PlayerSpawn");
                if (gameObject == null)
                    return;
                spawnPoint = gameObject.GetComponent<vp_SpawnPoint>();
                if (spawnPoint == null)
                    return;
            }
            spawnPoint.transform.position = transform.position;
            spawnPoint.transform.Rotate(transform.rotation.eulerAngles);
            saveObject.SaveData();
            if (zone != null && GameController.gameController != null)
                GameController.gameController.SetZone(zone.name);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnDrawGizmos()
    {

        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = new Color(color.r, color.g, color.b, 0.5f);
        Gizmos.DrawCube(gizmoPos, gizmoSize);
        Gizmos.color = new Color(color.r, color.g, color.b, 0.75f);
        Gizmos.DrawLine(Vector3.zero, Vector3.forward * 2f);
        Gizmos.DrawLine(Vector3.forward * 2f, new Vector3(1f,0f,1f));
        Gizmos.DrawLine(Vector3.forward * 2f, new Vector3(-1f, 0f, 1f));

    }


    /// <summary>
    /// 
    /// </summary>
    public void OnDrawGizmosSelected()
    {

        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = new Color(color.r,color.g,color.b,0.75f);
        Gizmos.DrawCube(gizmoPos, gizmoSize);
        Gizmos.color = new Color(color.r, color.g, color.b, 1f);
        Gizmos.DrawLine(Vector3.zero, Vector3.forward * 2f);
        Gizmos.DrawLine(Vector3.forward * 2f, new Vector3(1f, 0f, 1f));
        Gizmos.DrawLine(Vector3.forward * 2f, new Vector3(-1f, 0f, 1f));
    }



}
