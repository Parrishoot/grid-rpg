using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(TurnManager))]
public class TurnManagerEditor : Editor
{
    public override void OnInspectorGUI() {
        
        base.OnInspectorGUI();
        
        EditorGUILayout.Space(15);

        TurnManager turnManager = (TurnManager) target;

        if(GUILayout.Button("Start Round")) {
            turnManager.StartRound();
        }
    }
}
