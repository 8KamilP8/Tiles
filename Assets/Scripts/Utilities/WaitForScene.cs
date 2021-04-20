using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
public class WaitForScene : MonoBehaviour
{
    SceneMarker flag;
    [SerializeField] private int sceneID;
    private void Update() {
        flag = FindObjectOfType<SceneMarker>();
        if (flag != null) {            
            if(flag.ID == sceneID) {
                Wait();
                Destroy(gameObject);
            }
        }

    }
    public void Wait() {
        MonoBehaviourMultiScene[] MMS = FindObjectsOfType<MonoBehaviourMultiScene>();
        foreach (MonoBehaviourMultiScene mms in MMS) {
            mms.OnMultiSceneStart();
        }
    }
    
}


