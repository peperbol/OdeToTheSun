using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundColorPulsar : Pulsar
{

    [Range(0, 4)]
    public float maxColorPulse = 0.05f;

    override public void startPulse()
    {
        SpriteRenderer target = GetComponent<SpriteRenderer>();
        StartCoroutine(pulseBackgroundColor(target, 0.1f, maxColorPulse, GameProperties.SecondsPerBeat - 0.05f));
    }

    private IEnumerator pulseBackgroundColor(SpriteRenderer target, float widenTime, float maxBrightness, float shrinkTime)
    {
        float currTime = 0;
        Color initial = target.color;

        while (currTime < widenTime && target != null)
        {
            float scale = Mathf.Lerp(0, maxBrightness, currTime / widenTime);
            initial.a = scale;
            target.color = initial;

            currTime += Time.deltaTime;
            yield return null;
        }

        while (currTime < shrinkTime && target != null)
        {
            float scale = Mathf.Lerp(maxBrightness, 0, (currTime - widenTime) / shrinkTime);
            initial.a = scale;
            target.color = initial;

            currTime += Time.deltaTime;
            yield return null;
        }

        if (target != null)
        {

            initial.a = 0;
            target.color = initial;
        }

    }
}
