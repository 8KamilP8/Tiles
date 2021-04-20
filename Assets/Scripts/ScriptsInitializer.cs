using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsInitializer : MonoBehaviour
{

    private IInitializable[] scripts;

    void Start() {
        foreach (IInitializable initializable in scripts) {
            System.Type[] types = initializable.InitArgumentTypes();

        }
        
    }
    
}
