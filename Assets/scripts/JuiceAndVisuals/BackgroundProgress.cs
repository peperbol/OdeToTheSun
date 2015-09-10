using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundProgress : MonoBehaviour {
    public Color start;
    public Color end;
    SpriteRenderer sr;
    public float progressOfDisapear = 0.5f;
    void Start() {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Camera.main.backgroundColor = Color.Lerp(start, end, GameProgress.Progress);
        Color c = sr.color;
        c.a =1 - Mathf.Clamp(GameProgress.Progress, 0, progressOfDisapear) / progressOfDisapear;
        sr.color = c;
    }
}
