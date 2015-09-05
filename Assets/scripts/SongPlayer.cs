using UnityEngine;
using System.Collections;
using System.IO;

public class SongPlayer : MonoBehaviour {

	public bool playing = false;

	// In seconds
	private float timePerBeat;
	private int currentBeatId = 0;

	private float timeElapsed = 0;
	private float timeTillNextBeat;
	private float timeTillNextMeasure;		// 4/4 time signature, 4 beats per measure

	private ClapWaveSequence waveSequence = new ClapWaveSequence();

	public AudioClip beatSound;
	public AudioSource backgroundMusicAudioSource;
	public AudioSource effectsAudioSource;
    private NoteSpawner ns;
	// Use this for initialization
	void Start () {
        ns = GameObject.FindObjectOfType<NoteSpawner>();

		timeElapsed = 0;
		timePerBeat = 60 / GameProperties.BeatsPerMinute;
		timeTillNextBeat = timePerBeat;
		timeTillNextMeasure = timePerBeat * 4;		// 4/4 time signature, 4 beats per measure	timePerBeat = 60 / bpm;

		LoadSequenceFile("sequence.txt");
	}

	public void ApplyTimestampOffset(float offset) {
		waveSequence.ApplyTimestampOffset(offset);
	}

	public void Play() {
		playing = true;
	}
	
	void Update () {
		if (!playing) 
			return;
       
		this.timeElapsed += Time.deltaTime;
		timeTillNextBeat -= Time.deltaTime;
        

		if (timeTillNextBeat <= 0) {
            if (currentBeatId == GameProperties.BeatsUntilCenter - 1)
                backgroundMusicAudioSource.Play();
            Debug.Log("Beat");
			timeTillNextBeat = timePerBeat - timeTillNextBeat;
            ClapWave wave = waveSequence.GetWave(currentBeatId);
            string waveStr = wave.ToString();
            //effectsAudioSource.PlayOneShot(beatSound);
            ns.SpawnWave(wave);
			currentBeatId++;
		}

		// not now, maybe later for juuuuice 
		if (timeTillNextMeasure <= 0) {
			timeTillNextMeasure = timePerBeat * 4;
			//TODO visualizer.SpawnMeasure();
		}
	}

	public void LoadSequenceFile(string fileName) {
		string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
        Debug.Log ("filePath " + filePath);
		FileInfo file = new FileInfo (filePath);
        StreamReader reader = file.OpenText();
        string line = reader.ReadLine();
	

        do
        {
            bool[] claps = new bool[8];
            if (line[0] == '#')
            {
                line = reader.ReadLine();
                continue;
            }

			for (int i = 0; i < 8; i++)
				claps[i] = line[i] != BeatSequence.NONE;
			bool hold = line.Length > 8 && line[8] == BeatSequence.HOLD;
			bool release = line.Length > 8 && line[8] == BeatSequence.RELEASE ;
			ClapWave wave = new ClapWave(claps, hold, release);
			waveSequence.Add(wave);

            Debug.Log(line);
			Debug.Log(wave.ToString());
            line = reader.ReadLine();
        } while (line != null);        

		waveSequence.GenerateTimeStamps(timePerBeat);
	}
}
