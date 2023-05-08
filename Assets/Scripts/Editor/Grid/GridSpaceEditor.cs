using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;


[CustomEditor(typeof(GridSpace))]
public class GridSpaceEditor : Editor {

    public override void OnInspectorGUI() {
        
        base.OnInspectorGUI();
        
        EditorGUILayout.Space(15);

        GridSpace gridSpace = (GridSpace) target;

        if(GUILayout.Button("Accessible?")) {
            Debug.Log(gridSpace.IsAccessible());
        }
    }
}