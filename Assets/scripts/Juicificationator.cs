using UnityEngine;
using System.Collections;
using System;

public class Juicificationator : MonoBehaviour {
    [Range(0,4)]
    public float maxSizePulse = 1.25f;

    [Range(0, 4)]
    public float maxColorPulse = 1.05f;

    public void onTheBeat()
    {
        beatTheNotes();
        beatTheBackground();
    }

    private void beatTheBackground()
    {
        StartCoroutine(pulseBackgroundColor(Camera.main, 0.1f, maxColorPulse, 0.5f));
    }

    private void beatTheNotes()
    {
        Note[] visibleNotes = GameObject.FindObjectsOfType<Note>();
        foreach (Note note in visibleNotes)
        {
            onTheBeat(note);
        }
    }

    private void onTheBeat(Note note)
    {
        StartCoroutine(pulseSize(note.transform, 0.02f, maxSizePulse, 0.5f));
    }

    private IEnumerator pulseSize(Transform target, float widenTime, float maxSize, float shrinkTime)
    {
        float currTime = 0;
        Vector3 initialScale = target.localScale;

        while (currTime < widenTime && target != null)
        {
            float scale = Mathf.Lerp(1, maxSize, currTime / widenTime);
            target.localScale = initialScale * scale;

            currTime += Time.deltaTime;
            yield return null;
        }

        while (currTime < shrinkTime && target != null)
        {
            float scale = Mathf.Lerp(maxSize, 1, (currTime - widenTime) / shrinkTime);
            target.localScale = initialScale * scale;

            currTime += Time.deltaTime;
            yield return null;
        }

        if ( target != null)
        {
            target.localScale = initialScale;
        }

        yield return null;
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

        yield return null;
    }

}
