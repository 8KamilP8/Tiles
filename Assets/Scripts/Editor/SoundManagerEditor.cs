using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SoundManager))]
[CanEditMultipleObjects]
public class SoundManagerEditor : Editor {

    SerializedProperty clips;

    void OnEnable() {
        clips = serializedObject.FindProperty("clipDataBase");
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Number of types: ");
        clips.arraySize = EditorGUILayout.IntField(clips.arraySize);
        EditorGUILayout.EndHorizontal();
        for (int i = 0; i < clips.arraySize; i++) {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(clips.GetArrayElementAtIndex(i), new GUIContent(((SoundEffect)i).ToString()));
            EditorGUILayout.EndHorizontal();
        }
        serializedObject.ApplyModifiedProperties();
    }
}