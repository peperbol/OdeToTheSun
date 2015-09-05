using UnityEngine;
using System.Collections;
using UnityEditor;

public class BeatSequenceEditor : EditorWindow
{
    const float checkboxWidth = 25;
    const float checkboxHeight = 25;
    const float Left = 25;
    int length;
    Vector2 scrollPosition = Vector2.zero;
    [MenuItem("Beats/Sequence Editor")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(BeatSequenceEditor), false, "Sequence Editor");
    }
    void OnEnable() {
        length = GameProgress.Sequence.data.GetLength(0);
    }
    void OnGUI()
    {
        BeatSequence b = GameProgress.Sequence;


        EditorGUI.DrawRect(new Rect(0, 0, position.width, 30), new Color(0.3f, 0.35f, 0.4f));

        float width = Left;
        if (GUI.Button(new Rect(width, 0, 50, 20), "Revert"))
        {
            b.Load(BeatSequence.Path);
        }
        width += 55;
        if (GUI.Button(new Rect(width, 0, 50, 20), "Save"))
        {

            b.Write(BeatSequence.Path);
        }
        width += 55;
        length = EditorGUI.IntField(new Rect(width, 0, 100, 20), length);
        width += 105;
        if (GUI.Button(new Rect(width, 0, 20, 20), ">"))
        {
            b.Resize(length);
        }
        width += 25;

        width = Left;

        GUILayout.Label("", GUILayout.Width(position.width), GUILayout.Height(27));
        scrollPosition = GUILayout.BeginScrollView(scrollPosition);
        float height = 5;
        for (int i = 1; i <= 8; i++)
        {
            EditorGUI.LabelField(new Rect(width, height, checkboxWidth, checkboxHeight),i+"");
            width += checkboxWidth;
        }
        EditorGUI.LabelField(new Rect(width, height, checkboxWidth, checkboxHeight), "h");
        width += checkboxWidth;
        EditorGUI.LabelField(new Rect(width, height, checkboxWidth, checkboxHeight), "r");
        width += checkboxWidth;

        height += checkboxHeight;
        for (int x = 0; x < b.data.GetLength(0); x++)
        {
            if (x % BeatSequence.MEASURELENGHT == 0)
            {
                EditorGUI.DrawRect(new Rect(0, height- 5, position.width, 1), new Color(0.3f, 0.35f, 0.4f));
            }
            width = Left;
            for (int y = 0; y < b.data.GetLength(1); y++)
            {
                b.data[x, y] = EditorGUI.Toggle(new Rect(width,height,checkboxWidth, checkboxHeight), b.data[x, y]);
                width += checkboxWidth;

            }
            height += checkboxHeight;
        }
        GUILayout.Label("", GUILayout.Width(position.width), GUILayout.Height(height - 30));
        GUILayout.EndScrollView();
    }
}
