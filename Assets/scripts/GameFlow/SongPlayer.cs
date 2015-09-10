using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

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
  public string songName;
    private NoteSpawner ns;
    private Juicificationator juice;

    public ClapWaveSequence WaveSequence
    {
        get { return waveSequence; }
    }
	void Start () {
        ns = GameObject.FindObjectOfType<NoteSpawner>();
        juice = GameObject.FindObjectOfType<Juicificationator>();

        timeElapsed = 0;
		timePerBeat = 60 / GameProperties.BeatsPerMinute;
		timeTillNextBeat = timePerBeat;
		timeTillNextMeasure = timePerBeat * 4;		// 4/4 time signature, 4 beats per measure	timePerBeat = 60 / bpm;

		waveSequence = ClapWaveSequence.LoadSequenceFile(songName,timePerBeat);
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
            if (currentBeatId == GameProperties.BeatsUntilCenter )
                backgroundMusicAudioSource.Play();
            //Debug.Log("Beat");
			//Debug.Log(timeTillNetBeat);
			timeTillNextBeat = timePerBeat + timeTillNextBeat;
            ClapWave wave = waveSequence.GetWave(currentBeatId);
            string waveStr = wave.ToString();
            //effectsAudioSource.PlayOneShot(beatSound);
            ns.SpawnWave(wave);
			currentBeatId++;
            //TODO vincent INVESTIGATE
            juice.onTheBeat();

            if (currentBeatId >= WaveSequence.Count())
            {
                GameObject.FindObjectOfType<EndOfGame>().End();
            }
        }

		// not now, maybe later for juuuuice 
		if (timeTillNextMeasure <= 0) {
			timeTillNextMeasure = timePerBeat * 4;
			//TODO visualizer.SpawnMeasure();
		}
	}
  
}
