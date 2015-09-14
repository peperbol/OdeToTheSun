using UnityEngine;
using System.Collections;

public class NoteSpawner : MonoBehaviour {


	private Vector3[] spawnpoints;
	public Note NotePrefab;
    public ProceduralRing RingPrefab;

	// Use this for initialization
	void Start () {
        spawnpoints = calculateSpawnPoints();
    }

    Vector3[] calculateSpawnPoints()
    {
        Vector3[] result = new Vector3[GameProperties.NUMBER_OF_COLORS];
        for (int i = 0; i < GameProperties.NUMBER_OF_PLAYERS; i++)
        {
            float angle_to_player = 2 * Mathf.PI / GameProperties.NUMBER_OF_PLAYERS * i;
            result[toIndex(i, Hand.LEFT)] = new Vector3(
                    Mathf.Cos(angle_to_player - GameProperties.ANGLE_OFFSET_BETWEEN_HANDS) * GameProperties.SpawnRadius,
                    Mathf.Sin(angle_to_player - GameProperties.ANGLE_OFFSET_BETWEEN_HANDS) * GameProperties.SpawnRadius,
                    0
                );
            result[toIndex(i, Hand.RIGHT)] = new Vector3(
                    Mathf.Cos(angle_to_player + GameProperties.ANGLE_OFFSET_BETWEEN_HANDS) * GameProperties.SpawnRadius,
                    Mathf.Sin(angle_to_player + GameProperties.ANGLE_OFFSET_BETWEEN_HANDS) * GameProperties.SpawnRadius,
                    0
                );
        }
        return result;
    }

    void spawnNote(SolarColor color) {
        Note o = Instantiate<Note>(NotePrefab);
        o.transform.position = spawnpoints[(int)color];
        o.ColorOfNote = color;
        o.GetComponent<MoveTowards>().turnToLeft = ((int)color % 2 == 0);
    }


    void spawnRing()
    {
        ProceduralRing r = Instantiate<ProceduralRing>(RingPrefab);
        r.centerDistance = GameProperties.SpawnRadius;
        r.shrinkingSpeed = GameProperties.NoteVelocity;
    }
    public void SpawnWave(ClapWave wave) {
        for (int i = 0; i < wave.Notes.Length; i++)
        {
            if (wave.Notes[i]) {
                spawnNote((SolarColor)i);
            }
        }
        spawnRing();
    }

    public void spawn2RandomNotesWithRing()
    {
        int firstNotePlayer = Random.Range(0,GameProperties.NUMBER_OF_PLAYERS);
        Hand firstNoteHand = Random.value < .5 ? Hand.LEFT : Hand.RIGHT;

        int secondNotePlayer = Random.Range(0, GameProperties.NUMBER_OF_PLAYERS);
        Hand secondNoteHand = Random.value < .5 ? Hand.LEFT : Hand.RIGHT;

        while(firstNotePlayer == secondNotePlayer && firstNoteHand == secondNoteHand)
        {
            secondNotePlayer = Random.Range(0, GameProperties.NUMBER_OF_PLAYERS);
            secondNoteHand = Random.value < .5 ? Hand.LEFT : Hand.RIGHT;
        }
        /*
        spawnNote(firstNotePlayer, firstNoteHand);
        spawnNote(secondNotePlayer, secondNoteHand);
        */
        spawnRing();
    }
    
    public static int toIndex(int player, Hand hand)
    {
        return player * 2 + (int)hand;
    }

    // Update is called once per frame
    void Update () {
        
	}

    public enum Hand
    {
        LEFT = 0, RIGHT = 1
    }
}
