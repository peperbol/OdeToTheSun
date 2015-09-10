using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Renderer))]
public class VisualFade : MonoBehaviour {
    public bool visible;
    public float timeToFade = 1;
    private Renderer srenderer;
	void Start () {
        srenderer = GetComponent<Renderer>();
	}

	void Update () {
        Color c = srenderer.material.color;
        c.a = Mathf.Clamp(c.a + ((visible) ? 1 : -1) * Time.deltaTime / timeToFade, 0, 1);
        srenderer.material.color = c;
    }
}
