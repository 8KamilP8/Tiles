using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BoardDisplay))]
public class BoardDisplayEditor : Editor {

   

    private void OnSceneGUI() {

        //Getting properties
        int columns = serializedObject.FindProperty("columns").intValue;
        int rows = serializedObject.FindProperty("rows").intValue;
        float scale = serializedObject.FindProperty("scale").floatValue;
        float baseScale = serializedObject.FindProperty("baseScale").floatValue;
        var script = (BoardDisplay)target;

        //Draw Gizmos:
        Vector2 origin = script.GetComponent<RectTransform>().position;
        float squareLength = scale * baseScale;

        float halfWidth = squareLength * columns / 2f;
        float halfHeight = squareLength * rows / 2f;


        Vector2 a0 = origin + new Vector2(-halfWidth, +halfHeight);
        Vector2 a1 = origin + new Vector2(+halfWidth, +halfHeight);
        Vector2 a2 = origin + new Vector2(+halfWidth, -halfHeight);
        Vector2 a3 = origin + new Vector2(-halfWidth, -halfHeight);

        Handles.DrawLine(a0, a1, 3f);
        Handles.DrawLine(a1, a2, 3f);
        Handles.DrawLine(a2, a3, 3f);
        Handles.DrawLine(a3, a0, 3f);

        for (int i = 1; i < columns; i++) {
            Vector2 offset = new Vector2(i * squareLength, 0f);
            Handles.DrawLine(a0 + offset, a3 + offset, 1f);
        }
        for (int i = 1; i < rows; i++) {
            Vector2 offset = new Vector2(0f, i * squareLength);
            Handles.DrawLine(a3 + offset, a2 + offset, 1f);
        }
    }
}
