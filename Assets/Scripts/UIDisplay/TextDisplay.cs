using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public abstract class TextDisplay : MonoBehaviour {

    protected TextMeshProUGUI textMesh;
    protected TextMeshProUGUI _textMesh {
        get {
            if (textMesh is null)
                textMesh = GetComponent<TextMeshProUGUI>();
            return textMesh;
        }
    }

    
}
