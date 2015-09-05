using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SpriteRenderer))]
public class VisualFade : MonoBehaviour {
    public bool visible;
    public float timeToFade = 1;
    private SpriteRenderer srenderer;
	void Start () {
        srenderer = GetComponent<SpriteRenderer>();
	}

	void Update () {
        Color c = srenderer.color;
        c.a = Mathf.Clamp(c.a + ((visible) ? 1 : -1) * Time.deltaTime * timeToFade, 0, 1);
        srenderer.color = c;
    }
}
