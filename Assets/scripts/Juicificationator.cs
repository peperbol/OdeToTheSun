using UnityEngine;
using System.Collections;
using System;

public class Juicificationator : MonoBehaviour {
    [Range(0,4)]
    public float maxSize = 2f;
	public void onTheBeat()
    {
        Note[] visibleNotes = GameObject.FindObjectsOfType<Note>();
        foreach(Note note in visibleNotes)
        {
            onTheBeat(note);
        }
    }

    private void onTheBeat(Note note)
    {
        StartCoroutine(pulse(note.transform, 0.1f, maxSize, 0.5f));
    }

    private IEnumerator pulse(Transform target, float widenTime, float maxSize, float shrinkTime)
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


}
