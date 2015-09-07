using UnityEngine;
using System.Collections;

public class GameProgress : MonoBehaviour {
    private static float beats = 0;
    public static float totalbeats {
        get {
            if (beats == 0) {
                int c = 0;
                ClapWaveSequence seq = FindObjectOfType<SongPlayer>().WaveSequence;

                for (int i = 0; i < seq.Count(); i++)
                {
                    for (int j = 0; j < seq.GetWave(i).Notes.Length; j++)
                    {
                        if (seq.GetWave(i).Notes[j]) c++;
                    }
                }
                beats = c;
            }
            return beats;

        }// to be edited
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
 
    public static float Progress {
        get { return progress; }
        set {
            progress = Mathf.Clamp(value, 0, 1);
            if(progress == 1)
            {
                GameObject.FindObjectOfType<EndOfGame>().End();
            }
        }
    }
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
        Progress = startProgress;
	}

	public void Update() {
		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			Progress = 1;
		}

	}

    public static void HitBeat()
    {
        Progress += beatHitProgress;
    }
    public static void MissBeat()
    {
        Progress += beatMissProgress;
    }
}
