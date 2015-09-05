using UnityEngine;
using System.Collections;

public class NoteSpawner : MonoBehaviour {


	private Vector3[] spawnpoints;
	public Note NotePrefab;

	// Use this for initialization
	void Start () {
        spawnpoints = calculateSpawnPoints();

        for (int i = 0; i < 1; i++) {
            spawnNote(i, Hand.LEFT);
            spawnNote(i, Hand.RIGHT);
        }
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
