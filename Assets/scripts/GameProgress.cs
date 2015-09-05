using UnityEngine;
using System.Collections;

public class GameProgress : MonoBehaviour {
    public static float totalbeats {
        get { return 60; }// to be edited
    }
    public static float beatHitProgress {
        get { return 1/(totalbeats * GameProperties.BEAT_SUCCEED_RATIO); }
    }
    public static float beatMissProgress
    {
        get { return -beatHitProgress/2; }
    }

    [Range(0, 1)]
    public float startProgress; // debug field
    public static float progress;
    private static SunGrowth sg;

    private static BeatSequence sequence;
    public static BeatSequence Sequence {
        get {
            if (sequence == null) {
                sequence = new BeatSequence(BeatSequence.Path);
            }
            return sequence;
        }
        set { sequence = value; }
    }

    void Start () {
        sg = GameObject.FindObjectOfType<SunGrowth>();
        progress = startProgress;
	}
    public static void HitBeat()
    {
        progress += beatHitProgress;
    }
    public static void MissBeat()
    {
        progress += beatMissProgress;
    }
}
