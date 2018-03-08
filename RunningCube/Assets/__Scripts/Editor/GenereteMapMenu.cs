using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (LevelGenerator)) ]
public class GenereteMapMenu : Editor {

    public override void OnInspectorGUI()
    {
        LevelGenerator newLevel = (LevelGenerator)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Gerar"))
        {
            newLevel.GenerateMap();
        }
        if (GUILayout.Button("Limpar"))
        {
            newLevel.LevelCleaner();
        }
    }
}
