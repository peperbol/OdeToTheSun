using UnityEngine;
using System.Collections;

public class NoteSpawner : MonoBehaviour {


	private Vector3[] spawnpoints;
	public Note NotePrefab;

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

    void spawnNote(int player, Hand hand) {
        Note o = Instantiate<Note>(NotePrefab);
        o.transform.position = spawnpoints[toIndex(player, hand)];
        o.ColorOfNote = (Colors)toIndex(player, hand);
    }

    public void spawn2RandomNotes()
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

        spawnNote(firstNotePlayer, firstNoteHand);
        spawnNote(secondNotePlayer, secondNoteHand);
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
