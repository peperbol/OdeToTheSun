using UnityEngine;
using System.Collections;

public class NoteSpawner : MonoBehaviour {


	private Vector3[] spawnpoints = new Vector3[GameProperties.NUMBER_OF_COLORS];
	public GameObject NotePrefab;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < GameProperties. NUMBER_OF_COLORS; i++) {
			spawnpoints[i] = new Vector3(
					Mathf.Cos(2 * Mathf.PI/ GameProperties.NUMBER_OF_COLORS * i) * GameProperties.SpawnRadius,
				Mathf.Sin(2 * Mathf.PI/ GameProperties.NUMBER_OF_COLORS * i) * GameProperties.SpawnRadius,
					0
				);
			Debug.Log(spawnpoints[i].x);
		}
		for (int i = 0; i < 2; i++) {
			GameObject o = Instantiate<GameObject>(NotePrefab);
			o.transform.position = spawnpoints[i];
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
