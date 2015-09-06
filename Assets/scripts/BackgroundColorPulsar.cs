using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class BackgroundColorPulsar : MonoBehaviour {

    [Range(0, 4)]
    public float maxColorPulse = 1.05f;

    public void startPulse()
    {
        Camera target = GetComponent<Camera>();
        StartCoroutine(pulseBackgroundColor(target, 0.1f, maxColorPulse, 0.5f));
    }

    private IEnumerator pulseBackgroundColor(Camera target, float widenTime, float maxBrightness, float shrinkTime)
    {
        float currTime = 0;
        Color initial = target.backgroundColor;

        while (currTime < widenTime && target != null)
        {
            float scale = Mathf.Lerp(1, maxBrightness, currTime / widenTime);
            target.backgroundColor = initial * scale;

            currTime += Time.deltaTime;
            yield return null;
        }

        while (currTime < shrinkTime && target != null)
        {
            float scale = Mathf.Lerp(maxBrightness, 1, (currTime - widenTime) / shrinkTime);
            target.backgroundColor = initial * scale;

            currTime += Time.deltaTime;
            yield return null;
        }

        if (target != null)
        {
            target.backgroundColor = initial;
        }

    }
}
