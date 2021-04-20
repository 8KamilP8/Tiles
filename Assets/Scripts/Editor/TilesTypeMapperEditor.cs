using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TilesTypeMapper))]
[CanEditMultipleObjects]
public class TilesTypeMapperEditor : Editor {

    SerializedProperty sprites;

    void OnEnable() {
        sprites = serializedObject.FindProperty("sprites");
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Number of types: ");
        sprites.arraySize = EditorGUILayout.IntField(sprites.arraySize);
        EditorGUILayout.EndHorizontal();
        for (int i = 0; i < sprites.arraySize; i++) {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(sprites.GetArrayElementAtIndex(i), new GUIContent(((TileType)i).ToString()));
            EditorGUILayout.EndHorizontal();
        }
        serializedObject.ApplyModifiedProperties();
    }
}
