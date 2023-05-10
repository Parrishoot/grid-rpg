using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.UI;

[CustomEditor(typeof(MultiClickableButton))]
public class MultiClickableButtonEditor : ButtonEditor
{
    SerializedProperty onMiddleClick;
    SerializedProperty onRightClick;

    protected override void OnEnable() {
        base.OnEnable();

        onMiddleClick = serializedObject.FindProperty("onMiddleClick");
        onRightClick = serializedObject.FindProperty("onRightClick");    
    }

    public override void OnInspectorGUI()
    {
        MultiClickableButton targetMyButton = (MultiClickableButton) target;

        base.OnInspectorGUI();

        EditorGUILayout.PropertyField(onMiddleClick, new GUIContent("On Middle Click"));
        EditorGUILayout.PropertyField(onRightClick, new GUIContent("On Right Click"));

        serializedObject.ApplyModifiedProperties();
    }
}
