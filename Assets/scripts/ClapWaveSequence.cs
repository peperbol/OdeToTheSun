using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClapWaveSequence {

	List<ClapWave> waves;

	public ClapWaveSequence() {
		waves = new List<ClapWave>();
	}

	public void Add(ClapWave wave) {
		wave.SetId(waves.Count + 1);
		waves.Add(wave);
	}

	public void GenerateTimeStamps(float timePerBeat) {
		for (int i = 0; i < waves.Count; i++) 
			waves[i].SetTimeStamp(timePerBeat * i);
	}

	public int Count() {
		return waves.Count;
	}

	public ClapWave GetWave(int waveId) {
		return waves[waveId];
	}

	public void ApplyTimestampOffset(float offset) {
		// TODO
	}
}

public class ClapWave {

	private int id; 			// Id of the wave in the sequence (0-Count)
	private bool[] notes;
	private bool hold;
	private bool release;
	private float timeStamp = 0;

	public ClapWave(bool[] notes, bool hold=false, bool release=false) {
		this.notes = notes;
		this.hold = hold;
		this.release = release;
	}
    public bool[] Notes {
        get { return notes; }
    }
	public void SetId(int id) {
		this.id = id;
	}

	public void SetTimeStamp(float timeStamp) {
		this.timeStamp = timeStamp;
	}

	public float GetTimeStamp() {
		return timeStamp;
	}

	public string ToString() {
		string str = "";

		for (int i = 0; i < notes.Length; i++) {
			if (notes[i])
				str += "x";
			else 
				str += "-";
		}

		if (release)
			str += " release";
		if (hold)
			str += " hold";

		return str;
	}

}
