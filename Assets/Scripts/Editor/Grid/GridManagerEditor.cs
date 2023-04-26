using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridManager))]
public class GridManagerEditor : Editor {

    private float vertPadding = 5f;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        
        EditorGUILayout.Space(15);

        GridManager gridManager = (GridManager) target;

        gridManager.gridSize = EditorGUILayout.Vector2IntField("Grid Size: ", gridManager.gridSize);

         EditorGUILayout.Space(5);

        if(GUILayout.Button("Resize Grid Matrix")) {
            ResetGridMatrix();
        }

        EditorGUILayout.Space(15);

        for (int i = 0, x = 0; x < gridManager.EnabledGridSpaceMatrix.Width; x++)
        {
            GUILayout.EndVertical();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            for (int y = 0; y < gridManager.EnabledGridSpaceMatrix.Height; y++)
            {
                gridManager.EnabledGridSpaceMatrix[x, y] = EditorGUILayout.Toggle(gridManager.EnabledGridSpaceMatrix[x,y], GUILayout.Height(15), GUILayout.Width(15));
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.BeginVertical();

            i++;
        }        

        EditorGUILayout.Space(15);

        if(GUILayout.Button("Generate Grid")) {
            gridManager.InitGrid();
        }
    }

    private void ResetGridMatrix() {

        GridManager gridManager = (GridManager) target;

        SerializableMatrix<bool> prevGridMatrix = gridManager.EnabledGridSpaceMatrix.Clone();

        gridManager.EnabledGridSpaceMatrix = new SerializableMatrix<bool>(gridManager.gridSize.x, gridManager.gridSize.y, true);

        for(int x = 0; x < Mathf.Min(prevGridMatrix.Width, gridManager.EnabledGridSpaceMatrix.Width); x++) {
            for(int y = 0; y < Mathf.Min(prevGridMatrix.Height, gridManager.EnabledGridSpaceMatrix.Height); y++) {
                gridManager.EnabledGridSpaceMatrix[x,y] = prevGridMatrix[x,y];
            }
        }
    }
}