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

  

  private ClapWaveSequence sequence;
  public ClapWaveSequence Sequence
  {
    get
    {
      if (sequence == null)
      {
        LoadSequence();
      }
      return sequence;
    }
    set { sequence = value; }
  }

  private void  LoadSequence() {
    sequence = ClapWaveSequence.LoadSequenceFile(path, 1);
    if (sequence == null)
    {
      Debug.LogWarning("Editor can't load Sequencefile \"" + path + "\".");
      sequence = new ClapWaveSequence();
    }
    length = Sequence.Count();
  }

  string path = "sequence.txt";

  void OnGUI()
  {

    ClapWaveSequence b = Sequence;


    EditorGUI.DrawRect(new Rect(0, 0, position.width, 30), new Color(0.3f, 0.35f, 0.4f));

    float width = Left;

    path = EditorGUI.TextField(new Rect(width, 0, 100, 20), path);
    width += 105;

    if (GUI.Button(new Rect(width, 0, 50, 20), "Load"))
    {
      LoadSequence();
    }
    width += 55;
    if (GUI.Button(new Rect(width, 0, 50, 20), "Save"))
    {

      //b.Write(BeatSequence.Path);
    }
    width += 55;
    length = EditorGUI.IntField(new Rect(width, 0, 100, 20), length);
    width += 105;

    if (GUI.Button(new Rect(width, 0, 20, 20), ">"))
    {
      b.SetLength(length);
    }
    width += 25;

    width = Left;

    GUILayout.Label("", GUILayout.Width(position.width), GUILayout.Height(27));
    scrollPosition = GUILayout.BeginScrollView(scrollPosition);
    float height = 5;
    for (int i = 1; i <= 8; i++)
    {
      EditorGUI.LabelField(new Rect(width, height, checkboxWidth, checkboxHeight), i + "");
      width += checkboxWidth;
    }
    EditorGUI.LabelField(new Rect(width, height, checkboxWidth, checkboxHeight), "h");
    width += checkboxWidth;
    EditorGUI.LabelField(new Rect(width, height, checkboxWidth, checkboxHeight), "r");
    width += checkboxWidth;

    height += checkboxHeight;
    for (int x = 0, l = b.Count(); x < l ; x++)
    {

     
      width = Left;
      ClapWave wave = b.GetWave(x);
      for (int y = 0; y < wave.Notes.Length; y++)
      {
        
        EditorGUI.DrawRect(new Rect(width- 5, height - 5, checkboxWidth, checkboxHeight), (wave.Notes[y])?((Colors)y).GetColor(): ((Colors)y).GetColor() * 0.8f);
        
        wave.Notes[ y] = EditorGUI.Toggle(new Rect(width, height, checkboxWidth, checkboxHeight), wave.Notes[y]);
        width += checkboxWidth;

      }
      
      wave.Hold = EditorGUI.Toggle(new Rect(width, height, checkboxWidth, checkboxHeight), wave.Hold);
      width += checkboxWidth;

      wave.Release = EditorGUI.Toggle(new Rect(width, height, checkboxWidth, checkboxHeight), wave.Release);
      width += checkboxWidth;


      if (x % ClapWaveSequence.MEASURELENGHT == 0)
      {
        EditorGUI.DrawRect(new Rect(0, height -5, position.width, 2), new Color(0.3f, 0.35f, 0.4f));
        EditorGUI.LabelField(new Rect(5, height, 20, 20), "" + (x / ClapWaveSequence.MEASURELENGHT + 1));
      }

      height += checkboxHeight;
    }
    GUILayout.Label("", GUILayout.Width(position.width), GUILayout.Height(height - 30));
    GUILayout.EndScrollView();
  }
}
